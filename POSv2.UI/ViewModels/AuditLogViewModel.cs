using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POSv2.Application.Interfaces;
using POSv2.Domain.Entities;
using System.Collections.ObjectModel;

public partial class AuditLogViewModel : ObservableObject
{
    private readonly IAuditService auditService;

    [ObservableProperty] private ObservableCollection<AuditLog> logs = new();
    [ObservableProperty] private string filterUser;
    [ObservableProperty] private string filterModule;
    [ObservableProperty] private string filterAction;
    [ObservableProperty] private DateTime? filterFromDate;
    [ObservableProperty] private DateTime? filterToDate;
    [ObservableProperty] private int currentPage = 1;
    [ObservableProperty] private int pageSize = 50;
    [ObservableProperty] private int totalPages = 1;

    public IRelayCommand SearchCommand { get; }
    public IRelayCommand ExportCommand { get; }
    public IRelayCommand NextPageCommand { get; }
    public IRelayCommand PrevPageCommand { get; }

    public AuditLogViewModel(IAuditService auditService)
    {
        this.auditService = auditService;
        SearchCommand = new RelayCommand(LoadLogs);
        ExportCommand = new RelayCommand(ExportLogs);
        NextPageCommand = new RelayCommand(NextPage);
        PrevPageCommand = new RelayCommand(PrevPage);
        LoadLogs();
    }

    private void LoadLogs()
    {
        var allLogs = auditService.GetFilteredLogs(filterUser, filterModule, filterAction, filterFromDate, filterToDate);
        totalPages = (int)Math.Ceiling(allLogs.Count() / (double)pageSize);
        currentPage = Math.Max(1, Math.Min(currentPage, totalPages));
        logs.Clear();
        foreach (var log in allLogs.Skip((currentPage - 1) * pageSize).Take(pageSize))
            logs.Add(log);
    }

    private void NextPage()
    {
        if (currentPage < totalPages)
        {
            currentPage++;
            LoadLogs();
        }
    }

    private void PrevPage()
    {
        if (currentPage > 1)
        {
            currentPage--;
            LoadLogs();
        }
    }

    private void ExportLogs()
    {
        var allLogs = auditService.GetFilteredLogs(filterUser, filterModule, filterAction, filterFromDate, filterToDate);
        ExportToCsv(allLogs);
    }

    private void ExportToCsv(IEnumerable<AuditLog> logs)
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Fecha/Hora,Usuario,Módulo,Acción,Detalle");
        foreach (var log in logs)
        {
            sb.AppendLine($"\"{log.Timestamp:yyyy-MM-dd HH:mm:ss}\",\"{log.UserId}\",\"{log.Module}\",\"{log.Action}\",\"{log.Details}\"");
        }
        System.IO.File.WriteAllText("auditoria_export.csv", sb.ToString());
        // Mejorar: preguntar al usuario la ruta y mostrar mensaje de éxito
    }
}