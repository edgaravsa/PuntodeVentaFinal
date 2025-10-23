public class AuditLog
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string Module { get; set; }
    public string Action { get; set; }
    public string Details { get; set; }
    public DateTime Timestamp { get; set; }
}