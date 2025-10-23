using Avalonia.Controls;
using POSv2.UI.ViewModels.Configuration;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetRequiredService<ConfigurationViewModel>();
    }
}