using EF_Assignment_4_CRUD.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace EF_Assignment_4_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>
                (
                    entity =>
                    {
                        entity.HasKey(e => e.EmployeeId);

                        entity.Property(e => e.EmployeeId)
                        .HasColumnName("EmpID")
                        .ValueGeneratedOnAdd();

                        entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(50);

                        entity.Property(e => e.Email)
                        .IsRequired()
                        .HasMaxLength(150);

                        entity.Property(e => e.Phone)
                        .HasMaxLength(12);

                        entity.HasIndex(e => e.Email)
                        .IsUnique();

                        entity.Property(e => e.Salary)
                        .HasColumnType("decimal(10,2)")
                        .HasDefaultValue(30000.00m);

                    }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
