using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;

namespace POSv2.Application.Interfaces
{
    public interface IExportService
    {
        void ExportToCsv<T>(IEnumerable<T> data, string filePath);
        void ExportToExcel<T>(IEnumerable<T> data, string filePath);
    }
}
