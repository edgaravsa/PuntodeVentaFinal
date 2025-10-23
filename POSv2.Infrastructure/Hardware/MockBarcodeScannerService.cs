using POSv2.Application.Interfaces;
using System;

namespace POSv2.Infrastructure.Hardware
{
    public class MockBarcodeScannerService : IBarcodeScannerService
    {
        public bool IsConnected => true;
        public string GetStatus() => "Simulador de lector activo";

        public event Action<string> BarcodeScanned;

        public void Start() => Console.WriteLine("[Simulado] Lector iniciado");
        public void Stop() => Console.WriteLine("[Simulado] Lector detenido");

        // Simula un escaneo manual
        public void SimulateScan(string code)
        {
            BarcodeScanned?.Invoke(code);
        }
    }
}