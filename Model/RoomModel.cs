using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";      // Standard, Deluxe, Family Room, Suite

        [Column(TypeName = "decimal(10,2)")]
        public decimal Rate { get; set; }           // presyo kada gabi

        public override string ToString()
        {
            return Name;
        }
    }

    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = "";
        public int RoomTypeId { get; set; }
        public RoomType? RoomType { get; set; }

        // Available, Reserved, Occupied, Maintenance
        public string Status { get; set; } = "Available";
        public bool IsActive { get; set; } = true;

        [NotMapped]
        public string RoomTypeName
        {
            get { return RoomType != null ? RoomType.Name : ""; }
        }

        [NotMapped]
        public decimal Rate
        {
            get { return RoomType != null ? RoomType.Rate : 0; }
        }
    }
}