using POSv2.Infrastructure.Services;
using Xunit;
using System.IO;

public class SimulatedPrinterServiceTests
{
    [Fact]
    public void Print_ShouldCreateSimulatedTicketFile()
    {
        var printer = new SimulatedPrinterService();
        var text = "TEST TICKET";
        var filePath = "ticket_simulado.txt";

        printer.Print(text);

        Assert.True(File.Exists(filePath));
        Assert.Equal(text, File.ReadAllText(filePath));
        File.Delete(filePath);
    }
}