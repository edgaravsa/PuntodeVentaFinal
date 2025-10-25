using System;
using System.Collections.Generic;
using System.Linq;
using POSv2.Domain.Entities;
using POSv2.Domain.Repositories;

namespace POSv2.Application.Services
{
    public class AuditService
    {
        private readonly IAuditLogRepository auditRepo;

        public AuditService(IAuditLogRepository auditRepo)
        {
            this.auditRepo = auditRepo;
        }

        public IEnumerable<AuditLog> GetFilteredLogs(string userId, string module, string action, DateTime? from, DateTime? to)
        {
            var query = auditRepo.GetAll().AsQueryable();
            if (!string.IsNullOrWhiteSpace(userId))
                query = query.Where(l => l.UserId.Contains(userId));
            if (!string.IsNullOrWhiteSpace(module))
                query = query.Where(l => l.Module.Contains(module));
            if (!string.IsNullOrWhiteSpace(action))
                query = query.Where(l => l.Action.Contains(action));
            if (from.HasValue)
                query = query.Where(l => l.Timestamp >= from.Value);
            if (to.HasValue)
                query = query.Where(l => l.Timestamp <= to.Value);
            return query.OrderByDescending(l => l.Timestamp).ToList();
        }
    }
}