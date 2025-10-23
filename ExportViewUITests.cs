using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Testing;
using Xunit;

public class ExportViewUITests : AvaloniaTestClass
{
    [Fact]
    public async Task ExportView_ShowsDynamicFilters_WhenBaseChanged()
    {
        var vm = new ExportViewModel(...); // mocks/repositorios de prueba
        var view = new ExportView { DataContext = vm };

        var combo = view.FindControl<ComboBox>("BaseCombo");
        combo.SelectedItem = "Ventas";
        await Task.Delay(50); // Espera renderizado

        var ventasFilters = view.FindControl<StackPanel>("VentasFilters");
        Assert.True(ventasFilters.IsVisible);

        combo.SelectedItem = "Productos";
        await Task.Delay(50);

        var productosFilters = view.FindControl<StackPanel>("ProductosFilters");
        Assert.True(productosFilters.IsVisible);
    }

    [Fact]
    public async Task ExportView_ExportButtonDisabled_WhenNoItems()
    {
        var vm = new ExportViewModel(...); // mocks/repositorios de prueba
        var view = new ExportView { DataContext = vm };

        var exportBtn = view.FindControl<Button>("ExportButton");
        Assert.False(exportBtn.IsEnabled);
    }
}