public class Startup
{
    private readonly IConfiguration config;
    private readonly IServiceCollection services;

    public Startup(IConfiguration config, IServiceCollection services)
    {
        this.config = config;
        this.services = services;
    }

    public void ConfigureServices()
    {
        if (config.UsePrinter)
            services.AddSingleton<IPrinterService, PrinterService>();
        else
            services.AddSingleton<IPrinterService, SimulatedPrinterService>();

        if (config.UseBarcodeReader)
            services.AddSingleton<IBarcodeReaderService, BarcodeReaderService>();
        else
            services.AddSingleton<IBarcodeReaderService, SimulatedBarcodeReaderService>();

        if (config.UseCustomerDisplay)
            services.AddSingleton<ICustomerDisplayService, CustomerDisplayService>();
        else
            services.AddSingleton<ICustomerDisplayService, SimulatedCustomerDisplayService>();
    }
}