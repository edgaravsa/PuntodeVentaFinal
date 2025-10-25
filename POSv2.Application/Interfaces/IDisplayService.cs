using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;

namespace POSv2.Application.Interfaces
{
    public interface IDisplayService
    {
        void ShowText(string text);
        bool IsConnected { get; }
        string GetStatus();
    }
}