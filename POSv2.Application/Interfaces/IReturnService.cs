public interface IReturnService
{
    Task CancelOrderAsync(Guid orderId, string reason, string employeeId);
    Task ReturnItemsAsync(Guid orderId, List<ReturnItem> items, string reason, string employeeId);
    Task<List<ReturnOrCancellation>> GetReturnsAndCancellationsAsync(DateTime? from = null, DateTime? to = null);
}