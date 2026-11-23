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
            CancelExpiredReservations();
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

            // Hanggang 1 taon lang mula ngayon puwedeng mag-book
            if (checkIn.Date > DateTime.Today.AddDays(HotelPolicy.MaxDaysAhead))
                throw new Exception("Reservations can only be made up to " + HotelPolicy.MaxDaysAhead + " days ahead.");

            // Pinakamahabang stay
            int nights = (checkOut.Date - checkIn.Date).Days;
            if (nights > HotelPolicy.MaxNights)
                throw new Exception("Maximum stay is " + HotelPolicy.MaxNights + " nights.");
        }

        // ===================== RESERVATION =====================

        // status = "Pending" o "Confirmed"
        public Reservation CreateReservation(int guestId, int roomId, DateTime checkIn, DateTime checkOut, string status, int numberOfGuests)
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

            // Dapat kasya ang guests sa room
            if (numberOfGuests < 1)
                throw new Exception("Number of guests must be at least 1.");

            if (room.RoomType != null && numberOfGuests > room.RoomType.MaxGuests)
                throw new Exception("Room " + room.RoomNumber + " is only good for " + room.RoomType.MaxGuests + " guest(s).");

            // Walang double-booking ng room
            if (reservationRepo.IsRoomBooked(roomId, checkIn.Date, checkOut.Date))
                throw new Exception("Room " + room.RoomNumber + " is already booked for these dates.");

            // Walang double-booking ng guest
            if (reservationRepo.GuestHasOverlappingReservation(guestId, checkIn.Date, checkOut.Date))
                throw new Exception(guest.FullName + " already has a reservation on these dates.");

            Reservation reservation = new Reservation();
            reservation.GuestId = guestId;
            reservation.RoomId = roomId;
            reservation.CheckInDate = checkIn.Date;
            reservation.CheckOutDate = checkOut.Date;
            reservation.RoomRate = room.Rate;
            reservation.Status = status;
            reservation.NumberOfGuests = numberOfGuests;
            reservationRepo.AddReservation(reservation);

            // Automatic: nagiging Reserved ang room (pero hindi kung may naka-check-in pa)
            RefreshRoomStatus(roomId);

            return reservation;
        }

        public List<Reservation> GetReservations()
        {
            CancelExpiredReservations();
            return reservationRepo.GetReservations();
        }

        // Hanapin gamit ang Reservation ID, hal. "RES-0001", "res1" o "1"
        public Reservation FindReservation(string code)
        {
            CancelExpiredReservations();
            int id = CodeHelper.ToId(code, "RES-");

            Reservation? reservation = reservationRepo.GetReservationById(id);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            return reservation;
        }

        // Mas madaling paghahanap. Puwede ang:
        //   Reservation ID -> "RES-0001", "res1", "1"
        //   Pangalan       -> "Juan", "Juan Santos"
        //   Room number    -> "301"
        //   Status         -> "Pending", "CheckedIn"
        // Nauuna ang mga active na reservation.
        public List<Reservation> SearchReservations(string text)
        {
            CancelExpiredReservations();

            text = text.Trim();
            if (text == "")
                throw new Exception("Please enter a Reservation ID, guest name or room number.");

            List<Reservation> result = new List<Reservation>();

            if (CodeHelper.StartsWithPrefix(text, "RES"))
            {
                // Reservation ID lang
                Reservation? r = reservationRepo.GetReservationById(CodeHelper.ToId(text, "RES-"));
                if (r != null) result.Add(r);
            }
            else
            {
                // Numero lang (hal. "5") = puwedeng Reservation ID
                if (CodeHelper.IsDigits(text) && text.Length <= 4)
                {
                    Reservation? r = reservationRepo.GetReservationById(CodeHelper.ToId(text, "RES-"));
                    if (r != null) result.Add(r);
                }

                // Pangalan, room number o status
                foreach (Reservation r in reservationRepo.Search(text))
                {
                    if (!ContainsReservation(result, r.Id))
                        result.Add(r);
                }
            }

            if (result.Count == 0)
                throw new Exception("No reservation found for \"" + text + "\".");

            return result;
        }

        // TRUE kung nasa listahan na ang reservation (para walang doble)
        private bool ContainsReservation(List<Reservation> list, int id)
        {
            foreach (Reservation r in list)
            {
                if (r.Id == id) return true;
            }
            return false;
        }

        // ===================== AUTO-CANCEL =====================

        // Automatic na kina-cancel ang:
        //   Pending na hindi na-confirm bago ang check-in date
        //   Confirmed na hindi dumating (no-show) at walang bayad
        public void CancelExpiredReservations()
        {
            List<Reservation> expired = reservationRepo.GetExpiredReservations(DateTime.Today);

            foreach (Reservation r in expired)
            {
                reservationRepo.UpdateStatus(r.Id, "Cancelled");
                RefreshRoomStatus(r.RoomId);
            }
        }

        // ===================== ROOM STATUS =====================

        // Inaayos ang status ng room base sa mga reservation nito:
        //   may naka-check-in            -> Occupied
        //   may Pending o Confirmed pa   -> Reserved
        //   wala na                      -> Available
        // Hindi ginagalaw kapag Maintenance.
        private void RefreshRoomStatus(int roomId)
        {
            Room? room = roomRepo.GetRoomById(roomId);
            if (room == null || room.Status == "Maintenance")
                return;

            if (reservationRepo.RoomHasCheckedInGuest(roomId))
                roomRepo.UpdateRoomStatus(roomId, "Occupied");
            else if (reservationRepo.RoomHasActiveReservation(roomId))
                roomRepo.UpdateRoomStatus(roomId, "Reserved");
            else
                roomRepo.UpdateRoomStatus(roomId, "Available");
        }

        // ===================== RESERVATION STATUS =====================

        // Pending -> Confirmed o Cancelled
        // Confirmed -> Pending o Cancelled
        public void UpdateStatus(int reservationId, string newStatus)
        {
            CancelExpiredReservations();

            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (newStatus != "Pending" && newStatus != "Confirmed" && newStatus != "Cancelled")
                throw new Exception("Please select Pending, Confirmed or Cancelled.");

            if (reservation.Status != "Pending" && reservation.Status != "Confirmed")
                throw new Exception("A " + reservation.Status + " reservation can no longer be changed.");

            if (reservation.Status == newStatus)
                throw new Exception("Reservation is already " + newStatus + ".");

            // Hindi na puwedeng i-confirm kapag lampas na ang check-out date
            if (newStatus == "Confirmed" && DateTime.Today >= reservation.CheckOutDate)
                throw new Exception("This reservation has already passed its check-out date.");

            if (newStatus == "Cancelled" && reservation.AmountPaid > 0)
                throw new Exception("Cannot cancel: this reservation already has a payment.");

            reservationRepo.UpdateStatus(reservationId, newStatus);

            // Automatic: inaayos ang status ng room (Available kung wala nang ibang booking)
            RefreshRoomStatus(reservation.RoomId);
        }

        // ===================== CHECK-IN / CHECK-OUT =====================

        // Ilang oras ang pagitan (kahit 1 minuto lang ay bilang na 1 oras)
        private int CountHours(DateTime from, DateTime to)
        {
            if (to <= from)
                return 0;

            return (int)Math.Ceiling((to - from).TotalHours);
        }

        // Ibinabalik ang early check-in fee (0 kung hindi maaga)
        public decimal CheckIn(int reservationId)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "Confirmed")
                throw new Exception("Only Confirmed reservations can be checked in. Current status: " + reservation.Status);

            if (DateTime.Today < reservation.CheckInDate)
                throw new Exception("Check-in date is " + reservation.CheckInDate.ToString("MM/dd/yyyy") + ". It is too early to check in.");

            // No-show: lampas na ang check-out date
            if (DateTime.Today >= reservation.CheckOutDate)
                throw new Exception("This reservation has already passed its check-out date (" +
                    reservation.CheckOutDate.ToString("MM/dd/yyyy") + "). The guest did not arrive (no-show).");

            // Hindi puwedeng mag-check-in kapag may naka-check-in pa sa room
            if (reservationRepo.RoomHasCheckedInGuest(reservation.RoomId))
                throw new Exception("Room " + reservation.Room?.RoomNumber + " still has a checked-in guest.");

            // Early check-in: bago mag-2:00 PM, may bayad kada oras
            int earlyHours = CountHours(DateTime.Now, reservation.ExpectedCheckIn);
            decimal earlyFee = earlyHours * HotelPolicy.FeePerHour;
            reservationRepo.UpdateFees(reservationId, earlyFee, reservation.LateCheckOutFee);

            reservationRepo.UpdateStatus(reservationId, "CheckedIn");

            // Automatic: nagiging Occupied ang room
            roomRepo.UpdateRoomStatus(reservation.RoomId, "Occupied");

            return earlyFee;
        }

        // Late check-out: lampas 12:00 NN ng check-out date, may bayad kada oras.
        // Ginagamit ng Check-Out at ng Billing para updated ang bill.
        public decimal UpdateLateCheckOutFee(Reservation reservation)
        {
            if (reservation.Status != "CheckedIn")
                return reservation.LateCheckOutFee;

            int lateHours = CountHours(reservation.ExpectedCheckOut, DateTime.Now);
            decimal lateFee = lateHours * HotelPolicy.FeePerHour;

            // I-save lang kung tumaas ang multa
            if (lateFee > reservation.LateCheckOutFee)
            {
                reservationRepo.UpdateFees(reservation.Id, reservation.EarlyCheckInFee, lateFee);
                reservation.LateCheckOutFee = lateFee;
            }

            return reservation.LateCheckOutFee;
        }

        public void CheckOut(int reservationId)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "CheckedIn")
                throw new Exception("Only checked-in guests can be checked out.");

            // Kung lampas na sa 12:00 NN, idadagdag ang late check-out fee sa bill
            decimal lateFee = UpdateLateCheckOutFee(reservation);

            if (reservation.Balance > 0)
            {
                string message = "Cannot check out. Remaining balance: P" + reservation.Balance.ToString("N2");
                if (lateFee > 0)
                    message += "\n(Includes late check-out fee: P" + lateFee.ToString("N2") + ")";
                message += "\nPlease settle the bill in Billing / Payment first.";
                throw new Exception(message);
            }

            reservationRepo.UpdateStatus(reservationId, "Completed");

            // Automatic: Available ulit, o Reserved kung may susunod pang booking
            RefreshRoomStatus(reservation.RoomId);
        }
    }
}