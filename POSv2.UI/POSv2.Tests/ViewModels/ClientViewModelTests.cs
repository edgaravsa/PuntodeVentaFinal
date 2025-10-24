using Xunit;
using FluentAssertions;
using POSv2.UI.ViewModels.Clients;
using POSv2.Domain.Entities;
using Moq;
using POSv2.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POSv2.Tests.ViewModels
{
    public class ClientViewModelTests
    {
        private ClientViewModel GetViewModel(List<Client>? clients = null)
        {
            var clientService = new Mock<IClientService>();
            clients ??= new List<Client>
            {
                new Client { Id = System.Guid.NewGuid(), Name = "Ana", LastName = "Gómez", ClientNumber = 1, Email = "ana@correo.com" }
            };
            clientService.Setup(x => x.GetAllClientsAsync()).ReturnsAsync(clients);
            clientService.Setup(x => x.AddClientAsync(It.IsAny<Client>())).Returns(Task.CompletedTask);
            clientService.Setup(x => x.UpdateClientAsync(It.IsAny<Client>())).Returns(Task.CompletedTask);
            clientService.Setup(x => x.DeleteClientAsync(It.IsAny<System.Guid>())).Returns(Task.CompletedTask);

            return new ClientViewModel(clientService.Object);
        }

        [Fact]
        public async Task AddClientCommand_ShouldAddClient()
        {
            var vm = GetViewModel();
            vm.ClientNumber = 2;
            vm.Name = "Pedro";
            vm.LastName = "López";
            vm.Phone = "5551234567";
            vm.Email = "pedro@correo.com";
            await vm.AddClientCommand.ExecuteAsync(null);

            vm.Clients.Should().Contain(c => c.Email == "pedro@correo.com");
        }

        [Fact]
        public async Task EditClientCommand_ShouldUpdateClient()
        {
            var vm = GetViewModel();
            var client = vm.Clients[0];
            vm.SelectedClient = client;
            vm.Name = "Anita";
            await vm.EditClientCommand.ExecuteAsync(null);

            vm.Clients[0].Name.Should().Be("Anita");
        }

        [Fact]
        public async Task DeleteClientCommand_ShouldRemoveClient()
        {
            var vm = GetViewModel();
            var client = vm.Clients[0];
            vm.SelectedClient = client;
            await vm.DeleteClientCommand.ExecuteAsync(null);

            vm.Clients.Should().NotContain(c => c.Email == "ana@correo.com");
        }
    }
}