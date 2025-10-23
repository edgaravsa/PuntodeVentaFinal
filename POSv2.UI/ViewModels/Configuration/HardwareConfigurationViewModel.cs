using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace POSv2.UI.ViewModels.Configuration
{
    public partial class HardwareConfigurationViewModel : ObservableObject
    {
        // Opciones de hardware
        [ObservableProperty] private bool usePrinter;
        [ObservableProperty] private bool useBarcodeReader;
        [ObservableProperty] private bool useCustomerDisplay;

        // Modelos seleccionables
        [ObservableProperty] private ObservableCollection<string> printerModels = new()
        {
            "Simulado (PDF)",
            "Genérico ESC/POS",
            "Windows Print",
            "Epson TM-T20",
            "Star TSP100"
        };
        [ObservableProperty] private string selectedPrinterModel = "Simulado (PDF)";

        [ObservableProperty] private ObservableCollection<string> barcodeReaderModels = new()
        {
            "Simulado (manual)",
            "USB HID",
            "Serial RS232",
            "Honeywell Voyager",
            "Zebra DS2208"
        };
        [ObservableProperty] private string selectedBarcodeReaderModel = "Simulado (manual)";

        [ObservableProperty] private ObservableCollection<string> customerDisplayModels = new()
        {
            "Simulado (pantalla secundaria)",
            "Serial VFD",
            "USB LCD"
        };
        [ObservableProperty] private string selectedCustomerDisplayModel = "Simulado (pantalla secundaria)";

        public IRelayCommand SaveHardwareConfigCommand { get; }

        public HardwareConfigurationViewModel()
        {
            SaveHardwareConfigCommand = new RelayCommand(SaveHardwareConfig);
            // Cargar configuración previa si existe
        }

        private void SaveHardwareConfig()
        {
            // Guarda las opciones seleccionadas en config.json o en tu sistema de configuración
            // Ejemplo:
            // ConfigService.SaveHardwareConfig(new HardwareConfig
            // {
            //     UsePrinter = UsePrinter,
            //     PrinterModel = SelectedPrinterModel,
            //     UseBarcodeReader = UseBarcodeReader,
            //     BarcodeReaderModel = SelectedBarcodeReaderModel,
            //     UseCustomerDisplay = UseCustomerDisplay,
            //     CustomerDisplayModel = SelectedCustomerDisplayModel
            // });
        }
    }
}