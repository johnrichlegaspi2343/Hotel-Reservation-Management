using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    public class GuestController
    {
        private GuestRepository guestRepo = new GuestRepository();
        private ReservationRepository reservationRepo = new ReservationRepository();

        public List<Guest> GetGuests()
        {
            return guestRepo.GetGuests();
        }

        // Hanapin gamit ang:
        //   Guest ID  -> "GST-001", "gst1", "gst 1" o "1"
        //   Pangalan  -> "Juan", "Santos", "Juan Santos", "santos juan"
        //   Contact   -> "0917", "09170000001"
        //   ID number -> "ID-100001"
        public List<Guest> SearchGuest(string text)
        {
            text = text.Trim();
            if (text == "")
                throw new Exception("Please enter a Guest ID, name or contact number.");

            List<Guest> result = new List<Guest>();

            if (CodeHelper.StartsWithPrefix(text, "GST"))
            {
                // Guest ID lang
                Guest? guest = guestRepo.GetGuestById(CodeHelper.ToId(text, "GST-"));
                if (guest != null) result.Add(guest);
            }
            else
            {
                // Maikling numero (hal. "1" o "12") = puwedeng Guest ID
                if (CodeHelper.IsDigits(text) && text.Length <= 4)
                {
                    Guest? guest = guestRepo.GetGuestById(CodeHelper.ToId(text, "GST-"));
                    if (guest != null) result.Add(guest);
                }

                // Pangalan, contact number o ID number
                foreach (Guest g in guestRepo.Search(text))
                {
                    if (!ContainsGuest(result, g.Id))
                        result.Add(g);
                }
            }

            if (result.Count == 0)
                throw new Exception("No guest found for \"" + text + "\".");

            return result;
        }

        // TRUE kung nasa listahan na ang guest (para walang doble)
        private bool ContainsGuest(List<Guest> list, int id)
        {
            foreach (Guest g in list)
            {
                if (g.Id == id) return true;
            }
            return false;
        }

        public void AddGuest(Guest guest)
        {
            guest.DateOfBirth = guest.DateOfBirth.Date;     // petsa lang, walang oras
            guest.IdNumber = guest.IdNumber.Trim().ToUpper();
            ValidateGuest(guest);
            guestRepo.AddGuest(guest);      // pagkatapos nito, may Id at GuestCode na
        }

        public void UpdateGuest(Guest guest)
        {
            guest.DateOfBirth = guest.DateOfBirth.Date;     // petsa lang, walang oras
            guest.IdNumber = guest.IdNumber.Trim().ToUpper();
            ValidateGuest(guest);
            guestRepo.UpdateGuest(guest);
        }

        public void DeleteGuest(int id)
        {
            if (reservationRepo.GuestHasActiveReservation(id))
                throw new Exception("Cannot delete: this guest has a pending, confirmed or checked-in reservation.");

            guestRepo.DeactivateGuest(id);
        }

        private void ValidateGuest(Guest guest)
        {
            // ---------- Lahat ng field ay required ----------
            if (guest.FirstName.Trim() == "")
                throw new Exception("First name is required.");

            if (guest.LastName.Trim() == "")
                throw new Exception("Last name is required.");

            if (guest.Address.Trim() == "")
                throw new Exception("Address is required.");

            if (guest.Gender.Trim() == "")
                throw new Exception("Please select a gender.");

            if (guest.ContactNumber.Trim() == "")
                throw new Exception("Contact number is required.");

            if (guest.EmergencyContactName.Trim() == "")
                throw new Exception("Emergency contact name is required.");

            if (guest.EmergencyContactNumber.Trim() == "")
                throw new Exception("Emergency contact number is required.");

            // ---------- Tamang format ----------
            if (!IsValidName(guest.FirstName))
                throw new Exception("First name must contain letters only.");

            if (!IsValidName(guest.LastName))
                throw new Exception("Last name must contain letters only.");

            if (!IsValidName(guest.EmergencyContactName))
                throw new Exception("Emergency contact name must contain letters only.");

            if (guest.DateOfBirth.Date > DateTime.Today.AddYears(-HotelPolicy.MinGuestAge))
                throw new Exception("Guest must be at least " + HotelPolicy.MinGuestAge + " years old.");

            if (guest.DateOfBirth.Date < DateTime.Today.AddYears(-HotelPolicy.MaxGuestAge))
                throw new Exception("Please check the date of birth. Maximum age is " + HotelPolicy.MaxGuestAge + ".");

            if (!IsValidContactNumber(guest.ContactNumber))
                throw new Exception("Contact number must be 11 digits and start with 09.");

            if (!IsValidContactNumber(guest.EmergencyContactNumber))
                throw new Exception("Emergency contact number must be 11 digits and start with 09.");

            if (guest.ContactNumber.Trim() == guest.EmergencyContactNumber.Trim())
                throw new Exception("Emergency contact number must be different from the guest's contact number.");

            if (guest.Email.Trim() != "" && (!guest.Email.Contains("@") || !guest.Email.Contains(".")))
                throw new Exception("Please enter a valid email address.");

            // ---------- Valid ID ----------
            if (guest.IdType.Trim() == "")
                throw new Exception("Please select a Valid ID type.");

            if (!IsValidIdType(guest.IdType))
                throw new Exception("Please select a Valid ID type from the list.");

            if (guest.IdNumber.Trim() == "")
                throw new Exception("ID number is required.");

            if (!IsValidIdNumber(guest.IdNumber))
                throw new Exception("ID number must be 4 to 20 characters (letters, numbers and dash only).");

            // ---------- Walang duplicate ----------
            // Parehong ID = parehong tao
            if (guestRepo.IdNumberExists(guest.IdType.Trim(), guest.IdNumber.Trim(), guest.Id))
                throw new Exception("Another guest is already registered with this " + guest.IdType + " number.");
        }

        // Guest na pareho ang pangalan at birthday (null kung wala).
        // Ginagamit ng form para magbabala: "May kaparehong guest na, ituloy?"
        public Guest? FindSameGuest(string firstName, string lastName, DateTime dateOfBirth, int excludeId)
        {
            return guestRepo.FindSameGuest(firstName.Trim(), lastName.Trim(), dateOfBirth.Date, excludeId);
        }

        // TRUE kung nasa listahan ng tinatanggap na ID
        private bool IsValidIdType(string idType)
        {
            foreach (string type in HotelPolicy.IdTypes)
            {
                if (type == idType.Trim()) return true;
            }
            return false;
        }

        // Letra, numero at gitling (-) lang, 4 hanggang 20 characters
        private bool IsValidIdNumber(string idNumber)
        {
            idNumber = idNumber.Trim();
            if (idNumber.Length < 4 || idNumber.Length > 20)
                return false;

            foreach (char c in idNumber)
            {
                if (!char.IsLetterOrDigit(c) && c != '-')
                    return false;
            }
            return true;
        }

        // Letra, space, gitling (-), tuldok (.) at apostrophe (') lang. Puwede ang Ñ.
        private bool IsValidName(string name)
        {
            name = name.Trim();
            if (name.Length < 2)
                return false;

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '-' && c != '.' && c != '\'')
                    return false;
            }
            return true;
        }

        private bool IsValidContactNumber(string number)
        {
            number = number.Trim();

            if (number.Length != 11 || !number.StartsWith("09"))
                return false;

            foreach (char c in number)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }
    }
}