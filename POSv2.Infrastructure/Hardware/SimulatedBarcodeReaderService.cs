public class SimulatedBarcodeReaderService : IBarcodeReaderService
{
    public bool IsAvailable => false;
    public event Action<string> BarcodeScanned;
    public void Initialize()
    {
        // No hace nada
    }
}