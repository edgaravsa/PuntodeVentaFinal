public class AuditRepository : IAuditRepository
{
    private readonly List<Auditoria> auditorias;

    public IEnumerable<Auditoria> GetFiltered(DateTime? fechaInicio, DateTime? fechaFin, string usuario, string rol)
    {
        var query = auditorias.AsQueryable();
        if (fechaInicio.HasValue)
            query = query.Where(a => a.Fecha >= fechaInicio.Value);
        if (fechaFin.HasValue)
            query = query.Where(a => a.Fecha <= fechaFin.Value);
        if (!string.IsNullOrEmpty(usuario))
            query = query.Where(a => a.Usuario == usuario);
        if (!string.IsNullOrEmpty(rol))
            query = query.Where(a => a.Rol == rol);
        return query.ToList();
    }
}