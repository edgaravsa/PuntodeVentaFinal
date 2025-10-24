using POSv2.Application.Interfaces;
using System;

namespace POSv2.Infrastructure.Hardware
{
    public class MockDisplayService : IDisplayService
    {
        public bool IsConnected => true;
        public void ShowText(string text) => Console.WriteLine($"[Simulado] Display muestra: {text}");
        public string GetStatus() => "Simulador de display activo";
    }
}