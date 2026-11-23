using Model;

namespace BusinessLogic.Repository
{
    public class GuestRepository
    {
        public List<Guest> GetGuests()
        {
            using (var db = new AppDBContext())
            {
                return db.Guests.Where(g => g.IsActive).OrderBy(g => g.Id).ToList();
            }
        }

        public Guest? GetGuestById(int id)
        {
            using (var db = new AppDBContext())
            {
                return db.Guests.FirstOrDefault(g => g.Id == id && g.IsActive);
            }
        }

        // Hanapin gamit ang pangalan o contact number.
        // Puwedeng buong pangalan: "Juan Santos" o "santos juan".
        // Bawat salita ay dapat tumugma sa first name, last name o contact number.
        public List<Guest> Search(string text)
        {
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            using (var db = new AppDBContext())
            {
                IQueryable<Guest> query = db.Guests.Where(g => g.IsActive);

                foreach (string word in words)
                {
                    string w = word;
                    query = query.Where(g => g.FirstName.Contains(w) ||
                                             g.LastName.Contains(w) ||
                                             g.ContactNumber.Contains(w));
                }

                return query.OrderBy(g => g.LastName).ThenBy(g => g.FirstName).ToList();
            }
        }

        public bool GuestExists(string firstName, string lastName, DateTime dateOfBirth, int excludeId)
        {
            using (var db = new AppDBContext())
            {
                return db.Guests.Any(g => g.IsActive
                                       && g.FirstName == firstName
                                       && g.LastName == lastName
                                       && g.DateOfBirth == dateOfBirth
                                       && g.Id != excludeId);
            }
        }

        public void AddGuest(Guest guest)
        {
            using (var db = new AppDBContext())
            {
                db.Guests.Add(guest);
                db.SaveChanges();
            }
        }

        public void UpdateGuest(Guest updated)
        {
            using (var db = new AppDBContext())
            {
                Guest? guest = db.Guests.Find(updated.Id);
                if (guest != null)
                {
                    guest.FirstName = updated.FirstName;
                    guest.LastName = updated.LastName;
                    guest.Gender = updated.Gender;
                    guest.DateOfBirth = updated.DateOfBirth;
                    guest.ContactNumber = updated.ContactNumber;
                    guest.Email = updated.Email;
                    guest.Address = updated.Address;
                    guest.EmergencyContactName = updated.EmergencyContactName;
                    guest.EmergencyContactNumber = updated.EmergencyContactNumber;
                    db.SaveChanges();
                }
            }
        }

        // "Delete" = hindi na active, para hindi masira ang lumang reservations
        public void DeactivateGuest(int id)
        {
            using (var db = new AppDBContext())
            {
                Guest? guest = db.Guests.Find(id);
                if (guest != null)
                {
                    guest.IsActive = false;
                    db.SaveChanges();
                }
            }
        }
    }
}