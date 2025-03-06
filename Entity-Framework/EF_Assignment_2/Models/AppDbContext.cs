using EF_Assignment_2.Data;
using Microsoft.EntityFrameworkCore;

namespace EF_Assignment_2.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) 
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
