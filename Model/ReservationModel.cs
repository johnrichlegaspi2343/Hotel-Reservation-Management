using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Reservation
    {
        public int Id { get; set; }

        public int GuestId { get; set; }
        public Guest? Guest { get; set; }

        // Mga room ng reservation (1 hanggang 5)
        public List<ReservationRoom> Rooms { get; set; } = new List<ReservationRoom>();

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        // Pending, Confirmed, Cancelled, CheckedIn, Completed
        //   Pending   = wala pang 50% downpayment, hindi pa hawak ang room
        //   Confirmed = nakabayad na ng downpayment, hawak na ang room
        public string Status { get; set; } = "Pending";

        // Lahat ng tao (bata man o matanda)
        public int NumberOfGuests { get; set; } = 1;

        public DateTime? ActualCheckIn { get; set; }
        public DateTime? ActualCheckOut { get; set; }

        // Multa kapag maagang nag-check-in o late nag-check-out
        [Column(TypeName = "decimal(10,2)")]
        public decimal EarlyCheckInFee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal LateCheckOutFee { get; set; }

        // Security deposit na kinuha sa check-in (P1,000 bawat room)
        [Column(TypeName = "decimal(10,2)")]
        public decimal SecurityDeposit { get; set; }

        // Ibinalik sa guest kapag nag-cancel (libreng cancellation)
        [Column(TypeName = "decimal(10,2)")]
        public decimal RefundAmount { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();
        public List<Charge> Charges { get; set; } = new List<Charge>();

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

        // ---------- ROOMS ----------

        // Mga room number, hal. "201, 305"
        [NotMapped]
        public string RoomNumbers
        {
            get
            {
                string text = "";
                foreach (ReservationRoom rr in Rooms)
                {
                    if (text != "") text += ", ";
                    text += rr.Room != null ? rr.Room.RoomNumber : rr.RoomId.ToString();
                }
                return text;
            }
        }

        // Ilang guest ang kasya sa lahat ng room
        [NotMapped]
        public int TotalCapacity
        {
            get
            {
                int total = 0;
                foreach (ReservationRoom rr in Rooms)
                {
                    total += rr.Room != null ? rr.Room.MaxGuests : 0;
                }
                return total;
            }
        }

        // Pinagsamang rate ng lahat ng room kada gabi
        [NotMapped]
        public decimal RoomRate
        {
            get
            {
                decimal total = 0;
                foreach (ReservationRoom rr in Rooms)
                {
                    total += rr.RoomRate;
                }
                return total;
            }
        }

        // PANSAMANTALA para sa lumang forms: ang unang room ng reservation.
        // Gamitin ang Rooms o RoomNumbers sa mga bagong forms.
        [NotMapped]
        public Room? Room
        {
            get { return Rooms.Count > 0 ? Rooms[0].Room : null; }
        }

        [NotMapped]
        public int RoomId
        {
            get { return Rooms.Count > 0 ? Rooms[0].RoomId : 0; }
        }

        // ---------- BILL ----------

        // Room Charges = (rate ng lahat ng room) x Nights
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

        // Additional charges: extra bed, sira, nawala, atbp.
        [NotMapped]
        public decimal AdditionalCharges
        {
            get
            {
                decimal total = 0;
                foreach (Charge c in Charges)
                {
                    total += c.Amount;
                }
                return total;
            }
        }

        // Total Bill = Room Charges + Early/Late Fee + Additional Charges
        [NotMapped]
        public decimal TotalBill
        {
            get { return RoomCharges + ExtraCharges + AdditionalCharges; }
        }

        // 50% ng room charges, kailangan para ma-Confirm
        [NotMapped]
        public decimal DownpaymentAmount
        {
            get { return Math.Round(RoomCharges * HotelPolicy.DownpaymentPercent / 100, 2); }
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

        // Kulang pa para sa downpayment (0 kung bayad na)
        [NotMapped]
        public decimal DownpaymentDue
        {
            get
            {
                decimal due = DownpaymentAmount - AmountPaid;
                return due > 0 ? due : 0;
            }
        }

        [NotMapped]
        public string PaymentStatus
        {
            get
            {
                if (AmountPaid <= 0) return "Unpaid";
                if (Balance <= 0) return "Paid";
                if (DownpaymentDue <= 0) return "Downpayment Paid";
                return "Partially Paid";
            }
        }

        // ---------- SECURITY DEPOSIT ----------

        // Bahagi ng deposit na ginamit pambayad (Payment na "Deposit" ang method)
        [NotMapped]
        public decimal DepositUsed
        {
            get
            {
                decimal total = 0;
                foreach (Payment p in Payments)
                {
                    if (p.PaymentMethod == "Deposit") total += p.Amount;
                }
                return total;
            }
        }

        // Ibabalik sa guest sa check-out
        [NotMapped]
        public decimal DepositRefund
        {
            get
            {
                decimal refund = SecurityDeposit - DepositUsed;
                return refund > 0 ? refund : 0;
            }
        }
    }

    // Isang room sa loob ng isang reservation
    public class ReservationRoom
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        // Rate ng room noong ginawa ang reservation
        [Column(TypeName = "decimal(10,2)")]
        public decimal RoomRate { get; set; }

        [NotMapped]
        public decimal Subtotal
        {
            get { return Reservation != null ? RoomRate * Reservation.Nights : 0; }
        }
    }

    // Additional charge: extra bed, guest assistance, sira, nawala, atbp.
    public class Charge
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

        public string Description { get; set; } = "";

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string AddedBy { get; set; } = "";
    }

    public class Payment
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = "";   // Cash, Card, GCash, Deposit
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