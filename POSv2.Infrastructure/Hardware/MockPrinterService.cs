using POSv2.Application.Interfaces;
using POSv2.Domain.Entities;
using System;

namespace POSv2.Infrastructure.Hardware
{
    public class MockPrinterService : IPrinterService
    {
        public bool IsConnected => true;
        public void Print(string content) => Console.WriteLine($"[Simulado] Imprimiendo: {content}");
        public string GetStatus() => "Simulador de impresora activo";
    }
}