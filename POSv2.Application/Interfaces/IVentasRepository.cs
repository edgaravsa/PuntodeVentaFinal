namespace POSv2.Application.Interfaces
{
    public interface IVentasRepository
    {
        IEnumerable<Venta> GetFiltered(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string usuario,
            string metodoPago,
            double? montoMin,
            double? montoMax);
        // ... otros métodos
    }
}
