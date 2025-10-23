public interface IAuditService
{
    void Register(string userId, string module, string action, string details);
    IEnumerable<AuditLog> GetAllLogs();
    IEnumerable<AuditLog> GetFilteredLogs(string userId, string module, string action, DateTime? from, DateTime? to);
}