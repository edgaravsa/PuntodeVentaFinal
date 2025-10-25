namespace POSv2.Domain.Entities
{
    public class ReturnOrCancellation
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public List<ReturnItem> Items { get; set; } = new();
        public DateTime Date { get; set; }
        public string Reason { get; set; } = "";
        public string EmployeeId { get; set; }
        public bool IsCancellation { get; set; } // true = cancelación total, false = devolución parcial
    }
}
