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

        // Mga room na bakante sa petsang ito. roomTypeId = 0 kung lahat ng type.
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

        // Gumagawa ng reservation na may 1 hanggang 5 rooms.
        // Laging PENDING muna. Magiging Confirmed kapag nabayaran na ang 50% downpayment (sa Billing).
        public Reservation CreateReservation(int guestId, List<int> roomIds, DateTime checkIn, DateTime checkOut, int numberOfGuests)
        {
            CancelExpiredReservations();
            ValidateDates(checkIn, checkOut);

            Guest? guest = guestRepo.GetGuestById(guestId);
            if (guest == null)
                throw new Exception("Please select a guest.");

            if (guest.IdType == "" || guest.IdNumber == "")
                throw new Exception(guest.FullName + " has no Valid ID yet. Please update the guest information first.");

            // ---------- Rooms ----------
            if (roomIds.Count == 0)
                throw new Exception("Please select at least one room.");

            if (roomIds.Count > HotelPolicy.MaxRoomsPerReservation)
                throw new Exception("Maximum of " + HotelPolicy.MaxRoomsPerReservation + " rooms per reservation.");

            Reservation reservation = new Reservation();
            int totalCapacity = 0;

            foreach (int roomId in roomIds)
            {
                // Bawal ang dobleng room sa iisang reservation
                foreach (ReservationRoom added in reservation.Rooms)
                {
                    if (added.RoomId == roomId)
                        throw new Exception("The same room was selected twice.");
                }

                Room? room = roomRepo.GetRoomById(roomId);
                if (room == null || !room.IsActive)
                    throw new Exception("Room not found. Please select the room again.");

                if (room.Status == "Maintenance")
                    throw new Exception("Room " + room.RoomNumber + " is under maintenance.");

                // Walang double-booking ng room
                if (reservationRepo.IsRoomBooked(roomId, checkIn.Date, checkOut.Date, 0))
                    throw new Exception("Room " + room.RoomNumber + " is already booked for these dates.");

                ReservationRoom rr = new ReservationRoom();
                rr.RoomId = roomId;
                rr.RoomRate = room.Rate;    // rate ngayon, hindi magbabago kahit itaas ng Admin
                reservation.Rooms.Add(rr);

                totalCapacity += room.MaxGuests;
            }

            // ---------- Guests ----------
            if (numberOfGuests < 1)
                throw new Exception("Number of guests must be at least 1.");

            if (numberOfGuests > totalCapacity)
                throw new Exception("The selected room(s) are only good for " + totalCapacity + " guest(s). Please add another room.");

            // Walang double-booking ng guest
            if (reservationRepo.GuestHasOverlappingReservation(guestId, checkIn.Date, checkOut.Date))
                throw new Exception(guest.FullName + " already has a reservation on these dates.");

            reservation.GuestId = guestId;
            reservation.CheckInDate = checkIn.Date;
            reservation.CheckOutDate = checkOut.Date;
            reservation.Status = "Pending";
            reservation.NumberOfGuests = numberOfGuests;
            reservationRepo.AddReservation(reservation);

            // Ibabalik ang buong reservation (may guest, rooms at bill na)
            Reservation? saved = reservationRepo.GetReservationById(reservation.Id);
            if (saved == null)
                throw new Exception("Reservation was not saved. Please try again.");

            return saved;
        }

        // PANSAMANTALA para sa lumang Reservation form (isang room lang).
        // Tatanggalin kapag tapos na ang bagong Reservation form.
        public Reservation CreateReservation(int guestId, int roomId, DateTime checkIn, DateTime checkOut, string status, int numberOfGuests)
        {
            List<int> roomIds = new List<int>();
            roomIds.Add(roomId);
            return CreateReservation(guestId, roomIds, checkIn, checkOut, numberOfGuests);
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

        public Reservation GetReservationById(int id)
        {
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

        // ===================== MANAGE RESERVATIONS (filters) =====================

        // Darating ngayon (Confirmed, check-in date ay ngayon)
        public List<Reservation> GetTodaysArrivals()
        {
            List<Reservation> result = new List<Reservation>();
            foreach (Reservation r in GetReservations())
            {
                if (r.Status == "Confirmed" && r.CheckInDate.Date == DateTime.Today)
                    result.Add(r);
            }
            return result;
        }

        // Aalis ngayon (naka-check-in, check-out date ay ngayon o lampas na)
        public List<Reservation> GetTodaysDepartures()
        {
            List<Reservation> result = new List<Reservation>();
            foreach (Reservation r in GetReservations())
            {
                if (r.Status == "CheckedIn" && r.CheckOutDate.Date <= DateTime.Today)
                    result.Add(r);
            }
            return result;
        }

        // Nasa hotel ngayon (naka-check-in)
        public List<Reservation> GetInHouse()
        {
            List<Reservation> result = new List<Reservation>();
            foreach (Reservation r in GetReservations())
            {
                if (r.Status == "CheckedIn")
                    result.Add(r);
            }
            return result;
        }

        // Hindi pa nakakabayad ng downpayment
        public List<Reservation> GetPendingPayment()
        {
            List<Reservation> result = new List<Reservation>();
            foreach (Reservation r in GetReservations())
            {
                if (r.Status == "Pending")
                    result.Add(r);
            }
            return result;
        }

        // ===================== AUTO-CANCEL =====================

        // Automatic na kina-cancel ang:
        //   Pending na hindi nakapag-downpayment hanggang sa check-in date (ibabalik ang naibayad)
        //   Confirmed na hindi dumating (no-show): hindi na ibabalik ang downpayment
        public void CancelExpiredReservations()
        {
            List<Reservation> expired = reservationRepo.GetExpiredReservations(DateTime.Today);

            foreach (Reservation r in expired)
            {
                if (r.Status == "Pending")
                    reservationRepo.UpdateRefund(r.Id, r.AmountPaid);

                reservationRepo.UpdateStatus(r.Id, "Cancelled");
                RoomStatusHelper.RefreshRooms(r);
            }

            // Status ng lahat ng room para sa araw na ito
            RoomStatusHelper.RefreshAll();
        }

        // ===================== CANCELLATION =====================

        // TRUE kung libre pa ang cancel (hanggang 1 araw bago ang check-in)
        // Hal. check-in Dec 24 -> libre kung Dec 22 o mas maaga
        public bool IsFreeCancellation(Reservation reservation)
        {
            if (reservation.Status == "Pending")
                return true;    // hindi pa Confirmed, ibabalik ang anumang naibayad

            return DateTime.Today < reservation.CheckInDate.Date.AddDays(-HotelPolicy.FreeCancelDays);
        }

        // Kina-cancel ang reservation. Ibinabalik ang refund (0 kung hindi na refundable).
        public decimal CancelReservation(int reservationId)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "Pending" && reservation.Status != "Confirmed")
                throw new Exception("A " + reservation.Status + " reservation can no longer be cancelled.");

            decimal refund = 0;
            if (IsFreeCancellation(reservation))
                refund = reservation.AmountPaid;

            reservationRepo.UpdateRefund(reservationId, refund);
            reservationRepo.UpdateStatus(reservationId, "Cancelled");

            // Bakante na ulit ang mga room
            RoomStatusHelper.RefreshRooms(reservation);

            return refund;
        }

        // PANSAMANTALA para sa lumang Reservation Status form.
        // Automatic na ang Confirmed (pagkabayad ng downpayment), kaya Cancel na lang ang puwede.
        public void UpdateStatus(int reservationId, string newStatus)
        {
            if (newStatus == "Cancelled")
            {
                CancelReservation(reservationId);
                return;
            }

            throw new Exception("Reservations are confirmed automatically after the " +
                HotelPolicy.DownpaymentPercent + "% downpayment is paid in Billing / Payment.");
        }

        // ===================== CHECK-IN / CHECK-OUT =====================

        // Ilang oras ang pagitan (kahit 1 minuto lang ay bilang na 1 oras)
        private int CountHours(DateTime from, DateTime to)
        {
            if (to <= from)
                return 0;

            return (int)Math.Ceiling((to - from).TotalHours);
        }

        // Check-in ng LAHAT ng room ng reservation.
        // Kinukuha ang security deposit (P1,000 bawat room).
        // Ibinabalik ang early check-in fee (0 kung hindi maaga).
        public decimal CheckIn(int reservationId)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status == "Pending")
                throw new Exception("Please pay the " + HotelPolicy.DownpaymentPercent + "% downpayment first (P" +
                    reservation.DownpaymentDue.ToString("N2") + ").");

            if (reservation.Status != "Confirmed")
                throw new Exception("Only Confirmed reservations can be checked in. Current status: " + reservation.Status);

            if (DateTime.Today < reservation.CheckInDate)
                throw new Exception("Check-in date is " + reservation.CheckInDate.ToString("MM/dd/yyyy") + ". It is too early to check in.");

            // No-show: lampas na ang check-out date
            if (DateTime.Today >= reservation.CheckOutDate)
                throw new Exception("This reservation has already passed its check-out date (" +
                    reservation.CheckOutDate.ToString("MM/dd/yyyy") + "). The guest did not arrive (no-show).");

            // Hindi puwedeng mag-check-in kapag may naka-check-in pa sa alinmang room
            foreach (ReservationRoom rr in reservation.Rooms)
            {
                if (reservationRepo.RoomHasCheckedInGuest(rr.RoomId, reservationId))
                    throw new Exception("Room " + rr.Room?.RoomNumber + " still has a checked-in guest.");
            }

            // Early check-in: bago mag-2:00 PM, P200 kada oras bawat room
            int earlyHours = CountHours(DateTime.Now, reservation.ExpectedCheckIn);
            decimal earlyFee = earlyHours * HotelPolicy.FeePerHour * reservation.Rooms.Count;
            reservationRepo.UpdateFees(reservationId, earlyFee, reservation.LateCheckOutFee);

            // Security deposit: P1,000 bawat room
            decimal deposit = HotelPolicy.SecurityDepositPerRoom * reservation.Rooms.Count;
            reservationRepo.UpdateSecurityDeposit(reservationId, deposit);

            reservationRepo.UpdateStatus(reservationId, "CheckedIn");

            // Automatic: nagiging Occupied ang lahat ng room
            RoomStatusHelper.RefreshRooms(reservation);

            return earlyFee;
        }

        // Late check-out (bawat room):
        //   lampas 12:00 NN hanggang 6:00 PM -> P200 kada oras
        //   lampas 6:00 PM                   -> singil ng 1 buong gabi (rate ng room)
        // Ginagamit ng Check-Out at ng Billing para updated ang bill.
        public decimal UpdateLateCheckOutFee(Reservation reservation)
        {
            if (reservation.Status != "CheckedIn")
                return reservation.LateCheckOutFee;

            decimal lateFee;
            DateTime limit = reservation.CheckOutDate.Date.AddHours(HotelPolicy.LateCheckOutLimitHour);

            if (DateTime.Now > limit)
            {
                lateFee = reservation.RoomRate;     // 1 gabi ng lahat ng room
            }
            else
            {
                int lateHours = CountHours(reservation.ExpectedCheckOut, DateTime.Now);
                lateFee = lateHours * HotelPolicy.FeePerHour * reservation.Rooms.Count;
            }

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

            // Automatic: Available ulit ang lahat ng room
            RoomStatusHelper.RefreshRooms(reservation);
        }
    }
}