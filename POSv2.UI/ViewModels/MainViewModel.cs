using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POSv2.UI.ViewModels.Cashier;
using POSv2.UI.ViewModels.Products;
using POSv2.UI.ViewModels.Employees;
using POSv2.UI.ViewModels.Clients;
using POSv2.UI.ViewModels.Configuration;
using POSv2.UI.ViewModels.Export;
using POSv2.UI.ViewModels.Inventory;
using System;

namespace POSv2.UI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty] private object? currentViewModel;

        public CashierViewModel CashierVM { get; }
        public ProductViewModel ProductVM { get; }
        public EmployeeViewModel EmployeeVM { get; }
        public ClientViewModel ClientVM { get; }
        public ConfigurationViewModel ConfigVM { get; }
        public ExportViewModel ExportVM { get; }
        public InventoryViewModel InventoryVM { get; }

        public IRelayCommand ShowCashierCommand { get; }
        public IRelayCommand ShowProductsCommand { get; }
        public IRelayCommand ShowEmployeesCommand { get; }
        public IRelayCommand ShowClientsCommand { get; }
        public IRelayCommand ShowConfigurationCommand { get; }
        public IRelayCommand ShowExportCommand { get; }
        public IRelayCommand ShowInventoryCommand { get; }

        public MainViewModel(
            CashierViewModel cashierVM,
            ProductViewModel productVM,
            EmployeeViewModel employeeVM,
            ClientViewModel clientVM,
            ConfigurationViewModel configVM,
            ExportViewModel exportVM,
            InventoryViewModel inventoryVM)
        {
            CashierVM = cashierVM;
            ProductVM = productVM;
            EmployeeVM = employeeVM;
            ClientVM = clientVM;
            ConfigVM = configVM;
            ExportVM = exportVM;
            InventoryVM = inventoryVM;

            ShowCashierCommand = new RelayCommand(() => CurrentViewModel = CashierVM);
            ShowProductsCommand = new RelayCommand(() => CurrentViewModel = ProductVM);
            ShowEmployeesCommand = new RelayCommand(() => CurrentViewModel = EmployeeVM);
            ShowClientsCommand = new RelayCommand(() => CurrentViewModel = ClientVM);
            ShowConfigurationCommand = new RelayCommand(() => CurrentViewModel = ConfigVM);
            ShowExportCommand = new RelayCommand(() => CurrentViewModel = ExportVM);
            ShowInventoryCommand = new RelayCommand(() => CurrentViewModel = InventoryVM);

            // Muestra el módulo de caja por defecto
            CurrentViewModel = CashierVM;
        }
    }
}