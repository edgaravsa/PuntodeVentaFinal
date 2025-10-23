public class ProductosRepository : IProductosRepository
{
    private readonly List<Producto> productos;

    public IEnumerable<Producto> GetFiltered(string categoria, string estado, int? stockMin, int? stockMax)
    {
        var query = productos.AsQueryable();
        if (!string.IsNullOrEmpty(categoria))
            query = query.Where(p => p.Categoria == categoria);
        if (!string.IsNullOrEmpty(estado))
            query = query.Where(p => p.Estado == estado);
        if (stockMin.HasValue)
            query = query.Where(p => p.Stock >= stockMin.Value);
        if (stockMax.HasValue)
            query = query.Where(p => p.Stock <= stockMax.Value);
        return query.ToList();
    }
}