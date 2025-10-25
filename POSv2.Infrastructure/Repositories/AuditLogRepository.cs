using POSv2.Domain.Entities;
using POSv2.Domain.Repositories;
using System.Collections.Generic;
using POSv2.Application.Interfaces;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly List<AuditLog> logs = new();

    public void Add(AuditLog log)
    {
        logs.Add(log);
    }

    public IEnumerable<AuditLog> GetAll()
    {
        // Ordena por fecha descendente
        return logs.OrderByDescending(l => l.Timestamp).ToList();
    }
}