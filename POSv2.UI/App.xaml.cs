services.AddSingleton<PrinterServiceProxy>();
services.AddSingleton<SimulatedPrinterService>();
services.AddSingleton<RealPrinterService>();

services.AddSingleton<BarcodeReaderServiceProxy>();
services.AddSingleton<SimulatedBarcodeReaderService>();
services.AddSingleton<RealBarcodeReaderService>();

services.AddSingleton<CustomerDisplayServiceProxy>();
services.AddSingleton<SimulatedCustomerDisplayService>();
services.AddSingleton<RealCustomerDisplayService>();