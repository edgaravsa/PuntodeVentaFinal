public class ProductsViewModel : AuthorizedViewModel
{
    private readonly IProductService productService;

    public ProductsViewModel(
        IAuthenticationService authService,
        IAuditService auditService,
        IProductService productService
    ) : base(authService, auditService)
    {
        this.productService = productService;
    }

    public async Task EditProduct(Product product, string newName)
    {
        var employee = await RequestAuthorization("Gerente");
        if (employee == null) return;
        product.Name = newName;
        productService.UpdateProduct(product);
        RegisterAudit(employee, "Productos", "Edición", $"Producto {product.Id} cambiado a '{newName}'");
    }

    public async Task AddProduct(Product product)
    {
        var employee = await RequestAuthorization("Gerente");
        if (employee == null) return;
        productService.AddProduct(product);
        RegisterAudit(employee, "Productos", "Alta", $"Nuevo producto {product.Id}: '{product.Name}'");
    }

    public async Task DeleteProduct(Product product)
    {
        var employee = await RequestAuthorization("Administrador");
        if (employee == null) return;
        productService.DeleteProduct(product.Id);
        RegisterAudit(employee, "Productos", "Baja", $"Producto {product.Id} eliminado");
    }
}