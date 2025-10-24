namespace POSv2.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetFiltered(
            string rol,
            string estado,
            string usuario);
        // ... otros métodos
    }
}
