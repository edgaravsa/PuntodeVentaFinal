using Xunit;
using FluentAssertions;
using POSv2.UI.ViewModels.Products;
using POSv2.Domain.Entities;
using Moq;
using System.Threading.Tasks;

namespace POSv2.Tests.ViewModels
{
    public class ProductViewModelTests
    {
        [Fact]
        public async Task AddProductCommand_ShouldAddProduct()
        {
            var productService = new Mock<IProductService>();
            var employeeService = new Mock<IEmployeeService>();
            productService.Setup(x => x.AddProductAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            var vm = new ProductViewModel(productService.Object, employeeService.Object)
            {
                Sku = "SKU001",
                Name = "Nuevo Producto",
                Size = ProductSize.Large,
                Description = "Desc",
                Category = "Cat",
                Unit = "Piece",
                Quantity = 5,
                PriceWithTax = 80,
                ImagePath = "/images/test.png"
            };

            vm.AddProductCommand.Execute(null);
            vm.Products.Should().Contain(p => p.Name == "Nuevo Producto");
        }
    }
}