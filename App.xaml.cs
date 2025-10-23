using POSv2.Application.Interfaces;
using POSv2.Infrastructure.Hardware;
using POSv2.UI.ViewModels;

public override void ConfigureServices(IServiceCollection services)
{
    // Otros servicios y repositorios...
    
    // Hardware (solo simulador de ejemplo, puedes agregar más)
    services.AddSingleton<IPrinterService, MockPrinterService>();
    services.AddSingleton<IBarcodeScannerService, MockBarcodeScannerService>();
    services.AddSingleton<IDisplayService, MockDisplayService>();

    // ViewModel de configuración de hardware
    services.AddTransient<HardwareConfigViewModel>();
}