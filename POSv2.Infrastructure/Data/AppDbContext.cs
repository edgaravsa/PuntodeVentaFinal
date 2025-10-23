using Microsoft.EntityFrameworkCore;
using POSv2.Domain.Entities;

namespace POSv2.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
        public DbSet<Configuration> Configurations => Set<Configuration>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Admin user
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    EmployeeNumber = 1,
                    Name = "Admin",
                    Username = "Admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123"),
                    Role = EmployeeRole.Administrator
                }
            );
        }
    }
}