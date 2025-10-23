# Guía para Crear Ejecutables POSv2

POSv2 se desarrolla con Avalonia UI, permitiendo crear ejecutables para Windows, macOS, iOS y Android.

## Requisitos Generales
- .NET 8 SDK instalado (descargar de [dotnet.microsoft.com](https://dotnet.microsoft.com))
- Avalonia UI instalado (`dotnet new install Avalonia.Templates`)
- Acceso a Mac para compilación de macOS/iOS
- Android Studio para Android

---

## Windows (.exe)
1. Abre terminal en el directorio raíz del proyecto.
2. Ejecuta:
   ```
   dotnet publish -c Release -r win-x64 --self-contained
   ```
3. El ejecutable estará en `/bin/Release/net8.0/win-x64/publish/POSv2.exe`

---

## macOS (.app)
1. Compilar en una Mac.
2. Ejecuta:
   ```
   dotnet publish -c Release -r osx-x64 --self-contained
   ```
3. La app estará en `/bin/Release/net8.0/osx-x64/publish/POSv2.app`

---

## Linux
1. Ejecuta:
   ```
   dotnet publish -c Release -r linux-x64 --self-contained
   ```
2. El ejecutable estará en `/bin/Release/net8.0/linux-x64/publish/POSv2`

---

## Android (APK)
1. Instala requisitos: Android Studio, .NET MAUI workload.
2. En el terminal:
   ```
   dotnet publish -c Release -f net8.0-android
   ```
3. Busca el APK en `/bin/Release/net8.0-android/publish/`
4. Instala en el dispositivo mediante Android Studio o comando:
   ```
   adb install POSv2.apk
   ```

---

## iOS (IPA)
1. Instala Xcode y .NET MAUI workload en Mac.
2. Ejecuta:
   ```
   dotnet publish -c Release -f net8.0-ios
   ```
3. El archivo .app/IPA estará en `/bin/Release/net8.0-ios/publish/`
4. Instala en el dispositivo mediante Xcode o TestFlight.

---

## Consejos
- Siempre usa compilación `Release` para producción.
- Para ejecutar en dispositivos móviles, necesitas cuenta de desarrollador (Apple/Google).
- Consulta la documentación oficial de Avalonia y .NET para detalles avanzados.

---

**¡Listo! Ahora puedes crear y distribuir POSv2 para cualquier plataforma.**