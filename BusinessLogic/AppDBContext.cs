using Microsoft.EntityFrameworkCore;
using Model;
using System.Reflection.Emit;

namespace BusinessLogic
{
    public class AppDBContext : DbContext
    {
        // Default: LocalDB. Kung ibang server ang gamit mo, mag-set ng environment variable HOTEL_DB_CONNECTION.
        private string ConnectionString =
            Environment.GetEnvironmentVariable("HOTEL_DB_CONNECTION")
            ?? @"Server=(localdb)\MSSQLLocalDB;Database=HotelReservationDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        }
    }
}