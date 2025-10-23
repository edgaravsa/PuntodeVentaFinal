# POSv2

## Descripción

POSv2 es un sistema de punto de venta multiplataforma desarrollado en Avalonia UI (.NET). Funciona en Windows, macOS, Linux, Android e iOS. Permite la integración y simulación de hardware como impresoras, scanners y displays.

---

## Instalación

Consulta la [Guía de Instalación](Guia_Instalacion_POSv2.md) para descargar y ejecutar el instalador adecuado para tu sistema operativo.

---

## Uso de scripts automatizados para compilación y empaquetado

Para facilitar la generación de ejecutables listos para distribuir e instalar, el proyecto incluye scripts automatizados. Estos scripts compilan el sistema y empaquetan los archivos en carpetas separadas para cada plataforma.

### ¿Qué hacen los scripts?

- Compilan el programa para Windows, macOS, Linux, Android e iOS.
- Agrupan los ejecutables en una carpeta `publish`.
- Comprimen cada ejecutable en un archivo `.zip` para facilitar su distribución.

### ¿Dónde están los scripts?

- Para usuarios de **Windows**: usa el archivo `build_all.ps1` (PowerShell).
- Para usuarios de **Linux/macOS**: usa el archivo `build_all.sh` (Bash).

---

### ¿Cómo usar los scripts? (Guía paso a paso)

#### **Windows (PowerShell)**

1. Abre una ventana de PowerShell en la carpeta raíz del proyecto POSv2.
2. Escribe el siguiente comando y presiona Enter:
   ```
   .\build_all.ps1
   ```
3. Espera a que el script termine. Verás carpetas como `publish/win-x64`, `publish/osx-x64`, etc.
4. Los archivos `.zip` estarán dentro de cada carpeta, listos para compartir o instalar.

#### **Linux/macOS (Bash)**

1. Abre una terminal en la carpeta raíz del proyecto POSv2.
2. Escribe el siguiente comando para dar permisos de ejecución al script:
   ```
   chmod +x build_all.sh
   ```
3. Ejecuta el script con:
   ```
   ./build_all.sh
   ```
4. Espera a que el script termine. Verás carpetas como `publish/win-x64`, `publish/osx-x64`, etc.
5. Los archivos `.zip` estarán dentro de cada carpeta, listos para compartir o instalar.

---

### **Notas importantes**

- Es recomendable ejecutar los scripts en modo **Release** para obtener el mejor rendimiento.
- Los ejecutables y archivos `.zip` generados pueden ser copiados y usados en otra computadora con el sistema operativo correspondiente.
- Si tienes dudas o problemas, consulta la sección de **Soporte** en el manual o contacta al equipo de desarrollo.

---

## Otros recursos

- [Manual de Usuario](Manual_Usuario_POSv2.md)
- [Guía Técnica](Manual_Tecnico_POSv2.md)
- [Guía de Pruebas](Guia_Pruebas_POSv2_Hardware.md)