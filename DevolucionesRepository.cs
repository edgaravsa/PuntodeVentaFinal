public class DevolucionesRepository : IDevolucionesRepository
{
    private readonly List<Devolucion> devoluciones;

    public IEnumerable<Devolucion> GetFiltered(DateTime? fechaInicio, DateTime? fechaFin, string usuario, double? montoMin, double? montoMax)
    {
        var query = devoluciones.AsQueryable();
        if (fechaInicio.HasValue)
            query = query.Where(d => d.Fecha >= fechaInicio.Value);
        if (fechaFin.HasValue)
            query = query.Where(d => d.Fecha <= fechaFin.Value);
        if (!string.IsNullOrEmpty(usuario))
            query = query.Where(d => d.Usuario == usuario);
        if (montoMin.HasValue)
            query = query.Where(d => d.Total >= montoMin.Value);
        if (montoMax.HasValue)
            query = query.Where(d => d.Total <= montoMax.Value);
        return query.ToList();
    }
}