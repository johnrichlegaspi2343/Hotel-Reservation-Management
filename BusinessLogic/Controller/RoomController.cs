using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    public class RoomController
    {
        private RoomRepository roomRepo = new RoomRepository();
        private ReservationRepository reservationRepo = new ReservationRepository();

        // ===================== ROOM TYPES =====================

        public List<RoomType> GetRoomTypes()
        {
            return roomRepo.GetRoomTypes();
        }

        // bedSize   = description ng kama, hal. "2 Double Beds"
        // beds      = ilang kama (1 hanggang 3)
        // amenities = hal. "Aircon, TV, WiFi, 1 CR"
        public void AddRoomType(string name, decimal rate, string bedSize, int maxGuests, int beds = 1, string amenities = "")
        {
            ValidateRoomType(name, rate, bedSize, maxGuests, beds, 0);

            RoomType type = new RoomType();
            type.Name = name.Trim();
            type.Rate = rate;
            type.BedSize = bedSize.Trim();
            type.MaxGuests = maxGuests;
            type.Beds = beds;
            type.Amenities = amenities.Trim();
            roomRepo.AddRoomType(type);
        }

        public void UpdateRoomType(int id, string name, decimal rate, string bedSize, int maxGuests, int beds = 1, string amenities = "")
        {
            ValidateRoomType(name, rate, bedSize, maxGuests, beds, id);
            roomRepo.UpdateRoomType(id, name.Trim(), rate, bedSize.Trim(), maxGuests, beds, amenities.Trim());
        }

        private void ValidateRoomType(string name, decimal rate, string bedSize, int maxGuests, int beds, int id)
        {
            if (name.Trim() == "")
                throw new Exception("Room type name is required.");

            if (rate <= 0)
                throw new Exception("Room rate must be greater than zero.");

            if (rate > 100000)
                throw new Exception("Room rate is too high. Maximum is P100,000.");

            if (rate != Math.Round(rate, 2))
                throw new Exception("Room rate can only have up to 2 decimal places.");

            if (beds < 1 || beds > HotelPolicy.MaxBedsPerRoom)
                throw new Exception("Number of beds must be from 1 to " + HotelPolicy.MaxBedsPerRoom + ".");

            if (bedSize.Trim() == "")
                throw new Exception("Please enter the bed description (example: 2 Double Beds).");

            if (maxGuests < 1 || maxGuests > HotelPolicy.MaxGuestsPerRoom)
                throw new Exception("Max guests must be from 1 to " + HotelPolicy.MaxGuestsPerRoom + ".");

            if (roomRepo.RoomTypeNameExists(name.Trim(), id))
                throw new Exception("Room type already exists.");
        }

        // ===================== ROOMS =====================

        public List<Room> GetRooms()
        {
            // Para updated ang status ng mga room sa araw na ito
            RoomStatusHelper.RefreshAll();
            return roomRepo.GetRooms();
        }

        public void AddRoom(string roomNumber, int roomTypeId)
        {
            ValidateRoom(roomNumber, roomTypeId, 0);

            Room room = new Room();
            room.RoomNumber = roomNumber.Trim();
            room.RoomTypeId = roomTypeId;
            room.Status = "Available";
            roomRepo.AddRoom(room);
        }

        public void UpdateRoom(int id, string roomNumber, int roomTypeId)
        {
            ValidateRoom(roomNumber, roomTypeId, id);

            Room? room = roomRepo.GetRoomById(id);
            if (room == null)
                throw new Exception("Room not found.");

            // Bawal palitan ang room number o room type kapag may active na booking
            bool changed = room.RoomNumber != roomNumber.Trim() || room.RoomTypeId != roomTypeId;
            if (changed && reservationRepo.RoomHasActiveReservation(id))
                throw new Exception("Room " + room.RoomNumber + " has an active reservation. Its number and type cannot be changed.");

            roomRepo.UpdateRoom(id, roomNumber.Trim(), roomTypeId);
        }

        // Room number: 3 digits, numero lang, hindi nagsisimula sa 0 (hal. 101 hanggang 999)
        private void ValidateRoom(string roomNumber, int roomTypeId, int id)
        {
            roomNumber = roomNumber.Trim();

            if (roomNumber == "")
                throw new Exception("Room number is required.");

            if (roomNumber.Length != 3 || !CodeHelper.IsDigits(roomNumber) || roomNumber.StartsWith("0"))
                throw new Exception("Room number must be 3 digits (example: 101).");

            if (roomTypeId <= 0)
                throw new Exception("Room type is required.");

            if (roomRepo.RoomNumberExists(roomNumber, id))
                throw new Exception("Room number already exists.");
        }

        // Available at Maintenance lang ang puwedeng i-set ng Admin.
        // Ang Reserved at Occupied ay automatic (galing sa Reservation at Check-In).
        public void SetRoomStatus(int id, string status)
        {
            if (status != "Available" && status != "Maintenance")
                throw new Exception("You can only set a room to Available or Maintenance.");

            Room? room = roomRepo.GetRoomById(id);
            if (room == null)
                throw new Exception("Room not found.");

            if (room.Status == "Reserved" || room.Status == "Occupied")
                throw new Exception("Room " + room.RoomNumber + " is " + room.Status + ". Its status cannot be changed manually.");

            // Bawal i-Maintenance kapag may naka-book pa (kahit sa susunod na buwan)
            if (status == "Maintenance" && reservationRepo.RoomHasActiveReservation(id))
                throw new Exception("Room " + room.RoomNumber + " has an upcoming reservation. Cancel or move it first.");

            roomRepo.UpdateRoomStatus(id, status);

            // Galing Maintenance -> tingnan kung may reservation ngayong araw
            if (status == "Available")
                RoomStatusHelper.Refresh(id);
        }

        public void DeleteRoom(int id)
        {
            Room? room = roomRepo.GetRoomById(id);
            if (room == null)
                throw new Exception("Room not found.");

            if (room.Status == "Reserved" || room.Status == "Occupied")
                throw new Exception("Cannot delete a room that is " + room.Status + ".");

            // Bawal i-delete kapag may naka-book pa (kahit sa susunod na buwan)
            if (reservationRepo.RoomHasActiveReservation(id))
                throw new Exception("Cannot delete room " + room.RoomNumber + ". It has an upcoming reservation.");

            roomRepo.DeactivateRoom(id);
        }
    }
}