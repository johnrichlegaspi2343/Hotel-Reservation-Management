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
    }
}