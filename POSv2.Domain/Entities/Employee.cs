public class Employee
{
    public Guid Id { get; set; }
    public string Username { get; set; } // Login único
    public string FullName { get; set; }
    public string PasswordHash { get; set; } // Hasheada
    public string Role { get; set; } // "Cajero", "Gerente", "Administrador"
    public bool IsActive { get; set; }
}