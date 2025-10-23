public class ClientesRepository : IClientesRepository
{
    private readonly List<Cliente> clientes;

    public IEnumerable<Cliente> GetFiltered(string estado, string usuario)
    {
        var query = clientes.AsQueryable();
        if (!string.IsNullOrEmpty(estado))
            query = query.Where(c => c.IsActive ? estado == "Activo" : estado == "Inactivo");
        if (!string.IsNullOrEmpty(usuario))
            query = query.Where(c => c.Nombre.Contains(usuario));
        return query.ToList();
    }
}