using POSv2.Application.Interfaces;
using BCrypt.Net;

public class AuthenticationService : IAuthenticationService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

    // ... otros métodos de autenticación
}