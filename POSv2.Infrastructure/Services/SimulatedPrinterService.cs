using POSv2.Application.Interfaces;
using POSv2.Domain.Entities;
using System.IO;

namespace POSv2.Infrastructure.Services
{
    public class SimulatedPrinterService : IPrinterService
    {
        public bool IsConnected => true; // O false si quieres simular desconexión

        public void Print(string content)
        {
            // Puedes simular la impresión escribiendo a un archivo, consola, etc.
            File.WriteAllText("ticket_simulado.txt", content);
            // O: System.Console.WriteLine($"[SimulatedPrinter] Printing: {content}");
        }

        public string GetStatus()
        {
            // Devuelve siempre "OK", puedes personalizar si quieres simular errores
            return "OK";
        }
    }
}