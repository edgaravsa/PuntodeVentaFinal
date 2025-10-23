using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POSv2.Application.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

public partial class ExportViewModel : ObservableObject
{
    private readonly IVentasRepository ventasRepo;
    private readonly IProductosRepository productosRepo;
    private readonly IEmployeeRepository employeeRepo;
    private readonly IAuditRepository auditRepo;
    private readonly IClientesRepository clientesRepo;
    private readonly IDevolucionesRepository devolucionesRepo;
    private readonly IExportService exportService;

    [ObservableProperty] private string selectedBase;
    [ObservableProperty] private ObservableCollection<object> items = new();
    [ObservableProperty] private string selectedFormat = "CSV";

    // Filtros dinámicos
    [ObservableProperty] private DateTime? filtroFechaInicio;
    [ObservableProperty] private DateTime? filtroFechaFin;
    [ObservableProperty] private string filtroUsuario;
    [ObservableProperty] private string filtroMetodoPago;
    [ObservableProperty] private string filtroRol;
    [ObservableProperty] private string filtroEstado;
    [ObservableProperty] private string filtroCategoria;
    [ObservableProperty] private double? filtroMontoMin;
    [ObservableProperty] private double? filtroMontoMax;
    [ObservableProperty] private int? filtroStockMin;
    [ObservableProperty] private int? filtroStockMax;

    public IRelayCommand LoadCommand { get; }
    public IRelayCommand ExportCommand { get; }

    public ExportViewModel(
        IVentasRepository ventasRepo,
        IProductosRepository productosRepo,
        IEmployeeRepository employeeRepo,
        IAuditRepository auditRepo,
        IClientesRepository clientesRepo,
        IDevolucionesRepository devolucionesRepo,
        IExportService exportService)
    {
        this.ventasRepo = ventasRepo;
        this.productosRepo = productosRepo;
        this.employeeRepo = employeeRepo;
        this.auditRepo = auditRepo;
        this.clientesRepo = clientesRepo;
        this.devolucionesRepo = devolucionesRepo;
        this.exportService = exportService;

        LoadCommand = new RelayCommand(LoadItems);
        ExportCommand = new RelayCommand(Export);
    }

    void LoadItems()
    {
        items.Clear();
        switch (selectedBase)
        {
            case "Ventas":
                foreach (var v in ventasRepo.GetFiltered(
                    filtroFechaInicio, filtroFechaFin, filtroUsuario, filtroMetodoPago, filtroMontoMin, filtroMontoMax))
                    items.Add(v);
                break;
            case "Productos":
                foreach (var p in productosRepo.GetFiltered(
                    filtroCategoria, filtroEstado, filtroStockMin, filtroStockMax))
                    items.Add(p);
                break;
            case "Empleados":
                foreach (var e in employeeRepo.GetFiltered(filtroRol, filtroEstado, filtroUsuario))
                    items.Add(e);
                break;
            case "Auditoría":
                foreach (var a in auditRepo.GetFiltered(
                    filtroFechaInicio, filtroFechaFin, filtroUsuario, filtroRol))
                    items.Add(a);
                break;
            case "Clientes":
                foreach (var c in clientesRepo.GetFiltered(filtroEstado, filtroUsuario))
                    items.Add(c);
                break;
            case "Devoluciones":
                foreach (var d in devolucionesRepo.GetFiltered(
                    filtroFechaInicio, filtroFechaFin, filtroUsuario, filtroMontoMin, filtroMontoMax))
                    items.Add(d);
                break;
        }
    }

    async void Export()
    {
        var dialog = new SaveFileDialog();
        dialog.Filters.Add(new FileDialogFilter() { Name = "CSV", Extensions = { "csv" } });
        dialog.Filters.Add(new FileDialogFilter() { Name = "Excel", Extensions = { "xlsx" } });
        // PDF opcional

        var filePath = await dialog.ShowAsync();
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