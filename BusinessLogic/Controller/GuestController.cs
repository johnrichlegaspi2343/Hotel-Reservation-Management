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

        // Hanapin gamit ang Guest ID (GST-001), pangalan, o contact number
        public List<Guest> SearchGuest(string text)
        {
            text = text.Trim();
            if (text == "")
                throw new Exception("Please enter a Guest ID, name or contact number.");

            List<Guest> result = new List<Guest>();

            if (text.ToUpper().StartsWith("GST-"))
            {
                Guest? guest = guestRepo.GetGuestById(CodeHelper.ToId(text, "GST-"));
                if (guest != null) result.Add(guest);
            }
            else
            {
                result = guestRepo.Search(text);
            }

            if (result.Count == 0)
                throw new Exception("Guest not found.");

            return result;
        }

        public void AddGuest(Guest guest)
        {
            guest.DateOfBirth = guest.DateOfBirth.Date;     // petsa lang, walang oras
            ValidateGuest(guest);
            guestRepo.AddGuest(guest);      // pagkatapos nito, may Id at GuestCode na
        }

        public void UpdateGuest(Guest guest)
        {
            guest.DateOfBirth = guest.DateOfBirth.Date;     // petsa lang, walang oras
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
            if (guest.FirstName.Trim() == "")
                throw new Exception("First name is required.");

            if (guest.LastName.Trim() == "")
                throw new Exception("Last name is required.");

            if (guest.DateOfBirth.Date > DateTime.Today.AddYears(-18))
                throw new Exception("Guest must be at least 18 years old.");

            if (!IsValidContactNumber(guest.ContactNumber))
                throw new Exception("Contact number must be 11 digits and start with 09.");

            if (guest.Email.Trim() != "" && (!guest.Email.Contains("@") || !guest.Email.Contains(".")))
                throw new Exception("Please enter a valid email address.");

            if (guest.Address.Trim() == "")
                throw new Exception("Address is required.");

            if (guest.EmergencyContactNumber.Trim() != "" && !IsValidContactNumber(guest.EmergencyContactNumber))
                throw new Exception("Emergency contact number must be 11 digits and start with 09.");

            if (guestRepo.GuestExists(guest.FirstName.Trim(), guest.LastName.Trim(), guest.DateOfBirth.Date, guest.Id))
                throw new Exception("This guest already exists.");
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