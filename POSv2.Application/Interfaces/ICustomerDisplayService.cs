using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;

namespace POSv2.Application.Interfaces
{
    public interface ICustomerDisplayService
    {
        bool IsAvailable { get; }
        void ShowTotal(decimal total);
        void ShowMessage(string message);
    }
}
