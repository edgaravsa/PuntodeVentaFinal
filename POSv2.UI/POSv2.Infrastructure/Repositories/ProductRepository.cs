using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using POSv2.Infrastructure.Data;

namespace POSv2.Infrastructure.Repositories
{
    public class ProductRepository : IProductService
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await context.Products.FindAsync(id);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
        }
    }
}