namespace Model
{
    // Lahat ng rules ng hotel, nasa isang lugar para madaling palitan
    public class HotelPolicy
    {
        // ---------- Oras ng check-in at check-out ----------
        public const int CheckInHour = 14;              // 2:00 PM
        public const int CheckOutHour = 12;             // 12:00 NN
        public const decimal FeePerHour = 200;          // P200 kada oras na maaga o lampas

        public const string CheckInTimeText = "2:00 PM";
        public const string CheckOutTimeText = "12:00 NN";

        // ---------- Reservation ----------
        public const int MaxNights = 30;                // pinakamahabang stay
        public const int MaxDaysAhead = 365;            // hanggang 1 taon lang puwedeng mag-book

        // ---------- Guest ----------
        public const int MinGuestAge = 18;
        public const int MaxGuestAge = 100;

        // ---------- Login ----------
        public const int MaxLoginAttempts = 3;          // ilang maling login bago ma-lock
        public const int LoginLockSeconds = 30;         // ilang segundo naka-lock
    }
}