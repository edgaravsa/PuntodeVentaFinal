using Xunit;
using FluentAssertions;
using POSv2.UI.ViewModels.Cashier;
using POSv2.Domain.Entities;
using Moq;
using POSv2.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POSv2.Tests.ViewModels
{
    public class CashierViewModelTests
    {
        private CashierViewModel GetViewModel(
            List<Product>? products = null,
            List<Client>? clients = null)
        {
            var productService = new Mock<IProductService>();
            var orderService = new Mock<IOrderService>();
            var clientService = new Mock<IClientService>();
            var employeeService = new Mock<IEmployeeService>();

            products ??= new List<Product>
            {
                new Product { Id = System.Guid.NewGuid(), Name = "Prod1", PriceWithTax = 50 },
                new Product { Id = System.Guid.NewGuid(), Name = "Prod2", PriceWithTax = 100 }
            };
            clients ??= new List<Client>
            {
                new Client { Id = System.Guid.NewGuid(), Name = "Cliente1" }
            };

            productService.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(products);
            clientService.Setup(x => x.GetAllClientsAsync()).ReturnsAsync(clients);

            var loggedUser = new Employee { Id = System.Guid.NewGuid(), Name = "Cashier", Role = EmployeeRole.Cashier };
            employeeService.Setup(x => x.GetLoggedUserAsync()).ReturnsAsync(loggedUser);

            orderService.Setup(x => x.SaveOrderAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);

            return new CashierViewModel(productService.Object, orderService.Object, clientService.Object, employeeService.Object);
        }

        [Fact]
        public void AddToCart_ShouldIncreaseQuantity_WhenProductAlreadyInCart()
        {
            var vm = GetViewModel();
            var product = vm.Products[0];

            vm.AddToCartCommand.Execute(new ProductQuantitySelection { Product = product, Quantity = 1 });
            vm.AddToCartCommand.Execute(new ProductQuantitySelection { Product = product, Quantity = 2 });

            vm.Cart.Should().ContainSingle();
            vm.Cart[0].Quantity.Should().Be(3);
        }

        [Fact]
        public void RemoveFromCart_ShouldRemoveItem()
        {
            var vm = GetViewModel();
            var product = vm.Products[0];

            var selection = new ProductQuantitySelection { Product = product, Quantity = 1 };
            vm.AddToCartCommand.Execute(selection);
            vm.RemoveFromCartCommand.Execute(selection);

            vm.Cart.Should().BeEmpty();
        }

        [Fact]
        public void UpdateTotals_ShouldCalculateSubtotalTaxTotal()
        {
            var vm = GetViewModel();
            var product1 = vm.Products[0];
            var product2 = vm.Products[1];

            vm.AddToCartCommand.Execute(new ProductQuantitySelection { Product = product1, Quantity = 2 });
            vm.AddToCartCommand.Execute(new ProductQuantitySelection { Product = product2, Quantity = 1 });

            vm.Subtotal.Should().Be(200);
            vm.Tax.Should().Be(32); // 16% IVA de 200
            vm.Total.Should().Be(232);
        }

        [Fact]
        public async Task ConfirmSaleCommand_ShouldClearCartAndResetTotals()
        {
            var vm = GetViewModel();
            var product = vm.Products[0];
            vm.AddToCartCommand.Execute(new ProductQuantitySelection { Product = product, Quantity = 2 });
            vm.CashReceived = 200;

            await vm.ConfirmSaleCommand.ExecuteAsync(null);

            vm.Cart.Should().BeEmpty();
            vm.Subtotal.Should().Be(0);
            vm.Tax.Should().Be(0);
            vm.Total.Should().Be(0);
            vm.CashReceived.Should().Be(0);
            vm.Change.Should().Be(0);
        }

        [Fact]
        public async Task SearchProductsCommand_ShouldLoadProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = System.Guid.NewGuid(), Name = "ProdA", PriceWithTax = 10 }
            };
            var vm = GetViewModel(products: products);

            await vm.SearchProductsCommand.ExecuteAsync(null);

            vm.Products.Should().ContainSingle(p => p.Name == "ProdA");
        }

        [Fact]
        public async Task LoadClientsAsync_ShouldLoadClients()
        {
            var clients = new List<Client>
            {
                new Client { Id = System.Guid.NewGuid(), Name = "CliA" }
            };
            var vm = GetViewModel(clients: clients);

            await Task.Delay(10); // Espera a la carga async
            vm.Clients.Should().ContainSingle(c => c.Name == "CliA");
        }
    }
}