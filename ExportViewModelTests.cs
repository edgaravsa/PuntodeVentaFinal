using Moq;
using Xunit;

public class ExportViewModelTests
{
    [Fact]
    public void LoadCommand_LoadsFilteredVentas()
    {
        var ventasRepoMock = new Mock<IVentasRepository>();
        ventasRepoMock.Setup(r => r.GetFiltered(
            It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
            "Ana", null, null, null))
            .Returns(new[] { new Venta { Usuario = "Ana", Total = 100 } });

        var vm = new ExportViewModel(
            ventasRepoMock.Object, ...otros repositorios..., new Mock<IExportService>().Object);

        vm.SelectedBase = "Ventas";
        vm.FiltroUsuario = "Ana";
        vm.LoadCommand.Execute(null);

        Assert.Single(vm.Items);
        Assert.Equal("Ana", ((Venta)vm.Items[0]).Usuario);
    }

    [Fact]
    public void ExportCommand_InvokesServiceWithCorrectFormat()
    {
        var exportServiceMock = new Mock<IExportService>();
        var vm = new ExportViewModel(
            ...repositorios..., exportServiceMock.Object);

        vm.SelectedFormat = "CSV";
        vm.Items.Add(new Venta { Usuario = "Ana", Total = 200 });

        vm.ExportCommand.Execute(null);

        exportServiceMock.Verify(s => s.ExportToCsv(It.IsAny<IEnumerable<object>>(), It.IsAny<string>()), Times.Once);
    }
}