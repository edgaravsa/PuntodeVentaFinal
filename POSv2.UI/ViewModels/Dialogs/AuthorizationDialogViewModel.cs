using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POSv2.Application.Interfaces;
using POSv2.Domain.Entities;

public partial class AuthorizationDialogViewModel : ObservableObject
{
    private readonly IAuthenticationService authService;
    private readonly string requiredRole;
    public Employee? AuthorizedEmployee { get; private set; }
    [ObservableProperty] private string username;
    [ObservableProperty] private string password;
    [ObservableProperty] private string errorMessage;
    public IRelayCommand AuthorizeCommand { get; }
    public IRelayCommand CancelCommand { get; }
    public event Action<bool, Employee?>? DialogResult;

    public AuthorizationDialogViewModel(IAuthenticationService authService, string requiredRole = null)
    {
        this.authService = authService;
        this.requiredRole = requiredRole;
        AuthorizeCommand = new RelayCommand(Authorize);
        CancelCommand = new RelayCommand(Cancel);
    }

    private void Authorize()
    {
        if (authService.Authenticate(Username, Password, out var employee))
        {
            if (requiredRole == null || employee.Role == requiredRole || employee.Role == "Administrador")
            {
                AuthorizedEmployee = employee;
                DialogResult?.Invoke(true, AuthorizedEmployee);
            }
            else
            {
                ErrorMessage = "No tienes permisos para esta acción.";
            }
        }
        else
        {
            ErrorMessage = "Usuario o contraseña incorrectos.";
        }
    }

    private void Cancel()
    {
        DialogResult?.Invoke(false, null);
    }
}