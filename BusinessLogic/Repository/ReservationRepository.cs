using Microsoft.EntityFrameworkCore;
using Model;

namespace BusinessLogic.Repository
{
    public class ReservationRepository
    {
        public List<Reservation> GetReservations()
        {
            using (var db = new AppDBContext())
            {
                return db.Reservations
                    .Include("Guest")
                    .Include("Room.RoomType")
                    .Include("Payments")
                    .OrderByDescending(r => r.Id)
                    .ToList();
            }
        }

        public Reservation? GetReservationById(int id)
        {
            using (var db = new AppDBContext())
            {
                return db.Reservations
                    .Include("Guest")
                    .Include("Room.RoomType")
                    .Include("Payments")
                    .FirstOrDefault(r => r.Id == id);
            }
        }

        // TRUE kung may Pending/Confirmed/CheckedIn na reservation ang room na tumatama sa petsa
        public bool IsRoomBooked(int roomId, DateTime checkIn, DateTime checkOut)
        {
            using (var db = new AppDBContext())
            {
                return db.Reservations.Any(r =>
                    r.RoomId == roomId &&
                    (r.Status == "Pending" || r.Status == "Confirmed" || r.Status == "CheckedIn") &&
                    r.CheckInDate < checkOut &&
                    checkIn < r.CheckOutDate);
            }
        }

        // TRUE kung may Pending/Confirmed/CheckedIn na reservation ang guest
        public bool GuestHasActiveReservation(int guestId)
        {
            using (var db = new AppDBContext())
            {
                return db.Reservations.Any(r =>
                    r.GuestId == guestId &&
                    (r.Status == "Pending" || r.Status == "Confirmed" || r.Status == "CheckedIn"));
            }
        }

        // TRUE kung may Pending/Confirmed/CheckedIn na reservation ang room (kahit anong petsa)
        public bool RoomHasActiveReservation(int roomId)
        {
            using (var db = new AppDBContext())
            {
                return db.Reservations.Any(r =>
                    r.RoomId == roomId &&
                    (r.Status == "Pending" || r.Status == "Confirmed" || r.Status == "CheckedIn"));
            }
        }

        // TRUE kung may naka-check-in na guest sa room ngayon
        public bool RoomHasCheckedInGuest(int roomId)
        {
            using (var db = new AppDBContext())
            {
                return db.Reservations.Any(r => r.RoomId == roomId && r.Status == "CheckedIn");
            }
        }

        // TRUE kung may ibang reservation na ang guest na tumatama sa parehong petsa
        public bool GuestHasOverlappingReservation(int guestId, DateTime checkIn, DateTime checkOut)
        {
            using (var db = new AppDBContext())
            {
                return db.Reservations.Any(r =>
                    r.GuestId == guestId &&
                    (r.Status == "Pending" || r.Status == "Confirmed" || r.Status == "CheckedIn") &&
                    r.CheckInDate < checkOut &&
                    checkIn < r.CheckOutDate);
            }
        }

        // Mga reservation na expired na:
        //   Pending na lumampas na ang check-in date (hindi na-confirm)
        //   Confirmed na lumampas na ang check-out date at walang bayad (no-show)
        public List<Reservation> GetExpiredReservations(DateTime today)
        {
            using (var db = new AppDBContext())
            {
                return db.Reservations
                    .Where(r => (r.Status == "Pending" && r.CheckInDate < today) ||
                                (r.Status == "Confirmed" && r.CheckOutDate <= today && !r.Payments.Any()))
                    .ToList();
            }
        }

        // Hanapin gamit ang pangalan ng guest, room number o status.
        // Puwedeng maraming salita: "juan 301" = si Juan sa room 301.
        // Nauuna ang mga active (Pending, Confirmed, CheckedIn), tapos ang pinakabago.
        public List<Reservation> Search(string text)
        {
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            using (var db = new AppDBContext())
            {
                IQueryable<Reservation> query = db.Reservations
                    .Include("Guest")
                    .Include("Room.RoomType")
                    .Include("Payments");

                foreach (string word in words)
                {
                    string w = word;
                    query = query.Where(r => r.Guest!.FirstName.Contains(w) ||
                                             r.Guest!.LastName.Contains(w) ||
                                             r.Room!.RoomNumber.Contains(w) ||
                                             r.Status.Contains(w));
                }

                return query
                    .OrderBy(r => (r.Status == "Pending" || r.Status == "Confirmed" || r.Status == "CheckedIn") ? 0 : 1)
                    .ThenByDescending(r => r.Id)
                    .ToList();
            }
        }

        public void AddReservation(Reservation reservation)
        {
            using (var db = new AppDBContext())
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();   // pagkatapos nito, may Id na ang reservation
            }
        }

        public void UpdateStatus(int id, string status)
        {
            using (var db = new AppDBContext())
            {
                Reservation? reservation = db.Reservations.Find(id);
                if (reservation != null)
                {
                    reservation.Status = status;

                    if (status == "CheckedIn") reservation.ActualCheckIn = DateTime.Now;
                    if (status == "Completed") reservation.ActualCheckOut = DateTime.Now;

                    db.SaveChanges();
                }
            }
        }

        // I-save ang early check-in fee at late check-out fee
        public void UpdateFees(int id, decimal earlyCheckInFee, decimal lateCheckOutFee)
        {
            using (var db = new AppDBContext())
            {
                Reservation? reservation = db.Reservations.Find(id);
                if (reservation != null)
                {
                    reservation.EarlyCheckInFee = earlyCheckInFee;
                    reservation.LateCheckOutFee = lateCheckOutFee;
                    db.SaveChanges();
                }
            }
        }
    }
}