using POSv2.Domain.Entities;
using System.Collections.Generic;

public interface IAuditLogRepository
{
    void Add(AuditLog log);
    IEnumerable<AuditLog> GetAll();
}