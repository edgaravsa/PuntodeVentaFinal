using Xunit;
using Moq;
using POSv2.Application.Interfaces;
using System.Collections.ObjectModel;

public class VentaViewModelTests
{
    [Fact]
    public void Scanner_AddsProductToCarrito_And_DisplayShowsTotal()
    {
        // Arrange
        var scannerMock = new Mock<IBarcodeScannerService>();
        var displayMock = new Mock<IDisplayService>();
        var productosRepoMock = new Mock<IProductosRepository>();
        productosRepoMock.Setup(r => r.BuscarPorCodigo("123"))
            .Returns(new Producto { CodigoBarra = "123", Precio = 50 });

        var vm = new VentaViewModel(
            scannerMock.Object,
            productosRepoMock.Object,
            displayMock.Object
        );

        // Act
        scannerMock.Raise(s => s.BarcodeScanned += null, "123");

        // Assert
        Assert.Single(vm.Carrito);
        Assert.Equal(50, vm.TotalVenta);
        displayMock.Verify(d => d.ShowText("Total: $50.00"), Times.Once);
    }

    [Fact]
    public void Cobrar_ShowsCambioOnDisplay()
    {
        // Arrange
        var scannerMock = new Mock<IBarcodeScannerService>();
        var displayMock = new Mock<IDisplayService>();
        var productosRepoMock = new Mock<IProductosRepository>();
        var vm = new VentaViewModel(scannerMock.Object, productosRepoMock.Object, displayMock.Object);

        vm.Carrito.Add(new Producto { Precio = 100 });
        vm.TotalVenta = 100;

        // Act
        vm.Cobrar(150);

        // Assert
        Assert.Equal(50, vm.Cambio);
        displayMock.Verify(d => d.ShowText("Cambio: $50.00"), Times.Once);
    }
}