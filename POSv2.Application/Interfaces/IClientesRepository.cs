using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;

namespace POSv2.Application.Interfaces
{
    public interface IClientesRepository
    {
        IEnumerable<Cliente> GetFiltered(
            string estado,
            string usuario);
        // ... otros métodos
    }
}
