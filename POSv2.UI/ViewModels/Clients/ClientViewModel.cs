using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace POSv2.UI.ViewModels.Clients
{
    public partial class ClientViewModel : ObservableObject
    {
        private readonly IClientService clientService;

        [ObservableProperty] private ObservableCollection<Client> clients = new();
        [ObservableProperty] private Client? selectedClient;

        // Propiedades para alta/edición
        [ObservableProperty] private int clientNumber;
        [ObservableProperty] private string name = "";
        [ObservableProperty] private string lastName = "";
        [ObservableProperty] private string phone = "";
        [ObservableProperty] private string email = "";

        public IRelayCommand AddClientCommand { get; }
        public IRelayCommand EditClientCommand { get; }
        public IRelayCommand DeleteClientCommand { get; }
        public IRelayCommand SearchClientsCommand { get; }
        public IRelayCommand ClearFormCommand { get; }

        public ClientViewModel(IClientService clientService)
        {
            this.clientService = clientService;
            AddClientCommand = new RelayCommand(async () => await AddClientAsync());
            EditClientCommand = new RelayCommand(async () => await EditClientAsync());
            DeleteClientCommand = new RelayCommand(async () => await DeleteClientAsync());
            SearchClientsCommand = new RelayCommand(async () => await SearchClientsAsync());
            ClearFormCommand = new RelayCommand(ClearForm);

            _ = SearchClientsAsync();
        }

        private async Task AddClientAsync()
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                ClientNumber = ClientNumber,
                Name = Name,
                LastName = LastName,
                Phone = Phone,
                Email = Email
            };
            await clientService.AddClientAsync(client);
            await SearchClientsAsync();
            ClearForm();
        }

        private async Task EditClientAsync()
        {
            if (SelectedClient == null) return;
            SelectedClient.ClientNumber = ClientNumber;
            SelectedClient.Name = Name;
            SelectedClient.LastName = LastName;
            SelectedClient.Phone = Phone;
            SelectedClient.Email = Email;

            await clientService.UpdateClientAsync(SelectedClient);
            await SearchClientsAsync();
            ClearForm();
        }

        private async Task DeleteClientAsync()
        {
            if (SelectedClient == null) return;
            await clientService.DeleteClientAsync(SelectedClient.Id);
            await SearchClientsAsync();
            ClearForm();
        }

        private async Task SearchClientsAsync()
        {
            var list = await clientService.GetAllClientsAsync();
            Clients = new ObservableCollection<Client>(list);
        }

        private void ClearForm()
        {
            ClientNumber = 0;
            Name = "";
            LastName = "";
            Phone = "";
            Email = "";
            SelectedClient = null;
        }
    }
}