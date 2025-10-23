namespace POSv2.Application.Interfaces
{
    public interface IDisplayService
    {
        void ShowText(string text);
        bool IsConnected { get; }
        string GetStatus();
    }
}