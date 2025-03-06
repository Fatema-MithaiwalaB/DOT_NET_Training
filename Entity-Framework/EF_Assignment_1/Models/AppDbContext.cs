using EF_Assignment_1.Data;
using Microsoft.EntityFrameworkCore;

namespace EF_Assignment_1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        // No DI Constructor (Only using OnConfiguring)
        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)  // Prevents conflicts if DI is added later
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-C2250N0\\SQLEXPRESS;Database=EFCoreDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
