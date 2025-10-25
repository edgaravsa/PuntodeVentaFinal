using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;

namespace POSv2.Application.Interfaces
{
    public interface IProductosRepository
    {
        IEnumerable<Producto> GetFiltered(
            string categoria,
            string estado,
            int? stockMin,
            int? stockMax);
        // ... otros métodos
    }
}
