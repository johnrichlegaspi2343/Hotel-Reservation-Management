using Microsoft.EntityFrameworkCore;
using Model;

namespace BusinessLogic
{
    public class AppDBContext : DbContext
    {
        // Default: LocalDB. Kung ibang server ang gamit mo, mag-set ng environment variable HOTEL_DB_CONNECTION.
        private string ConnectionString =
            Environment.GetEnvironmentVariable("HOTEL_DB_CONNECTION")
            ?? @"Server=(localdb)\MSSQLLocalDB;Database=HotelReservationDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bawal ang dalawang user na pareho ang username
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            // Bawal ang dalawang room na pareho ang room number
            modelBuilder.Entity<Room>().HasIndex(r => r.RoomNumber).IsUnique();
        }
    }
}