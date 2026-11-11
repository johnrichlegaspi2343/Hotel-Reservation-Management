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

        public DateTime? ActualCheckIn { get; set; }
        public DateTime? ActualCheckOut { get; set; }

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

        // Room Charges = Rate x Nights
        [NotMapped]
        public decimal TotalBill
        {
            get { return RoomRate * Nights; }
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