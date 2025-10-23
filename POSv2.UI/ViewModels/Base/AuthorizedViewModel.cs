using POSv2.Application.Interfaces;
using POSv2.Domain.Entities;
using System.Threading.Tasks;

public abstract class AuthorizedViewModel
{
    protected readonly IAuthenticationService authService;
    protected readonly IAuditService auditService;

    protected AuthorizedViewModel(IAuthenticationService authService, IAuditService auditService)
    {
        this.authService = authService;
        this.auditService = auditService;
    }

    public async Task<Employee?> RequestAuthorization(string requiredRole = null)
    {
        var dialog = new AuthorizationDialog();
        var vm = new AuthorizationDialogViewModel(authService, requiredRole);
        dialog.DataContext = vm;

        var tcs = new TaskCompletionSource<Employee?>();
        vm.DialogResult += (authorized, employee) =>
        {
            dialog.Close();
            tcs.SetResult(authorized ? employee : null);
        };
        await dialog.ShowDialog(App.Current.ApplicationLifetime.MainWindow);
        return await tcs.Task;
    }

    public void RegisterAudit(Employee employee, string module, string action, string details)
    {
        auditService.Register(employee.Id.ToString(), module, action, details);
    }
}