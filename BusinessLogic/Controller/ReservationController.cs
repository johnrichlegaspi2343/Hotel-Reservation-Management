using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    public class ReservationController
    {
        private ReservationRepository reservationRepo = new ReservationRepository();
        private RoomRepository roomRepo = new RoomRepository();
        private GuestRepository guestRepo = new GuestRepository();

        // ===================== AVAILABILITY =====================

        public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int roomTypeId)
        {
            ValidateDates(checkIn, checkOut);

            List<Room> rooms = roomRepo.GetAvailableRooms(checkIn.Date, checkOut.Date, roomTypeId);
            if (rooms.Count == 0)
                throw new Exception("No rooms available for the selected dates.");

            return rooms;
        }

        private void ValidateDates(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn.Date < DateTime.Today)
                throw new Exception("Check-in date cannot be in the past.");

            if (checkOut.Date <= checkIn.Date)
                throw new Exception("Check-out date must be later than check-in date.");
        }

        // ===================== RESERVATION =====================

        // status = "Pending" o "Confirmed"
        public Reservation CreateReservation(int guestId, int roomId, DateTime checkIn, DateTime checkOut, string status)
        {
            ValidateDates(checkIn, checkOut);

            if (status != "Pending" && status != "Confirmed")
                throw new Exception("Status must be Pending or Confirmed.");

            Guest? guest = guestRepo.GetGuestById(guestId);
            if (guest == null)
                throw new Exception("Please select a guest.");

            Room? room = roomRepo.GetRoomById(roomId);
            if (room == null || !room.IsActive)
                throw new Exception("Please select a room.");

            if (room.Status == "Maintenance")
                throw new Exception("Room " + room.RoomNumber + " is under maintenance.");

            // Walang double-booking
            if (reservationRepo.IsRoomBooked(roomId, checkIn.Date, checkOut.Date))
                throw new Exception("Room " + room.RoomNumber + " is already booked for these dates.");

            Reservation reservation = new Reservation();
            reservation.GuestId = guestId;
            reservation.RoomId = roomId;
            reservation.CheckInDate = checkIn.Date;
            reservation.CheckOutDate = checkOut.Date;
            reservation.RoomRate = room.Rate;
            reservation.Status = status;
            reservationRepo.AddReservation(reservation);

            // Automatic: nagiging Reserved ang room
            roomRepo.UpdateRoomStatus(roomId, "Reserved");

            return reservation;
        }

        public List<Reservation> GetReservations()
        {
            return reservationRepo.GetReservations();
        }

        // Hanapin gamit ang Reservation ID, hal. "RES-0001"
        public Reservation FindReservation(string code)
        {
            int id = CodeHelper.ToId(code, "RES-");

            Reservation? reservation = reservationRepo.GetReservationById(id);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            return reservation;
        }

        // ===================== RESERVATION STATUS =====================

        // Pending -> Confirmed o Cancelled
        // Confirmed -> Pending o Cancelled
        public void UpdateStatus(int reservationId, string newStatus)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (newStatus != "Pending" && newStatus != "Confirmed" && newStatus != "Cancelled")
                throw new Exception("Please select Pending, Confirmed or Cancelled.");

            if (reservation.Status != "Pending" && reservation.Status != "Confirmed")
                throw new Exception("A " + reservation.Status + " reservation can no longer be changed.");

            if (reservation.Status == newStatus)
                throw new Exception("Reservation is already " + newStatus + ".");

            if (newStatus == "Cancelled" && reservation.AmountPaid > 0)
                throw new Exception("Cannot cancel: this reservation already has a payment.");

            reservationRepo.UpdateStatus(reservationId, newStatus);

            // Automatic: kapag cancelled, available na ulit ang room
            if (newStatus == "Cancelled")
            {
                roomRepo.UpdateRoomStatus(reservation.RoomId, "Available");
            }
        }

        // ===================== CHECK-IN / CHECK-OUT =====================

        public void CheckIn(int reservationId)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "Confirmed")
                throw new Exception("Only Confirmed reservations can be checked in. Current status: " + reservation.Status);

            if (DateTime.Today < reservation.CheckInDate)
                throw new Exception("Check-in date is " + reservation.CheckInDate.ToString("MM/dd/yyyy") + ". It is too early to check in.");

            reservationRepo.UpdateStatus(reservationId, "CheckedIn");

            // Automatic: nagiging Occupied ang room
            roomRepo.UpdateRoomStatus(reservation.RoomId, "Occupied");
        }

        public void CheckOut(int reservationId)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "CheckedIn")
                throw new Exception("Only checked-in guests can be checked out.");

            if (reservation.Balance > 0)
                throw new Exception("Cannot check out. Remaining balance: P" + reservation.Balance.ToString("N2"));

            reservationRepo.UpdateStatus(reservationId, "Completed");

            // Automatic: available na ulit ang room
            roomRepo.UpdateRoomStatus(reservation.RoomId, "Available");
        }
    }
}