public class ConfigurationViewModel : AuthorizedViewModel
{
    private readonly IConfigService configService;

    public ConfigurationViewModel(
        IAuthenticationService authService,
        IAuditService auditService,
        IConfigService configService
    ) : base(authService, auditService)
    {
        this.configService = configService;
    }

    public async Task SaveSettings(SystemConfig config)
    {
        var employee = await RequestAuthorization("Administrador");
        if (employee == null) return;
        configService.Save(config);
        RegisterAudit(employee, "Configuración", "Modificación", $"Configuración modificada por {employee.Username}");
    }
}