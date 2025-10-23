public class CashViewModel : AuthorizedViewModel
{
    private readonly IPrinterService printer;

    public CashViewModel(Employee currentUser, IPrinterService printerService)
        : base(currentUser)
    {
        this.printer = printerService;
    }

    public void ImprimirTicket(string texto)
    {
        printer.Print(texto); // Usará el simulado o real según el modo
    }
}