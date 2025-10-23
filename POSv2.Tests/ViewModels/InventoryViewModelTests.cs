using Xunit;
using FluentAssertions;
using POSv2.UI.ViewModels.Inventory;
using POSv2.Domain.Entities;
using Moq;
using POSv2.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POSv2.Tests.ViewModels
{
    public class InventoryViewModelTests
    {
        private InventoryViewModel GetViewModel(List<Product>? products = null)
        {
            var inventoryService = new Mock<IInventoryService>();
            var productService = new Mock<IProductService>();

            products ??= new List<Product>
            {
                new Product { Id = System.Guid.NewGuid(), Name = "P1", SKU = "A1", Quantity = 10 }
            };
            productService.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(products);
            inventoryService.Setup(x => x.AdjustStockAsync(It.IsAny<System.Guid>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            return new InventoryViewModel(inventoryService.Object, productService.Object);
        }

        [Fact]
        public async Task AdjustStockCommand_ShouldCallAdjustAndRefresh()
        {
            var vm = GetViewModel();
            vm.SelectedProduct = vm.Products[0];
            vm.StockAdjustment = 5;
            vm.AdjustmentReason = "Reposición";

            await vm.AdjustStockCommand.ExecuteAsync(null);

            vm.StockAdjustment.Should().Be(0);
            vm.AdjustmentReason.Should().Be("");
            vm.SelectedProduct.Should().BeNull();
        }
    }
}