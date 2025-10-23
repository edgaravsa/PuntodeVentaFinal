public interface ICustomerDisplayService
{
    bool IsAvailable { get; }
    void ShowTotal(decimal total);
    void ShowMessage(string message);
}