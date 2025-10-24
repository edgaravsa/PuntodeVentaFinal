using POSv2.Application.Interfaces;

public class SimulatedCustomerDisplayService : ICustomerDisplayService
{
    public void ShowText(string text)
    {
        System.Console.WriteLine("DISPLAY: " + text);
    }
}