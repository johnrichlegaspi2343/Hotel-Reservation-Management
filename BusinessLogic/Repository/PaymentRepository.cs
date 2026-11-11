using Microsoft.EntityFrameworkCore;
using Model;

namespace BusinessLogic.Repository
{
    public class PaymentRepository
    {
        public List<Payment> GetPayments()
        {
            using (var db = new AppDBContext())
            {
                return db.Payments
                    .Include("Reservation.Guest")
                    .Include("Reservation.Room.RoomType")
                    .Include("Reservation.Payments")
                    .OrderByDescending(p => p.Id)
                    .ToList();
            }
        }

        public Payment? GetPaymentById(int id)
        {
            using (var db = new AppDBContext())
            {
                return db.Payments
                    .Include("Reservation.Guest")
                    .Include("Reservation.Room.RoomType")
                    .Include("Reservation.Payments")
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public void AddPayment(Payment payment)
        {
            using (var db = new AppDBContext())
            {
                db.Payments.Add(payment);
                db.SaveChanges();   // pagkatapos nito, may Id na ang payment
            }
        }
    }
}