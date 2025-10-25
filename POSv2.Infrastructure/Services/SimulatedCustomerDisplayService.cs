using POSv2.Application.Interfaces;
using POSv2.Domain.Entities;

namespace POSv2.Infrastructure.Services
{
    public class SimulatedCustomerDisplayService : ICustomerDisplayService
    {
        public bool IsAvailable => false;
        public void ShowTotal(decimal total) { /* No hace nada */ }
        public void ShowMessage(string message) { /* No hace nada */ }
    }
}