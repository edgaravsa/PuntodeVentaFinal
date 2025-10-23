public interface IEmployeeRepository
{
    IEnumerable<Employee> GetFiltered(
        string rol,
        string estado,
        string usuario);
    // ... otros métodos
}