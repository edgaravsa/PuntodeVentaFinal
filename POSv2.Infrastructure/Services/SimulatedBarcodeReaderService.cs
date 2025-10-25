using POSv2.Application.Interfaces;
using POSv2.Domain.Entities;

namespace POSv2.Infrastructure.Services
{
    public class SimulatedBarcodeReaderService : IBarcodeReaderService
    {
        public string ReadBarcode()
        {
            // Simula código fijo, puedes cambiarlo si quieres pedirlo por consola o UI
            return "SIM-CODE-12345";
        }
    }
}