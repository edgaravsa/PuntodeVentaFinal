using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace POSv2.UI.ViewModels.Employees
{
    public partial class EmployeeViewModel : ObservableObject
    {
        private readonly IEmployeeService employeeService;

        [ObservableProperty] private ObservableCollection<Employee> employees = new();
        [ObservableProperty] private Employee? selectedEmployee;

        // Propiedades para alta/edición
        [ObservableProperty] private int employeeNumber;
        [ObservableProperty] private string name = "";
        [ObservableProperty] private string username = "";
        [ObservableProperty] private EmployeeRole role = EmployeeRole.Cashier;
        [ObservableProperty] private string password = "";
        [ObservableProperty] private string confirmPassword = "";

        public IRelayCommand AddEmployeeCommand { get; }
        public IRelayCommand EditEmployeeCommand { get; }
        public IRelayCommand DeleteEmployeeCommand { get; }
        public IRelayCommand SearchEmployeesCommand { get; }
        public IRelayCommand ClearFormCommand { get; }

        public EmployeeViewModel(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
            AddEmployeeCommand = new RelayCommand(async () => await AddEmployeeAsync());
            EditEmployeeCommand = new RelayCommand(async () => await EditEmployeeAsync());
            DeleteEmployeeCommand = new RelayCommand(async () => await DeleteEmployeeAsync());
            SearchEmployeesCommand = new RelayCommand(async () => await SearchEmployeesAsync());
            ClearFormCommand = new RelayCommand(ClearForm);

            _ = SearchEmployeesAsync();
        }

        private async Task AddEmployeeAsync()
        {
            if (Password != ConfirmPassword || string.IsNullOrWhiteSpace(Password)) return;

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                EmployeeNumber = EmployeeNumber,
                Name = Name,
                Username = Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password),
                Role = Role
            };
            await employeeService.AddEmployeeAsync(employee);
            await SearchEmployeesAsync();
            ClearForm();
        }

        private async Task EditEmployeeAsync()
        {
            if (SelectedEmployee == null) return;
            SelectedEmployee.EmployeeNumber = EmployeeNumber;
            SelectedEmployee.Name = Name;
            SelectedEmployee.Username = Username;
            SelectedEmployee.Role = Role;
            if (!string.IsNullOrWhiteSpace(Password) && Password == ConfirmPassword)
                SelectedEmployee.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);

            await employeeService.UpdateEmployeeAsync(SelectedEmployee);
            await SearchEmployeesAsync();
            ClearForm();
        }

        private async Task DeleteEmployeeAsync()
        {
            if (SelectedEmployee == null) return;
            await employeeService.DeleteEmployeeAsync(SelectedEmployee.Id);
            await SearchEmployeesAsync();
            ClearForm();
        }

        private async Task SearchEmployeesAsync()
        {
            var list = await employeeService.GetAllEmployeesAsync();
            Employees = new ObservableCollection<Employee>(list);
        }

        private void ClearForm()
        {
            EmployeeNumber = 0;
            Name = "";
            Username = "";
            Role = EmployeeRole.Cashier;
            Password = "";
            ConfirmPassword = "";
            SelectedEmployee = null;
        }
    }
}