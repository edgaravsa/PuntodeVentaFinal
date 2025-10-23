public interface IAuthenticationService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
    // ... otros métodos
}