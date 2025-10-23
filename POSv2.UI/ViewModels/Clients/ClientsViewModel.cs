public class ClientsViewModel
{
    private readonly IClientService clientService;
    private readonly IAuditService auditService;

    public ClientsViewModel(
        IClientService clientService,
        IAuditService auditService
    )
    {
        this.clientService = clientService;
        this.auditService = auditService;
    }

    public void EditClient(Client client, string newName, string loggedEmployeeId)
    {
        client.Name = newName;
        clientService.UpdateClient(client);
        auditService.Register(loggedEmployeeId, "Clientes", "Edición", $"Cliente {client.Id} cambiado a '{newName}'");
    }
}