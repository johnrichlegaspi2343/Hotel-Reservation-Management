using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    public class RoomController
    {
        private RoomRepository roomRepo = new RoomRepository();

        // ===================== ROOM TYPES =====================

        public List<RoomType> GetRoomTypes()
        {
            return roomRepo.GetRoomTypes();
        }

        public void AddRoomType(string name, decimal rate)
        {
            ValidateRoomType(name, rate, 0);

            RoomType type = new RoomType();
            type.Name = name.Trim();
            type.Rate = rate;
            roomRepo.AddRoomType(type);
        }

        public void UpdateRoomType(int id, string name, decimal rate)
        {
            ValidateRoomType(name, rate, id);
            roomRepo.UpdateRoomType(id, name.Trim(), rate);
        }

        private void ValidateRoomType(string name, decimal rate, int id)
        {
            if (name.Trim() == "")
                throw new Exception("Room type name is required.");

            if (rate <= 0)
                throw new Exception("Room rate must be greater than zero.");

            if (roomRepo.RoomTypeNameExists(name.Trim(), id))
                throw new Exception("Room type already exists.");
        }

        // ===================== ROOMS =====================

        public List<Room> GetRooms()
        {
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
            roomRepo.UpdateRoom(id, roomNumber.Trim(), roomTypeId);
        }

        private void ValidateRoom(string roomNumber, int roomTypeId, int id)
        {
            if (roomNumber.Trim() == "")
                throw new Exception("Room number is required.");

            if (roomTypeId <= 0)
                throw new Exception("Room type is required.");

            if (roomRepo.RoomNumberExists(roomNumber.Trim(), id))
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

            roomRepo.UpdateRoomStatus(id, status);
        }

        public void DeleteRoom(int id)
        {
            Room? room = roomRepo.GetRoomById(id);
            if (room == null)
                throw new Exception("Room not found.");

            if (room.Status == "Reserved" || room.Status == "Occupied")
                throw new Exception("Cannot delete a room that is " + room.Status + ".");

            roomRepo.DeactivateRoom(id);
        }
    }
}