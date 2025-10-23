public class InventoryViewModel : AuthorizedViewModel
{
    private readonly IInventoryService inventoryService;

    public InventoryViewModel(
        IAuthenticationService authService,
        IAuditService auditService,
        IInventoryService inventoryService
    ) : base(authService, auditService)
    {
        this.inventoryService = inventoryService;
    }

    public async Task AdjustStock(Product product, int newQty)
    {
        var employee = await RequestAuthorization("Administrador");
        if (employee == null) return;
        inventoryService.AdjustStock(product.Id, newQty);
        RegisterAudit(employee, "Inventario", "Ajuste", $"Stock de {product.Name} ajustado a {newQty}");
    }
}