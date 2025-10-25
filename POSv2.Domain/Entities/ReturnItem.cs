namespace POSv2.Domain.Entities
{
    public class ReturnItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}