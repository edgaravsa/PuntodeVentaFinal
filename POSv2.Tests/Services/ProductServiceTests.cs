using Xunit;
using FluentAssertions;
using POSv2.Infrastructure.Data;
using POSv2.Infrastructure.Repositories;
using POSv2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace POSv2.Tests.Services
{
    public class ProductServiceTests
    {
        private ProductRepository GetRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("ProductTestDb")
                .Options;
            var context = new AppDbContext(options);
            return new ProductRepository(context);
        }

        [Fact]
        public async Task AddProduct_ShouldAddProductToDatabase()
        {
            var repo = GetRepository();
            var product = new Product
            {
                Id = System.Guid.NewGuid(),
                SKU = "SKU001",
                Name = "Test Product",
                Size = ProductSize.Medium,
                Description = "Desc",
                Category = "Cat",
                Unit = "Piece",
                Quantity = 10,
                PriceWithTax = 100
            };

            await repo.AddProductAsync(product);
            var products = await repo.GetAllProductsAsync();
            products.Should().ContainSingle(p => p.Name == "Test Product");
        }

        [Fact]
        public async Task DeleteProduct_ShouldRemoveProduct()
        {
            var repo = GetRepository();
            var product = new Product { Id = System.Guid.NewGuid(), Name = "DeleteMe" };
            await repo.AddProductAsync(product);

            await repo.DeleteProductAsync(product.Id);
            var products = await repo.GetAllProductsAsync();
            products.Should().NotContain(p => p.Name == "DeleteMe");
        }
    }
}