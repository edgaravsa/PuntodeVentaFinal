using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace POSv2.UI.ViewModels.Products
{
    public partial class ProductViewModel : ObservableObject
    {
        private readonly IProductService productService;
        private readonly IEmployeeService employeeService;

        [ObservableProperty] private ObservableCollection<Product> products = new();
        [ObservableProperty] private Product? selectedProduct;

        // Propiedades para crear/editar producto
        [ObservableProperty] private string sku = "";
        [ObservableProperty] private string name = "";
        [ObservableProperty] private ProductSize size = ProductSize.Medium;
        [ObservableProperty] private string description = "";
        [ObservableProperty] private string category = "";
        [ObservableProperty] private string unit = "";
        [ObservableProperty] private int quantity = 1;
        [ObservableProperty] private decimal priceWithTax = 0;
        [ObservableProperty] private string imagePath = "";

        public IRelayCommand AddProductCommand { get; }
        public IRelayCommand EditProductCommand { get; }
        public IRelayCommand DeleteProductCommand { get; }
        public IRelayCommand SearchProductsCommand { get; }
        public IRelayCommand ClearFormCommand { get; }

        public ProductViewModel(IProductService productService, IEmployeeService employeeService)
        {
            this.productService = productService;
            this.employeeService = employeeService;

            AddProductCommand = new RelayCommand(async () => await AddProductAsync());
            EditProductCommand = new RelayCommand(async () => await EditProductAsync());
            DeleteProductCommand = new RelayCommand(async () => await DeleteProductAsync());
            SearchProductsCommand = new RelayCommand(async () => await SearchProductsAsync());
            ClearFormCommand = new RelayCommand(ClearForm);

            _ = SearchProductsAsync();
        }

        private async Task AddProductAsync()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                SKU = Sku,
                Name = Name,
                Size = Size,
                Description = Description,
                Category = Category,
                Unit = Unit,
                Quantity = Quantity,
                PriceWithTax = PriceWithTax,
                ImagePath = ImagePath
            };
            await productService.AddProductAsync(product);
            await SearchProductsAsync();
            ClearForm();
        }

        private async Task EditProductAsync()
        {
            if (SelectedProduct == null) return;
            SelectedProduct.SKU = Sku;
            SelectedProduct.Name = Name;
            SelectedProduct.Size = Size;
            SelectedProduct.Description = Description;
            SelectedProduct.Category = Category;
            SelectedProduct.Unit = Unit;
            SelectedProduct.Quantity = Quantity;
            SelectedProduct.PriceWithTax = PriceWithTax;
            SelectedProduct.ImagePath = ImagePath;

            await productService.UpdateProductAsync(SelectedProduct);
            await SearchProductsAsync();
            ClearForm();
        }

        private async Task DeleteProductAsync()
        {
            if (SelectedProduct == null) return;
            await productService.DeleteProductAsync(SelectedProduct.Id);
            await SearchProductsAsync();
            ClearForm();
        }

        private async Task SearchProductsAsync()
        {
            var productList = await productService.GetAllProductsAsync();
            Products = new ObservableCollection<Product>(productList);
        }

        private void ClearForm()
        {
            Sku = "";
            Name = "";
            Size = ProductSize.Medium;
            Description = "";
            Category = "";
            Unit = "";
            Quantity = 1;
            PriceWithTax = 0;
            ImagePath = "";
            SelectedProduct = null;
        }
    }
}