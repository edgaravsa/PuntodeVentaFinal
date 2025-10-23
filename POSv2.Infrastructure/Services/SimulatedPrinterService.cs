using POSv2.Application.Interfaces;
using System.IO;

public class SimulatedPrinterService : IPrinterService
{
    public void Print(string text)
    {
        File.WriteAllText("ticket_simulado.txt", text);
    }
}