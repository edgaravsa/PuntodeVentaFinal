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
