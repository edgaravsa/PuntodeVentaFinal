using Xunit;
using FluentAssertions;
using POSv2.UI.ViewModels.Export;
using POSv2.Domain.Entities;
using Moq;
using POSv2.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace POSv2.Tests.ViewModels
{
    public class ExportViewModelTests
    {
        private ExportViewModel GetViewModel(List<Order>? orders = null)
        {
            var exportService = new Mock<IExportService>();
            orders ??= new List<Order>
            {
                new Order { Id = Guid.NewGuid(), Date = DateTime.Today, Total = 100, Branch = "Sucursal", PaymentType = PaymentType.Cash }
            };
            exportService.Setup(x => x.ExportOrdersAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>())).ReturnsAsync(orders);

            return new ExportViewModel(exportService.Object);
        }

        [Fact]
        public async Task ExportOrdersCommand_ShouldLoadExportedOrders()
        {
            var vm = GetViewModel();
            vm.StartDate = DateTime.Today.AddDays(-2);
            vm.EndDate = DateTime.Today;
            vm.ExportFilePath = "ventas.csv";

            await vm.ExportOrdersCommand.ExecuteAsync(null);

            vm.ExportedOrders.Should().ContainSingle(o => o.Total == 100 && o.Branch == "Sucursal");
        }

        [Fact]
        public void ClearExportCommand_ShouldResetExportViewModel()
        {
            var vm = GetViewModel();
            vm.ExportFilePath = "ventas.csv";
            vm.ExportedOrders.Add(new Order { Total = 50 });
            vm.ClearExportCommand.Execute(null);

            vm.ExportFilePath.Should().BeEmpty();
            vm.ExportedOrders.Should().BeEmpty();
        }
    }
}