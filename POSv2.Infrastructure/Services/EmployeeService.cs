using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using POSv2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace POSv2.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext context;
        private Employee? loggedUser;

        public EmployeeService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Employee?> AuthenticateAsync(string username, string password, EmployeeRole requiredRole)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(e => e.Username == username && e.Role == requiredRole);
            if (employee != null && BCrypt.Net.BCrypt.Verify(password, employee.PasswordHash))
            {
                loggedUser = employee;
                return employee;
            }
            return null;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await context.Employees.ToListAsync();
        }

        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public async Task<int> GetNextEmployeeNumberAsync()
        {
            var max = await context.Employees.MaxAsync(e => (int?)e.EmployeeNumber) ?? 0;
            return max + 1;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }

        public async Task<Employee?> GetLoggedUserAsync()
        {
            // En aplicación real se obtendría del contexto actual/session
            return loggedUser;
        }
    }
}