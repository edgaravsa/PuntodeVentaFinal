using Xunit;
public class VentasRepositoryTests
{
    [Fact]
    public void GetFiltered_ByFecha_ReturnsCorrectResults()
    {
        var repo = new VentasRepository(); // Inicializa con datos de prueba
        var results = repo.GetFiltered(DateTime.Today, DateTime.Today, null, null, null, null);
        Assert.All(results, v => Assert.Equal(DateTime.Today, v.Fecha.Date));
    }
    // Más pruebas para usuario, método de pago, monto...
}