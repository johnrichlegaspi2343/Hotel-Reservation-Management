namespace Model
{
    // Lahat ng rules ng hotel, nasa isang lugar para madaling palitan
    public class HotelPolicy
    {
        // ---------- Oras ng check-in at check-out ----------
        public const int CheckInHour = 14;              // 2:00 PM
        public const int CheckOutHour = 12;             // 12:00 NN
        public const decimal FeePerHour = 200;          // P200 kada oras na maaga o lampas (bawat room)
        public const int LateCheckOutLimitHour = 18;    // lampas 6:00 PM = singil ng 1 buong gabi

        public const string CheckInTimeText = "2:00 PM";
        public const string CheckOutTimeText = "12:00 NN";

        // ---------- Rooms ----------
        public const int MaxBedsPerRoom = 3;            // pinakamaraming kama sa isang room
        public const int MaxGuestsPerRoom = 8;          // pinakamaraming guest sa isang room

        // ---------- Reservation ----------
        public const int MaxNights = 30;                // pinakamahabang stay
        public const int MaxDaysAhead = 365;            // hanggang 1 taon lang puwedeng mag-book
        public const int MaxRoomsPerReservation = 5;    // hanggang 5 rooms sa isang reservation

        // ---------- Bayad ----------
        public const decimal DownpaymentPercent = 50;       // 50% ng room charges para ma-Confirm
        public const decimal SecurityDepositPerRoom = 1000; // kinukuha sa check-in, ibinabalik sa check-out
        public const int FreeCancelDays = 1;                // libre ang cancel hanggang 1 araw bago ang check-in

        // ---------- Guest ----------
        public const int MinGuestAge = 18;
        public const int MaxGuestAge = 100;

        // Mga tinatanggap na Valid ID
        public static readonly string[] IdTypes =
        {
            "National ID", "Driver's License", "Passport", "UMID", "SSS ID",
            "PhilHealth ID", "Postal ID", "Voter's ID", "PRC ID"
        };

        // Mga amenities na puwedeng piliin sa Room Maintenance
        public static readonly string[] AmenityList =
        {
            "Aircon", "TV", "WiFi", "Hot & Cold Shower", "Bathtub",
            "Mini Fridge", "Balcony", "Work Desk", "Sofa Bed", "Living Area"
        };

        // ---------- Additional Charges ----------
        public static readonly string[] ChargeTypes =
        {
            "Extra Bed", "Guest Assistance", "Room Damage", "Lost Item",
            "Room Service", "Laundry", "Others"
        };

        // Default na presyo ng charge (0 = ilalagay ng staff ang halaga)
        public static decimal GetDefaultChargePrice(string chargeType)
        {
            if (chargeType == "Extra Bed") return 500;
            if (chargeType == "Guest Assistance") return 300;
            return 0;
        }

        // ---------- Login ----------
        public const int MaxLoginAttempts = 3;          // ilang maling login bago ma-lock
        public const int LoginLockSeconds = 30;         // ilang segundo naka-lock
    }
}