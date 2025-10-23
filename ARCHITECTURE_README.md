# POSv2 Arquitectura y Flujos Principales

## 1. DI/Container
- Todos los servicios, repositorios y ViewModels se registran en App.xaml.cs.
- Las ventanas obtienen su ViewModel desde el container.

## 2. Seguridad y Auditoría
- Todas las acciones sensibles requieren autorización.
- Se registra en auditoría: usuario, módulo, acción, detalles, fecha/hora.

## 3. Hardware
- Integración modular: real/simulado.
- Se configura desde la vista de configuración.

## 4. Cómo agregar un módulo nuevo
- Hereda de AuthorizedViewModel.
- Usa RequestAuthorization y RegisterAudit.
- Registra el ViewModel en el DI/container.

## 5. Roles y permisos
- Cajero: solo caja y clientes.
- Gerente/Administrador: todo lo demás.

...