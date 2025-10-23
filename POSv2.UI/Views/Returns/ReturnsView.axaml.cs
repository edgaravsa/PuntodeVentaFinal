using Avalonia.Controls;
using POSv2.UI.ViewModels.Returns;

public partial class ReturnsView : UserControl
{
    public ReturnsView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetRequiredService<ReturnsViewModel>();
    }
}