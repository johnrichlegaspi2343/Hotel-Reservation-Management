using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public string EmergencyContactName { get; set; } = "";
        public string EmergencyContactNumber { get; set; } = "";
        public bool IsActive { get; set; } = true;

        // Guest ID na ipinapakita sa screen, hal. GST-001 (galing sa Id)
        [NotMapped]
        public string GuestCode
        {
            get { return "GST-" + Id.ToString("000"); }
        }

        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}