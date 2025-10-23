public interface IClientesRepository
{
    IEnumerable<Cliente> GetFiltered(
        string estado,
        string usuario);
    // ... otros métodos
}