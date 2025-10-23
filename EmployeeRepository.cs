public class EmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> empleados;

    public IEnumerable<Employee> GetFiltered(string rol, string estado, string usuario)
    {
        var query = empleados.AsQueryable();
        if (!string.IsNullOrEmpty(rol))
            query = query.Where(e => e.Role == rol);
        if (!string.IsNullOrEmpty(estado))
            query = query.Where(e => e.IsActive ? estado == "Activo" : estado == "Inactivo");
        if (!string.IsNullOrEmpty(usuario))
            query = query.Where(e => e.Username.Contains(usuario));
        return query.ToList();
    }
}