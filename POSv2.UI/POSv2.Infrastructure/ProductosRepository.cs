public class ProductosRepository : IProductosRepository
{
    public Producto BuscarPorCodigo(string code)
    {
        return productos.FirstOrDefault(p => p.CodigoBarra == code);
    }
}
