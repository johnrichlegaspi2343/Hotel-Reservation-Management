using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    public class BillingController
    {
        private PaymentRepository paymentRepo = new PaymentRepository();
        private ReservationRepository reservationRepo = new ReservationRepository();

        // paymentMethod = "Cash", "Card" o "GCash"
        public Payment ProcessPayment(int reservationId, decimal amount, string paymentMethod)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "Confirmed" && reservation.Status != "CheckedIn")
                throw new Exception("Payment is only allowed for Confirmed or Checked-In reservations.");

            if (paymentMethod == "")
                throw new Exception("Please select a payment method.");

            if (amount <= 0)
                throw new Exception("Payment amount must be greater than zero.");

            if (reservation.Balance <= 0)
                throw new Exception("This bill is already fully paid.");

            if (amount > reservation.Balance)
                throw new Exception("Amount is more than the remaining balance (P" + reservation.Balance.ToString("N2") + ").");

            Payment payment = new Payment();
            payment.ReservationId = reservationId;
            payment.Amount = amount;
            payment.PaymentMethod = paymentMethod;
            payment.PaymentDate = DateTime.Now;
            payment.ProcessedBy = Session.CurrentUser != null ? Session.CurrentUser.Username : "";
            paymentRepo.AddPayment(payment);

            return payment;
        }

        // Para sa Billing Records (Admin)
        public List<Payment> GetPayments()
        {
            return paymentRepo.GetPayments();
        }

        // Laman ng receipt, galing sa database
        public string GetReceipt(int paymentId)
        {
            Payment? payment = paymentRepo.GetPaymentById(paymentId);
            if (payment == null || payment.Reservation == null)
                throw new Exception("Payment not found.");

            Reservation r = payment.Reservation;

            string receipt = "";
            receipt += "HOTEL RESERVATION\n";
            receipt += "PAYMENT RECEIPT\n";
            receipt += "--------------------------------\n";
            receipt += "Transaction ID: " + payment.TransactionId + "\n";
            receipt += "Date: " + payment.PaymentDate.ToString("MM/dd/yyyy hh:mm tt") + "\n";
            receipt += "--------------------------------\n";
            receipt += "Guest: " + r.Guest?.FullName + " (" + r.Guest?.GuestCode + ")\n";
            receipt += "Reservation ID: " + r.ReservationCode + "\n";
            receipt += "Room: " + r.Room?.RoomNumber + " (" + r.Room?.RoomTypeName + ")\n";
            receipt += "Nights: " + r.Nights + "\n";
            receipt += "--------------------------------\n";
            receipt += "Total Bill: P" + r.TotalBill.ToString("N2") + "\n";
            receipt += "Amount Paid: P" + payment.Amount.ToString("N2") + "\n";
            receipt += "Payment Method: " + payment.PaymentMethod + "\n";
            receipt += "Remaining Balance: P" + r.Balance.ToString("N2") + "\n";
            receipt += "--------------------------------\n";
            receipt += "Thank you for your stay!";
            return receipt;
        }
    }
}