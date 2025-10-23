using Avalonia.Controls;
using POSv2.UI.ViewModels.Products;

public partial class ProductsWindow : Window
{
    public ProductsWindow()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetRequiredService<ProductsViewModel>();
    }
}