using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using POSv2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace POSv2.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;

        public OrderService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task SaveOrderAsync(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }
    }
}