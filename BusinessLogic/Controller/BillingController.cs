using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    public class BillingController
    {
        private PaymentRepository paymentRepo = new PaymentRepository();
        private ReservationRepository reservationRepo = new ReservationRepository();
        private ChargeRepository chargeRepo = new ChargeRepository();

        // ===================== PAYMENT =====================

        // paymentMethod = "Cash", "Card" o "GCash"
        // Pending: ang unang bayad ay dapat hindi bababa sa 50% downpayment -> magiging Confirmed
        public Payment ProcessPayment(int reservationId, decimal amount, string paymentMethod)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "Pending" && reservation.Status != "Confirmed" && reservation.Status != "CheckedIn")
                throw new Exception("Payment is not allowed for a " + reservation.Status + " reservation.");

            if (paymentMethod != "Cash" && paymentMethod != "Card" && paymentMethod != "GCash")
                throw new Exception("Please select a payment method (Cash, Card or GCash).");

            if (amount <= 0)
                throw new Exception("Payment amount must be greater than zero.");

            // Hanggang centavos lang (2 decimal places)
            if (amount != Math.Round(amount, 2))
                throw new Exception("Payment amount can only have up to 2 decimal places.");

            if (reservation.Balance <= 0)
                throw new Exception("This bill is already fully paid.");

            if (amount > reservation.Balance)
                throw new Exception("Amount is more than the remaining balance (P" + reservation.Balance.ToString("N2") + ").");

            bool willConfirm = false;
            if (reservation.Status == "Pending")
            {
                // Dapat buo ang downpayment
                if (amount < reservation.DownpaymentDue)
                    throw new Exception("Minimum payment to confirm this reservation is P" +
                        reservation.DownpaymentDue.ToString("N2") + " (" + HotelPolicy.DownpaymentPercent + "% downpayment).");

                // Baka may ibang nakabayad na para sa parehong room (unang nakabayad ang panalo)
                foreach (ReservationRoom rr in reservation.Rooms)
                {
                    if (reservationRepo.IsRoomBooked(rr.RoomId, reservation.CheckInDate, reservation.CheckOutDate, reservation.Id))
                        throw new Exception("Sorry, room " + rr.Room?.RoomNumber + " was already taken by another reservation. " +
                            "Please cancel this reservation and choose another room.");
                }

                willConfirm = true;
            }

            Payment payment = new Payment();
            payment.ReservationId = reservationId;
            payment.Amount = amount;
            payment.PaymentMethod = paymentMethod;
            payment.PaymentDate = DateTime.Now;
            payment.ProcessedBy = Session.CurrentUser != null ? Session.CurrentUser.Username : "";
            paymentRepo.AddPayment(payment);

            // Nabayaran ang downpayment -> Confirmed na, hawak na ang room
            if (willConfirm)
            {
                reservationRepo.UpdateStatus(reservationId, "Confirmed");
                RoomStatusHelper.RefreshRooms(reservation);
            }

            return payment;
        }

        // Ginagamit ang security deposit pambayad sa natitirang balance (bago mag-check-out).
        // Ibinabalik kung magkano ang nagamit. Ang matitira sa deposit ay ibabalik sa guest.
        public decimal UseSecurityDeposit(int reservationId)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "CheckedIn")
                throw new Exception("The security deposit can only be used for checked-in guests.");

            decimal remainingDeposit = reservation.SecurityDeposit - reservation.DepositUsed;
            if (remainingDeposit <= 0)
                throw new Exception("No security deposit left to use.");

            if (reservation.Balance <= 0)
                throw new Exception("This bill is already fully paid.");

            // Gagamitin lang ang kailangan
            decimal amount = remainingDeposit;
            if (amount > reservation.Balance)
                amount = reservation.Balance;

            Payment payment = new Payment();
            payment.ReservationId = reservationId;
            payment.Amount = amount;
            payment.PaymentMethod = "Deposit";
            payment.PaymentDate = DateTime.Now;
            payment.ProcessedBy = Session.CurrentUser != null ? Session.CurrentUser.Username : "";
            paymentRepo.AddPayment(payment);

            return amount;
        }

        // ===================== ADDITIONAL CHARGES =====================

        // description = hal. "Extra Bed", "Room Damage - broken glass"
        public void AddCharge(int reservationId, string description, decimal amount)
        {
            Reservation? reservation = reservationRepo.GetReservationById(reservationId);
            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != "Confirmed" && reservation.Status != "CheckedIn")
                throw new Exception("Charges can only be added to Confirmed or Checked-In reservations.");

            if (description.Trim() == "")
                throw new Exception("Please select or enter the charge description.");

            if (amount <= 0)
                throw new Exception("Charge amount must be greater than zero.");

            if (amount != Math.Round(amount, 2))
                throw new Exception("Charge amount can only have up to 2 decimal places.");

            if (amount > 100000)
                throw new Exception("Charge amount is too high. Maximum is P100,000.");

            Charge charge = new Charge();
            charge.ReservationId = reservationId;
            charge.Description = description.Trim();
            charge.Amount = amount;
            charge.DateAdded = DateTime.Now;
            charge.AddedBy = Session.CurrentUser != null ? Session.CurrentUser.Username : "";
            chargeRepo.AddCharge(charge);
        }

        // Kapag nagkamali ng lagay ng charge
        public void RemoveCharge(int chargeId)
        {
            Charge? charge = chargeRepo.GetChargeById(chargeId);
            if (charge == null)
                throw new Exception("Charge not found.");

            Reservation? reservation = reservationRepo.GetReservationById(charge.ReservationId);
            if (reservation == null || (reservation.Status != "Confirmed" && reservation.Status != "CheckedIn"))
                throw new Exception("Charges can only be removed from Confirmed or Checked-In reservations.");

            // Hindi puwedeng mag-negative ang balance (may bayad na para dito)
            if (reservation.Balance - charge.Amount < 0)
                throw new Exception("Cannot remove: this charge has already been paid.");

            chargeRepo.DeleteCharge(chargeId);
        }

        // ===================== RECORDS AT RECEIPT =====================

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
            receipt += "Cashier: " + payment.ProcessedBy + "\n";
            receipt += "--------------------------------\n";
            receipt += "Guest: " + r.Guest?.FullName + " (" + r.Guest?.GuestCode + ")\n";
            receipt += "Reservation ID: " + r.ReservationCode + "\n";
            receipt += "Check-in: " + r.ExpectedCheckIn.ToString("MM/dd/yyyy hh:mm tt") + "\n";
            receipt += "Check-out: " + r.ExpectedCheckOut.ToString("MM/dd/yyyy hh:mm tt") + "\n";
            receipt += "Nights: " + r.Nights + "\n";
            receipt += "--------------------------------\n";

            // Bawat room
            foreach (ReservationRoom rr in r.Rooms)
            {
                receipt += "Room " + rr.Room?.RoomNumber + " (" + rr.Room?.RoomTypeName + ") " +
                    "P" + rr.RoomRate.ToString("N2") + " x " + r.Nights + " = P" + (rr.RoomRate * r.Nights).ToString("N2") + "\n";
            }

            // Bawat additional charge
            foreach (Charge c in r.Charges)
            {
                receipt += c.Description + ": P" + c.Amount.ToString("N2") + "\n";
            }

            receipt += "Early/Late Fee: P" + r.ExtraCharges.ToString("N2") + "\n";
            receipt += "--------------------------------\n";
            receipt += "Total Bill: P" + r.TotalBill.ToString("N2") + "\n";
            receipt += "Amount Paid: P" + payment.Amount.ToString("N2") + " (" + payment.PaymentMethod + ")\n";
            receipt += "Total Paid: P" + r.AmountPaid.ToString("N2") + "\n";
            receipt += "Remaining Balance: P" + r.Balance.ToString("N2") + "\n";

            if (r.SecurityDeposit > 0)
                receipt += "Security Deposit: P" + r.SecurityDeposit.ToString("N2") +
                    " (Refund: P" + r.DepositRefund.ToString("N2") + ")\n";

            receipt += "--------------------------------\n";
            receipt += "Thank you for your stay!";
            return receipt;
        }
    }
}