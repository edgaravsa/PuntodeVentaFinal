public class ReturnsViewModel : AuthorizedViewModel
{
    private readonly IReturnService returnService;

    public ReturnsViewModel(
        IAuthenticationService authService,
        IAuditService auditService,
        IReturnService returnService
    ) : base(authService, auditService)
    {
        this.returnService = returnService;
    }

    public async Task CancelOrder(Guid orderId, string reason)
    {
        var employee = await RequestAuthorization("Gerente");
        if (employee == null) return;
        returnService.CancelOrder(orderId, reason, employee.Id);
        RegisterAudit(employee, "Devoluciones", "Cancelación", $"Orden {orderId} cancelada. Motivo: {reason}");
    }

    public async Task ReturnItems(Guid orderId, List<ReturnItem> items, string reason)
    {
        var employee = await RequestAuthorization("Gerente");
        if (employee == null) return;
        returnService.ReturnItems(orderId, items, reason, employee.Id);
        RegisterAudit(employee, "Devoluciones", "Devolución", $"Orden {orderId} devolución parcial por {employee.Username}");
    }
}