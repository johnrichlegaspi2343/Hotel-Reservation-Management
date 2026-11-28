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
                    // Babasahin ang bawat table. Kapag kulang ang columns, mag-e-error,
                    // kaya buburahin at gagawin ulit ang database.
                    db.RoomTypes.FirstOrDefault();
                    db.Rooms.FirstOrDefault();
                    db.Guests.FirstOrDefault();
                    db.Reservations.FirstOrDefault();
                    db.ReservationRooms.FirstOrDefault();
                    db.Payments.FirstOrDefault();
                    db.Charges.FirstOrDefault();
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

                // ---------- 6 ROOM TYPES ----------
                if (!db.RoomTypes.Any())
                {
                    // Malayang pipili ang guest. Max 3 beds at max 8 guests bawat room.
                    db.RoomTypes.Add(new RoomType
                    {
                        Name = "Single",
                        Rate = 1000,
                        Beds = 1,
                        BedSize = "1 Single Bed",
                        MaxGuests = 1,
                        Amenities = "Aircon, TV, WiFi, Hot & Cold Shower, 1 CR"
                    });
                    db.RoomTypes.Add(new RoomType
                    {
                        Name = "Standard",
                        Rate = 1500,
                        Beds = 1,
                        BedSize = "1 Double Bed",
                        MaxGuests = 2,
                        Amenities = "Aircon, TV, WiFi, Hot & Cold Shower, 1 CR"
                    });
                    db.RoomTypes.Add(new RoomType
                    {
                        Name = "Twin",
                        Rate = 1800,
                        Beds = 2,
                        BedSize = "2 Single Beds",
                        MaxGuests = 2,
                        Amenities = "Aircon, TV, WiFi, Hot & Cold Shower, 1 CR"
                    });
                    db.RoomTypes.Add(new RoomType
                    {
                        Name = "Deluxe",
                        Rate = 2800,
                        Beds = 2,
                        BedSize = "2 Double Beds",
                        MaxGuests = 4,
                        Amenities = "Aircon, TV, WiFi, Hot & Cold Shower, Mini Fridge, Work Desk, 1 CR"
                    });
                    db.RoomTypes.Add(new RoomType
                    {
                        Name = "Family",
                        Rate = 3500,
                        Beds = 3,
                        BedSize = "2 Queen Beds + 1 Double Bed",
                        MaxGuests = 6,
                        Amenities = "Aircon, TV, WiFi, Hot & Cold Shower, Mini Fridge, 2 CR"
                    });
                    db.RoomTypes.Add(new RoomType
                    {
                        Name = "Suite",
                        Rate = 5000,
                        Beds = 3,
                        BedSize = "2 King Beds + 1 Queen Bed",
                        MaxGuests = 8,
                        Amenities = "Aircon, TV, WiFi, Hot & Cold Shower, Bathtub, Mini Fridge, Sofa Bed, Living Area, Balcony, 2 CR"
                    });
                    db.SaveChanges();
                }

                // ---------- 50 ROOMS (5 floors x 10 rooms) ----------
                // Floor 1 = Single, Floor 2 = Standard (201-205) at Twin (206-210),
                // Floor 3 = Deluxe, Floor 4 = Family, Floor 5 = Suite
                if (!db.Rooms.Any())
                {
                    for (int floor = 1; floor <= 5; floor++)
                    {
                        for (int number = 1; number <= 10; number++)
                        {
                            string typeName = "Single";
                            if (floor == 2 && number <= 5) typeName = "Standard";
                            if (floor == 2 && number > 5) typeName = "Twin";
                            if (floor == 3) typeName = "Deluxe";
                            if (floor == 4) typeName = "Family";
                            if (floor == 5) typeName = "Suite";

                            RoomType type = db.RoomTypes.First(t => t.Name == typeName);

                            Room room = new Room();
                            room.RoomNumber = (floor * 100 + number).ToString();   // 101 ... 110, 201 ... 510
                            room.RoomTypeId = type.Id;
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

                            // Valid ID: paikot-ikot ang uri ng ID, iba-iba ang number
                            guest.IdType = HotelPolicy.IdTypes[count % HotelPolicy.IdTypes.Length];
                            guest.IdNumber = "ID-" + (100000 + count).ToString();

                            db.Guests.Add(guest);
                            db.SaveChanges();   // isa-isa para sunod-sunod ang GST-001 ... GST-050
                        }
                    }
                }
            }
        }
    }
}