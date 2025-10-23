public class ReportViewModel : ObservableObject
{
    private readonly IExportService exportService;

    [ObservableProperty] private ObservableCollection<ReportItem> items = new();
    [ObservableProperty] private string selectedFormat = "CSV";

    public IRelayCommand ExportCommand { get; }

    public ReportViewModel(IExportService exportService)
    {
        this.exportService = exportService;
        ExportCommand = new RelayCommand(Export);
    }

    private void Export()
    {
        var dialog = new SaveFileDialog();
        dialog.Filters.Add(new FileDialogFilter() { Name = "CSV", Extensions = { "csv" } });
        dialog.Filters.Add(new FileDialogFilter() { Name = "Excel", Extensions = { "xlsx" } });
        // PDF opcional

        var filePath = dialog.ShowAsync();
        if (string.IsNullOrWhiteSpace(filePath)) return;

        switch (selectedFormat)
        {
            case "CSV":
                exportService.ExportToCsv(items, filePath);
                break;
            case "Excel":
                exportService.ExportToExcel(items, filePath);
                break;
            // PDF opcional
        }
    }
}