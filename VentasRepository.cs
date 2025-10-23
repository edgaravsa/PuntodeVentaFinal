public class VentasRepository : IVentasRepository
{
    private readonly List<Venta> ventas;

    public IEnumerable<Venta> GetFiltered(DateTime? fechaInicio, DateTime? fechaFin, string usuario, string metodoPago, double? montoMin, double? montoMax)
    {
        var query = ventas.AsQueryable();
        if (fechaInicio.HasValue)
            query = query.Where(v => v.Fecha >= fechaInicio.Value);
        if (fechaFin.HasValue)
            query = query.Where(v => v.Fecha <= fechaFin.Value);
        if (!string.IsNullOrEmpty(usuario))
            query = query.Where(v => v.Usuario == usuario);
        if (!string.IsNullOrEmpty(metodoPago))
            query = query.Where(v => v.MetodoPago == metodoPago);
        if (montoMin.HasValue)
            query = query.Where(v => v.Total >= montoMin.Value);
        if (montoMax.HasValue)
            query = query.Where(v => v.Total <= montoMax.Value);
        return query.ToList();
    }
}