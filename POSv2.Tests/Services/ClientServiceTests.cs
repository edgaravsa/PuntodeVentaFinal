using Xunit;
using FluentAssertions;
using POSv2.Infrastructure.Data;
using POSv2.Infrastructure.Services;
using POSv2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace POSv2.Tests.Services
{
    public class ClientServiceTests
    {
        private ClientService GetService()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("ClientTestDb")
                .Options;
            var context = new AppDbContext(options);

            var client = new Client
            {
                Id = System.Guid.NewGuid(),
                ClientNumber = 10,
                Name = "Juan",
                LastName = "Pérez",
                Phone = "5551234567",
                Email = "juan@correo.com"
            };
            context.Clients.Add(client);
            context.SaveChanges();
            return new ClientService(context);
        }

        [Fact]
        public async Task FindClientAsync_ShouldFindByEmail()
        {
            var service = GetService();
            var client = await service.FindClientAsync("juan@correo.com");
            client.Should().NotBeNull();
            client!.Name.Should().Be("Juan");
        }

        [Fact]
        public async Task FindClientAsync_ShouldReturnNull_WhenNotFound()
        {
            var service = GetService();
            var client = await service.FindClientAsync("noexiste@correo.com");
            client.Should().BeNull();
        }
    }
}