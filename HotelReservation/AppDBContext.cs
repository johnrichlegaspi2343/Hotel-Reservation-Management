using System;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }          // "Admin" o "FrontDesk"
    }

    public class AppDBContext : DbContext
    {

        private string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=HotelReservationDB;Trusted_Connection=True;TrustServerCertificate=True;";


        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique ang username. Walang account na nakalagay sa code, sa database lang ang mga user.
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        }
    }
}