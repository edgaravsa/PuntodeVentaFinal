using Xunit;
using System.IO;

public class ExportServiceTests
{
    [Fact]
    public void ExportToCsv_CreatesFileWithData()
    {
        var service = new ExportService();
        var data = new List<Venta> { new Venta { Usuario = "Ana", Total = 150 } };
        var filePath = "test_export.csv";
        service.ExportToCsv(data, filePath);
        Assert.True(File.Exists(filePath));
        var content = File.ReadAllText(filePath);
        Assert.Contains("Ana", content);
        File.Delete(filePath);
    }
}