using POSv2.Application.Interfaces;
using POSv2.Domain.Entities;

public class CustomerDisplayService : ICustomerDisplayService
{
    public bool IsAvailable => true; // Detecta si hay pantalla cliente
    public void ShowTotal(decimal total)
    {
        // Muestra info en pantalla secundaria
    }
    public void ShowMessage(string message)
    {
        // Muestra mensaje
    }
}