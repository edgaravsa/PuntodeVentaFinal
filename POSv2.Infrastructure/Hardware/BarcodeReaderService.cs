using POSv2.Application.Interfaces;
using POSv2.Domain.Entities;

public class BarcodeReaderService : IBarcodeReaderService
{
    public bool IsAvailable => true; // Detecta si hay lector configurado

    public event Action<string> BarcodeScanned;

    public void Initialize()
    {
        // Escucha puerto serie/USB y dispara evento BarcodeScanned
    }

    public string ReadBarcode()
    {
        // Lógica simulada
        return ""; // O el valor leído del lector real
    }
}