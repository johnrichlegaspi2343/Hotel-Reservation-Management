using Microsoft.EntityFrameworkCore;
using Model;

namespace BusinessLogic.Repository
{
    public class RoomRepository
    {
        // ===================== ROOM TYPES =====================

        public List<RoomType> GetRoomTypes()
        {
            using (var db = new AppDBContext())
            {
                return db.RoomTypes.OrderBy(t => t.Rate).ToList();
            }
        }

        public RoomType? GetRoomTypeById(int id)
        {
            using (var db = new AppDBContext())
            {
                return db.RoomTypes.Find(id);
            }
        }

        public void AddRoomType(RoomType type)
        {
            using (var db = new AppDBContext())
            {
                db.RoomTypes.Add(type);
                db.SaveChanges();
            }
        }

        public void UpdateRoomType(int id, string name, decimal rate)
        {
            using (var db = new AppDBContext())
            {
                RoomType? type = db.RoomTypes.Find(id);
                if (type != null)
                {
                    type.Name = name;
                    type.Rate = rate;
                    db.SaveChanges();
                }
            }
        }

        public bool RoomTypeNameExists(string name, int excludeId)
        {
            using (var db = new AppDBContext())
            {
                return db.RoomTypes.Any(t => t.Name == name && t.Id != excludeId);
            }
        }

        // ===================== ROOMS =====================

        public List<Room> GetRooms()
        {
            using (var db = new AppDBContext())
            {
                return db.Rooms
                    .Include("RoomType")
                    .Where(r => r.IsActive)
                    .OrderBy(r => r.RoomNumber)
                    .ToList();
            }
        }

        public Room? GetRoomById(int id)
        {
            using (var db = new AppDBContext())
            {
                return db.Rooms.Include("RoomType").FirstOrDefault(r => r.Id == id);
            }
        }

        public bool RoomNumberExists(string roomNumber, int excludeId)
        {
            using (var db = new AppDBContext())
            {
                return db.Rooms.Any(r => r.RoomNumber == roomNumber && r.Id != excludeId);
            }
        }

        public void AddRoom(Room room)
        {
            using (var db = new AppDBContext())
            {
                db.Rooms.Add(room);
                db.SaveChanges();
            }
        }

        public void UpdateRoom(int id, string roomNumber, int roomTypeId)
        {
            using (var db = new AppDBContext())
            {
                Room? room = db.Rooms.Find(id);
                if (room != null)
                {
                    room.RoomNumber = roomNumber;
                    room.RoomTypeId = roomTypeId;
                    db.SaveChanges();
                }
            }
        }

        public void UpdateRoomStatus(int id, string status)
        {
            using (var db = new AppDBContext())
            {
                Room? room = db.Rooms.Find(id);
                if (room != null)
                {
                    room.Status = status;
                    db.SaveChanges();
                }
            }
        }

        // "Delete" = hindi na active, para hindi masira ang lumang reservations
        public void DeactivateRoom(int id)
        {
            using (var db = new AppDBContext())
            {
                Room? room = db.Rooms.Find(id);
                if (room != null)
                {
                    room.IsActive = false;
                    db.SaveChanges();
                }
            }
        }

        // Mga room na walang reservation sa napiling petsa. roomTypeId = 0 kung lahat ng type.
        public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int roomTypeId)
        {
            List<Room> available = new List<Room>();
            ReservationRepository reservationRepo = new ReservationRepository();

            foreach (Room room in GetRooms())
            {
                if (room.Status == "Maintenance") continue;
                if (roomTypeId != 0 && room.RoomTypeId != roomTypeId) continue;

                if (!reservationRepo.IsRoomBooked(room.Id, checkIn, checkOut))
                {
                    available.Add(room);
                }
            }
            return available;
        }
    }
}