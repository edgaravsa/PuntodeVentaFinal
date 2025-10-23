# Guía de Pruebas para Integración de Hardware en POSv2

## Objetivo
Validar que la integración de impresora, scanner y display en el sistema POSv2 funciona correctamente, tanto en modo simulador como con hardware real (cuando esté disponible).

---

## 1. Pruebas de Configuración de Hardware

### 1.1. Impresora

**Pasos:**
- Abrir la sección "Configuración de Hardware" en el sistema.
- Seleccionar tipo de impresora: Simulador (o modelo real si está disponible).
- Ingresar un texto de prueba y presionar el botón "Test Print".
- Verificar que:
  - Se muestra mensaje de éxito.
  - El estado de la impresora indica "Simulador de impresora activo" o el estado correcto del modelo real.

**Resultado esperado:**  
El sistema confirma la impresión simulada o real sin errores.

---

### 1.2. Scanner de Código de Barras

**Pasos:**
- En "Configuración de Hardware", seleccionar tipo de scanner: Simulador (o modelo real si está disponible).
- Ingresar un código de barras de prueba y presionar "Test Scan".
- Verificar que:
  - El sistema muestra el código escaneado en pantalla.
  - El estado del scanner es "Simulador de lector activo" o equivalente.

**Resultado esperado:**  
El sistema registra el código simulado o real sin errores.

---

### 1.3. Display de Cliente

**Pasos:**
- En "Configuración de Hardware", seleccionar tipo de display: Simulador (o modelo real si está disponible).
- Ingresar un texto de prueba y presionar "Test Display".
- Verificar que:
  - El display (simulado o real) muestra el texto ingresado.
  - El estado del display es "Simulador de display activo" o equivalente.

**Resultado esperado:**  
El sistema envía el mensaje al display sin errores.

---

## 2. Pruebas Funcionales en el Flujo de Venta

### 2.1. Venta por Escaneo

**Pasos:**
- Abrir una nueva venta.
- En la configuración de hardware, simular un escaneo con el código de un producto válido.
- Verificar que:
  - El producto se agrega automáticamente al carrito de venta.
  - El total se actualiza correctamente.

**Resultado esperado:**  
El producto aparece en la venta y el total es correcto.

---

### 2.2. Visualización en Display

**Pasos:**
- Agregar productos a la venta.
- Verificar que el display muestra el total actualizado.
- Al realizar el cobro, ingresar el monto recibido y finalizar la venta.
- Verificar que el display muestra el cambio a entregar al cliente.

**Resultado esperado:**  
El display muestra correctamente el total y el cambio.

---

## 3. Pruebas de Error y Recuperación

**Pasos:**
- Desconectar el hardware (si está disponible) y repetir pruebas de impresión, escaneo y display.
- Intentar operar con hardware no configurado.
- Intentar operar con hardware configurado incorrectamente.

**Resultado esperado:**  
El sistema muestra mensajes de error claros y no permite operaciones incorrectas.

---

## 4. Pruebas de Cambio de Hardware

**Pasos:**
- Cambiar entre simulador y modelo real en cada tipo de hardware (cuando esté disponible).
- Repetir las pruebas anteriores para cada tipo.

**Resultado esperado:**  
El sistema responde correctamente al cambio de hardware y las pruebas siguen siendo exitosas.

---

## 5. Checklist de Validación

- [ ] Impresora: Simulador y real funcionan y muestran estado correcto.
- [ ] Scanner: Simulador y real escanean y registran el código.
- [ ] Display: Simulador y real muestran mensajes y estados correctos.
- [ ] Venta por escaneo: Productos se agregan correctamente.
- [ ] Display en venta: Total y cambio se muestran correctamente.
- [ ] Mensajes de error: Se muestran cuando el hardware está desconectado o mal configurado.
- [ ] Cambios de hardware: El sistema responde y opera correctamente.

---

## Notas
- Documentar cualquier error, comportamiento inesperado o sugerencia de mejora.
- Adjuntar capturas de pantalla si es posible.
- Indicar modelo y marca de hardware real si se utiliza.

---

**¡Gracias por seguir esta guía!**