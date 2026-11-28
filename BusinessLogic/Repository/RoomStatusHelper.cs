using BusinessLogic.Repository;
using Model;

namespace BusinessLogic
{
    // Inaayos ang status ng room PARA SA ARAW NA ITO:
    //   may naka-check-in                           -> Occupied
    //   may Confirmed na reservation na sakop ngayon -> Reserved
    //   wala                                        -> Available
    // Hindi ginagalaw kapag Maintenance.
    // Kaya kahit naka-book na para sa susunod na linggo, Available pa rin ang room ngayon.
    public static class RoomStatusHelper
    {
        public static void Refresh(int roomId)
        {
            RoomRepository roomRepo = new RoomRepository();
            ReservationRepository reservationRepo = new ReservationRepository();

            Room? room = roomRepo.GetRoomById(roomId);
            if (room == null || room.Status == "Maintenance")
                return;

            string newStatus = "Available";
            if (reservationRepo.RoomHasCheckedInGuest(roomId, 0))
                newStatus = "Occupied";
            else if (reservationRepo.RoomIsReservedToday(roomId, DateTime.Today))
                newStatus = "Reserved";

            // I-save lang kung nagbago
            if (room.Status != newStatus)
                roomRepo.UpdateRoomStatus(roomId, newStatus);
        }

        // Huling araw na na-refresh ang lahat ng rooms
        private static DateTime lastRefreshAll = DateTime.MinValue;

        // Lahat ng rooms. Isang beses lang kada araw (pagpalit ng araw),
        // kasi ang ibang pagbabago ay inaayos na agad ng Refresh(roomId).
        public static void RefreshAll()
        {
            if (lastRefreshAll == DateTime.Today)
                return;

            RoomRepository roomRepo = new RoomRepository();
            foreach (Room room in roomRepo.GetRooms())
            {
                Refresh(room.Id);
            }

            lastRefreshAll = DateTime.Today;
        }

        // Lahat ng rooms ng isang reservation
        public static void RefreshRooms(Reservation reservation)
        {
            foreach (ReservationRoom rr in reservation.Rooms)
            {
                Refresh(rr.RoomId);
            }
        }
    }
}