# Manual Técnico – POSv2

## 1. Arquitectura
- Basado en Avalonia UI (C#)
- Uso de interfaces para hardware: impresora, scanner, display.
- Inyección de dependencias con DI (Microsoft.Extensions.DependencyInjection).
- Multiplataforma: Windows, macOS, Linux, iOS, Android.

## 2. Estructura de carpetas
```
POSv2.Application/
POSv2.Infrastructure/
POSv2.UI/
POSv2.Mobile/
POSv2.Tests/
```

## 3. Implementaciones de hardware
- Mock y clases concretas para cada tipo de dispositivo.
- Selección dinámica de hardware desde la configuración.

## 4. Pruebas
- Unitarias: xUnit + Moq.
- Manuales: ver [Guía de Pruebas](Guia_Pruebas_POSv2_Hardware.md).

## 5. Empaquetado y despliegue
- Ver [Guía de Ejecutables](Guia_Ejecutables_POSv2.md).

## 6. Extensión y mantenimiento
- Añadir nuevos dispositivos: implementar la interfaz y registrar en DI.