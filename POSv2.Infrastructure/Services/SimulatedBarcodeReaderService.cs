using POSv2.Application.Interfaces;

public class SimulatedBarcodeReaderService : IBarcodeReaderService
{
    public string ReadBarcode()
    {
        // Simula código fijo o lo puedes pedir al usuario por consola o UI
        return "SIM-CODE-12345";
    }
}