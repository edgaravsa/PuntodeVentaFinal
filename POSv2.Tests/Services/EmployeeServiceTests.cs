using Xunit;
using FluentAssertions;
using POSv2.Infrastructure.Data;
using POSv2.Infrastructure.Services;
using POSv2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace POSv2.Tests.Services
{
    public class EmployeeServiceTests
    {
        private EmployeeService GetService()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("EmployeeTestDb")
                .Options;
            var context = new AppDbContext(options);

            var employee = new Employee
            {
                Id = System.Guid.NewGuid(),
                Name = "TestUser",
                Username = "TestUser",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("SecretPass"),
                Role = EmployeeRole.Cashier,
                EmployeeNumber = 2
            };
            context.Employees.Add(employee);
            context.SaveChanges();
            return new EmployeeService(context);
        }

        [Fact]
        public async Task AuthenticateAsync_ShouldReturnEmployee_WhenCredentialsAreCorrect()
        {
            var service = GetService();
            var result = await service.AuthenticateAsync("TestUser", "SecretPass", EmployeeRole.Cashier);
            result.Should().NotBeNull();
            result!.Username.Should().Be("TestUser");
        }

        [Fact]
        public async Task AuthenticateAsync_ShouldReturnNull_WhenCredentialsAreWrong()
        {
            var service = GetService();
            var result = await service.AuthenticateAsync("TestUser", "WrongPass", EmployeeRole.Cashier);
            result.Should().BeNull();
        }
    }
}