public class SimulatedPrinterService : IPrinterService
{
    public bool IsAvailable => true;
    public void PrintTicket(Order order)
    {
        // Genera PDF o muestra ticket en pantalla
    }
}