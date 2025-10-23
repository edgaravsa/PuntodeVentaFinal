using Xunit;
using FluentAssertions;
using POSv2.Infrastructure.Data;
using POSv2.Infrastructure.Services;
using POSv2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace POSv2.Tests.Services
{
    public class OrderServiceTests
    {
        private OrderService GetService()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("OrderTestDb")
                .Options;
            var context = new AppDbContext(options);
            return new OrderService(context);
        }

        [Fact]
        public async Task SaveOrderAsync_ShouldAddOrder()
        {
            var service = GetService();
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Subtotal = 100,
                Tax = 16,
                Total = 116,
                Discount = 0,
                CashierId = Guid.NewGuid(),
                Branch = "SucursalTest",
                PaymentType = PaymentType.Cash
            };
            await service.SaveOrderAsync(order);

            var context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("OrderTestDb").Options);

            var orders = await context.Orders.ToListAsync();
            orders.Should().ContainSingle(o => o.Total == 116);
        }
    }
}