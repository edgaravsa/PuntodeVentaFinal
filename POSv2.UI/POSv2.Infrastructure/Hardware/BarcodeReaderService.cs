public class BarcodeReaderService : IBarcodeReaderService
{
    public bool IsAvailable => true; // Detecta si hay lector configurado
    public event Action<string> BarcodeScanned;
    public void Initialize()
    {
        // Escucha puerto serie/USB y dispara evento BarcodeScanned
    }
}