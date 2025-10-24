namespace POSv2.Application.Interfaces
{
    public interface IBarcodeScannerService
    {
        event Action<string> BarcodeScanned;
        void Start();
        void Stop();
        bool IsConnected { get; }
        string GetStatus();
    }
}