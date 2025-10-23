using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POSv2.Application.Interfaces;
using System.Collections.Generic;

public partial class HardwareConfigViewModel : ObservableObject
{
    // ... impresora y scanner

    [ObservableProperty] private string selectedDisplayType;
    [ObservableProperty] private string displayStatus;
    [ObservableProperty] private string displayTestText = "Bienvenido";

    private readonly Dictionary<string, IDisplayService> displays;

    public IRelayCommand TestDisplayCommand { get; }

    public HardwareConfigViewModel(
        MockPrinterService mockPrinter,
        MockBarcodeScannerService mockScanner,
        MockDisplayService mockDisplay
    )
    {
        // ... impresoras y scanners

        displays = new()
        {
            { "Simulador", mockDisplay },
            // { "LCD USB", new LcdUsbDisplayService() }
        };

        SelectedDisplayType = "Simulador";
        DisplayStatus = displays[SelectedDisplayType].GetStatus();

        TestDisplayCommand = new RelayCommand(TestDisplay);
    }

    private void TestDisplay()
    {
        if (displays.ContainsKey(SelectedDisplayType))
        {
            displays[SelectedDisplayType].ShowText(DisplayTestText);
            DisplayStatus = displays[SelectedDisplayType].GetStatus();
        }
        else
        {
            DisplayStatus = "No implementado";
        }
    }
}