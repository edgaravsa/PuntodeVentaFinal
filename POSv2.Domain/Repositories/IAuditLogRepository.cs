using POSv2.Domain.Entities;
using System.Collections.Generic;

namespace POSv2.Domain.Repositories
{
    public interface IAuditLogRepository
    {
        void Add(AuditLog log);
        IEnumerable<AuditLog> GetAll();
    }
}