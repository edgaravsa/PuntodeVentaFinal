using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using POSv2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace POSv2.Infrastructure.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext context;

        public InventoryService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<InventoryItem>> GetAllInventoryItemsAsync()
        {
            return await context.InventoryItems.ToListAsync();
        }

        public async Task AddInventoryItemAsync(InventoryItem item)
        {
            context.InventoryItems.Add(item);
            await context.SaveChangesAsync();
        }
    }
}