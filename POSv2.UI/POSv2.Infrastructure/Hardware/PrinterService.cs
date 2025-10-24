public class PrinterService : IPrinterService
{
    public bool IsAvailable => true; // Detecta si hay impresora instalada/configurada
    public void PrintTicket(Order order)
    {
        // Lógica para ESC/POS, USB, etc.
    }
}