using POSv2.Application.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

public partial class VentaViewModel : ObservableObject
{
    private readonly IBarcodeScannerService scanner;
    private readonly IProductosRepository productosRepo;
    private readonly IDisplayService display;

    [ObservableProperty] private ObservableCollection<Producto> carrito = new();
    [ObservableProperty] private double totalVenta;
    [ObservableProperty] private double pagoCliente;
    [ObservableProperty] private double cambio;

    public VentaViewModel(
        IBarcodeScannerService scanner,
        IProductosRepository productosRepo,
        IDisplayService display
    )
    {
        this.scanner = scanner;
        this.productosRepo = productosRepo;
        this.display = display;

        scanner.BarcodeScanned += OnBarcodeScanned;
        scanner.Start();
    }

    private void OnBarcodeScanned(string code)
    {
        var producto = productosRepo.BuscarPorCodigo(code);
        if (producto != null)
        {
            Carrito.Add(producto);
            CalcularTotal();
        }
        // Puedes agregar notificación, sonido, etc.
    }

    private void CalcularTotal()
    {
        TotalVenta = Carrito.Sum(p => p.Precio);
        MostrarTotalEnDisplay();
    }

    private void MostrarTotalEnDisplay()
    {
        display.ShowText($"Total: {TotalVenta:C}");
    }

    public void Cobrar(double pago)
    {
        PagoCliente = pago;
        Cambio = PagoCliente - TotalVenta;
        display.ShowText($"Cambio: {Cambio:C}");
    }
}