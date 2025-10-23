using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace POSv2.UI.ViewModels.Cashier
{
    public partial class CashierViewModel : ObservableObject
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IClientService clientService;
        private readonly IEmployeeService employeeService;

        [ObservableProperty] private ObservableCollection<ProductQuantitySelection> cart = new();
        [ObservableProperty] private ObservableCollection<Product> products = new();
        [ObservableProperty] private ObservableCollection<Client> clients = new();
        [ObservableProperty] private Client? selectedClient;
        [ObservableProperty] private PaymentType selectedPaymentType = PaymentType.Cash;
        [ObservableProperty] private decimal subtotal;
        [ObservableProperty] private decimal tax;
        [ObservableProperty] private decimal discount;
        [ObservableProperty] private decimal total;
        [ObservableProperty] private decimal cashReceived;
        [ObservableProperty] private decimal change;

        public IRelayCommand<ProductQuantitySelection> AddToCartCommand { get; }
        public IRelayCommand<ProductQuantitySelection> RemoveFromCartCommand { get; }
        public IRelayCommand CalculateTotalsCommand { get; }
        public IRelayCommand ConfirmSaleCommand { get; }
        public IRelayCommand SearchProductsCommand { get; }

        public CashierViewModel(IProductService productService,
                                IOrderService orderService,
                                IClientService clientService,
                                IEmployeeService employeeService)
        {
            this.productService = productService;
            this.orderService = orderService;
            this.clientService = clientService;
            this.employeeService = employeeService;

            AddToCartCommand = new RelayCommand<ProductQuantitySelection>(AddToCart);
            RemoveFromCartCommand = new RelayCommand<ProductQuantitySelection>(RemoveFromCart);
            CalculateTotalsCommand = new RelayCommand(UpdateTotals);
            ConfirmSaleCommand = new RelayCommand(async () => await ConfirmSaleAsync());
            SearchProductsCommand = new RelayCommand(async () => await SearchProductsAsync());

            _ = LoadClientsAsync();
            _ = SearchProductsAsync();
        }

        private void AddToCart(ProductQuantitySelection selection)
        {
            var existing = Cart.FirstOrDefault(x => x.Product.Id == selection.Product.Id);
            if (existing != null)
                existing.Quantity += selection.Quantity;
            else
                Cart.Add(new ProductQuantitySelection { Product = selection.Product, Quantity = selection.Quantity });
            UpdateTotals();
        }

        private void RemoveFromCart(ProductQuantitySelection selection)
        {
            Cart.Remove(selection);
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            Subtotal = Cart.Sum(x => x.Product.PriceWithTax * x.Quantity);
            Tax = Math.Round(Subtotal * 0.16M, 2); // IVA 16%
            Discount = 0; // Puede agregarse lógica de descuentos
            Total = Subtotal + Tax - Discount;
            Change = CashReceived > Total ? CashReceived - Total : 0;
        }

        private async Task ConfirmSaleAsync()
        {
            if (Cart.Count == 0 || Total <= 0) return;

            var loggedUser = await employeeService.GetLoggedUserAsync();
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Subtotal = Subtotal,
                Tax = Tax,
                Total = Total,
                Discount = Discount,
                PaymentType = SelectedPaymentType,
                Branch = "Central Branch",
                CashierId = loggedUser?.Id ?? Guid.Empty,
                ClientId = SelectedClient?.Id,
                Items = Cart.Select(c => new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = c.Product.Id,
                    Quantity = c.Quantity,
                    PriceWithTax = c.Product.PriceWithTax
                }).ToList()
            };

            await orderService.SaveOrderAsync(order);
            Cart.Clear();
            UpdateTotals();
            CashReceived = 0;
            Change = 0;
            // Aquí podría llamarse a la impresión/exportación del ticket
        }

        private async Task LoadClientsAsync()
        {
            var clientList = await clientService.GetAllClientsAsync();
            Clients = new ObservableCollection<Client>(clientList);
        }

        private async Task SearchProductsAsync()
        {
            var productList = await productService.GetAllProductsAsync();
            Products = new ObservableCollection<Product>(productList);
        }
    }

    public class ProductQuantitySelection : ObservableObject
    {
        [ObservableProperty] public Product Product;
        [ObservableProperty] public int Quantity;
    }
}