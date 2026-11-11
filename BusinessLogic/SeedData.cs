using Model;

namespace BusinessLogic
{
    public class SeedData
    {
        // Gagawa ng database (kung wala pa) at maglalagay ng default na data
        public static void Seed(bool resetDatabase)
        {
            using (var db = new AppDBContext())
            {
                if (resetDatabase)
                {
                    db.Database.EnsureDeleted();
                }

                db.Database.EnsureCreated();

                // Kung luma ang database (Users table lang ang laman), burahin at gawin ulit
                try
                {
                    db.Rooms.Any();
                }
                catch
                {
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                }

                // ---------- 2 USERS ----------
                if (!db.Users.Any())
                {
                    db.Users.Add(new User { Username = "admin", Password = "admin123", Role = "Admin" });
                    db.Users.Add(new User { Username = "frontdesk", Password = "front123", Role = "FrontDesk" });
                    db.SaveChanges();
                }

                // ---------- 4 ROOM TYPES ----------
                if (!db.RoomTypes.Any())
                {
                    db.RoomTypes.Add(new RoomType { Name = "Standard", Rate = 1500 });
                    db.RoomTypes.Add(new RoomType { Name = "Deluxe", Rate = 2000 });
                    db.RoomTypes.Add(new RoomType { Name = "Family Room", Rate = 3000 });
                    db.RoomTypes.Add(new RoomType { Name = "Suite", Rate = 5000 });
                    db.SaveChanges();
                }

                // ---------- 16 ROOMS (4 kada floor) ----------
                // Floor 1 = Standard, 2 = Deluxe, 3 = Family Room, 4 = Suite
                if (!db.Rooms.Any())
                {
                    List<RoomType> types = db.RoomTypes.OrderBy(t => t.Id).ToList();

                    for (int floor = 1; floor <= 4; floor++)
                    {
                        for (int number = 1; number <= 4; number++)
                        {
                            Room room = new Room();
                            room.RoomNumber = floor + "0" + number;      // 101, 102 ... 404
                            room.RoomTypeId = types[floor - 1].Id;
                            room.Status = "Available";
                            db.Rooms.Add(room);
                        }
                    }
                    db.SaveChanges();
                }

                // ---------- 50 GUESTS (10 first names x 5 last names) ----------
                if (!db.Guests.Any())
                {
                    string[] firstNames = { "Juan", "Jose", "Mark", "Carlo", "Miguel",
                                            "Maria", "Ana", "Kristine", "Angelica", "Patricia" };
                    string[] lastNames = { "Santos", "Reyes", "Cruz", "Bautista", "Garcia" };

                    int count = 0;
                    foreach (string lastName in lastNames)
                    {
                        for (int i = 0; i < firstNames.Length; i++)
                        {
                            count++;

                            Guest guest = new Guest();
                            guest.FirstName = firstNames[i];
                            guest.LastName = lastName;
                            guest.Gender = (i < 5) ? "Male" : "Female";
                            guest.DateOfBirth = new DateTime(1980 + (count % 20), (count % 12) + 1, (count % 28) + 1);
                            guest.ContactNumber = "0917" + count.ToString("0000000");
                            guest.Email = firstNames[i].ToLower() + "." + lastName.ToLower() + "@email.com";
                            guest.Address = count + " Rizal St., Manila";
                            guest.EmergencyContactName = "Parent of " + firstNames[i];
                            guest.EmergencyContactNumber = "0918" + count.ToString("0000000");

                            db.Guests.Add(guest);
                            db.SaveChanges();   // isa-isa para sunod-sunod ang GST-001 ... GST-050
                        }
                    }
                }
            }
        }
    }
}