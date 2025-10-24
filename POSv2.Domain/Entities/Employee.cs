namespace POSv2.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Username { get; set; } // Login único
        public string PasswordHash { get; set; } // Hasheada
        public EmployeeRole Role { get; set; } // Enum
        public bool IsActive { get; set; }
    }

    public enum EmployeeRole
    {
        Cashier,
        Manager,
        Administrator
    }
}
