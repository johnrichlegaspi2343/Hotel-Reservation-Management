using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Reservation
    {
        public int Id { get; set; }

        public int GuestId { get; set; }
        public Guest? Guest { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        // Rate ng room noong ginawa ang reservation
        [Column(TypeName = "decimal(10,2)")]
        public decimal RoomRate { get; set; }

        // Pending, Confirmed, Cancelled, CheckedIn, Completed
        public string Status { get; set; } = "Pending";

        // Ilang guest ang titira sa room (1 - 4)
        public int NumberOfGuests { get; set; } = 1;

        public DateTime? ActualCheckIn { get; set; }
        public DateTime? ActualCheckOut { get; set; }

        // Multa kapag maagang nag-check-in o late nag-check-out
        [Column(TypeName = "decimal(10,2)")]
        public decimal EarlyCheckInFee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal LateCheckOutFee { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();

        // Reservation ID na ipinapakita sa screen, hal. RES-0001
        [NotMapped]
        public string ReservationCode
        {
            get { return "RES-" + Id.ToString("0000"); }
        }

        [NotMapped]
        public int Nights
        {
            get { return (CheckOutDate.Date - CheckInDate.Date).Days; }
        }

        // Oras ng check-in: check-in date + 2:00 PM
        [NotMapped]
        public DateTime ExpectedCheckIn
        {
            get { return CheckInDate.Date.AddHours(HotelPolicy.CheckInHour); }
        }

        // Oras ng check-out: check-out date + 12:00 NN
        [NotMapped]
        public DateTime ExpectedCheckOut
        {
            get { return CheckOutDate.Date.AddHours(HotelPolicy.CheckOutHour); }
        }

        // Room Charges = Rate x Nights
        [NotMapped]
        public decimal RoomCharges
        {
            get { return RoomRate * Nights; }
        }

        // Early check-in fee + late check-out fee
        [NotMapped]
        public decimal ExtraCharges
        {
            get { return EarlyCheckInFee + LateCheckOutFee; }
        }

        // Total Bill = Room Charges + Early/Late Fee
        [NotMapped]
        public decimal TotalBill
        {
            get { return RoomCharges + ExtraCharges; }
        }

        [NotMapped]
        public decimal AmountPaid
        {
            get
            {
                decimal total = 0;
                foreach (Payment p in Payments)
                {
                    total += p.Amount;
                }
                return total;
            }
        }

        [NotMapped]
        public decimal Balance
        {
            get { return TotalBill - AmountPaid; }
        }

        [NotMapped]
        public string PaymentStatus
        {
            get
            {
                if (AmountPaid <= 0) return "Unpaid";
                if (Balance <= 0) return "Paid";
                return "Partially Paid";
            }
        }
    }

    public class Payment
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = "";   // Cash, Card, GCash
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string ProcessedBy { get; set; } = "";

        // Transaction ID na ipinapakita sa screen, hal. TRX-0001
        [NotMapped]
        public string TransactionId
        {
            get { return "TRX-" + Id.ToString("0000"); }
        }
    }
}