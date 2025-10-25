using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using ClosedXML.Excel;
using System.Globalization;

public class ExportService : IExportService
{
    public void ExportToCsv<T>(IEnumerable<T> data, string filePath)
    {
        using var writer = new StreamWriter(filePath);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(data);
    }

    public void ExportToExcel<T>(IEnumerable<T> data, string filePath)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Reporte");

        var props = typeof(T).GetProperties();
        for (int i = 0; i < props.Length; i++)
            worksheet.Cell(1, i + 1).Value = props[i].Name;

        int row = 2;
        foreach (var item in data)
        {
            for (int col = 0; col < props.Length; col++)
                worksheet.Cell(row, col + 1).Value = props[col].GetValue(item)?.ToString();
            row++;
        }
        workbook.SaveAs(filePath);
    }
}