public class MainWindowViewModel : ObservableObject
{
    // El usuario autenticado
    public Employee CurrentUser { get; }
    public UsersViewModel UsersVm { get; }
    public IRelayCommand ShowUsersCommand { get; }
    public object CurrentViewModel { get; private set; } // <- Agregada propiedad

    public MainWindowViewModel(Employee currentUser, UsersViewModel usersVm)
    {
        CurrentUser = currentUser;
        UsersVm = usersVm;
        ShowUsersCommand = new RelayCommand(ShowUsers, CanShowUsers);
    }

    private void ShowUsers()
    {
        CurrentViewModel = UsersVm;
    }

    private bool CanShowUsers()
    {
        return CurrentUser != null && CurrentUser.Role == "Administrador";
    }
}