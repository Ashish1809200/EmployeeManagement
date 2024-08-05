using EmployeeManagement.Models.Employee;
using EmployeeManagement.Models.EmployeeProduction;
using EmployeeManagement.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<EmployeeProduction> Production { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeProduction>()
                .HasOne(ep => ep.Employee)
                .WithMany()
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProduction>()
                .HasOne(ep => ep.Product)
                .WithMany()
                .HasForeignKey(ep => ep.ProductId);
        }
    }
}
