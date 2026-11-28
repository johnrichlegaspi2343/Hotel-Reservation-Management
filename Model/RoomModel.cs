using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";      // Single, Standard, Twin, Deluxe, Family, Suite

        [Column(TypeName = "decimal(10,2)")]
        public decimal Rate { get; set; }           // presyo kada gabi

        public int Beds { get; set; } = 1;          // ilang kama (1 hanggang 3)
        public string BedSize { get; set; } = "";   // description ng kama, hal. "2 Double Beds"
        public int MaxGuests { get; set; } = 1;     // ilang guest ang kasya (1 hanggang 8)

        // Mga amenities, hiwalay sa comma. Hal. "Aircon, TV, WiFi, 1 CR"
        public string Amenities { get; set; } = "";

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

        // Status NGAYONG ARAW: Available, Reserved, Occupied, Maintenance
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

        [NotMapped]
        public string BedSize
        {
            get { return RoomType != null ? RoomType.BedSize : ""; }
        }

        [NotMapped]
        public int Beds
        {
            get { return RoomType != null ? RoomType.Beds : 0; }
        }

        [NotMapped]
        public int MaxGuests
        {
            get { return RoomType != null ? RoomType.MaxGuests : 0; }
        }

        [NotMapped]
        public string Amenities
        {
            get { return RoomType != null ? RoomType.Amenities : ""; }
        }
    }
}