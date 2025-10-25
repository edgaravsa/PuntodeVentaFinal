using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;

namespace POSv2.Application.Interfaces
{
    public interface IAuthenticationService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
        // ... otros métodos
    }
}
