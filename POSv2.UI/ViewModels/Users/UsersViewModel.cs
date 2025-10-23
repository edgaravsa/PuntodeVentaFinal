public class UsersViewModel
{
    public Employee CurrentUser { get; }

    public UsersViewModel(Employee currentUser)
    {
        if (currentUser == null || currentUser.Role != "Administrador")
            throw new UnauthorizedAccessException("Acceso denegado. Solo administradores pueden gestionar usuarios.");

        CurrentUser = currentUser;
        // Inicializa otros miembros aquí si es necesario
    }

    // Otros métodos y propiedades de UsersViewModel
}