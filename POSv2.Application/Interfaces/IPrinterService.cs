namespace POSv2.Application.Interfaces
{
    public interface IPrinterService
    {
        void Print(string content);
        bool IsConnected { get; }
        string GetStatus();
    }
}