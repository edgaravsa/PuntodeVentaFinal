using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;

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
