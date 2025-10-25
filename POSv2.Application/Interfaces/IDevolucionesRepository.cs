using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;

namespace POSv2.Application.Interfaces
{
    public interface IDevolucionesRepository
    {
        IEnumerable<Devolucion> GetFiltered(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string usuario,
            double? montoMin,
            double? montoMax);
        // ... otros métodos
    }
}
