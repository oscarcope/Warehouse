namespace Application.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = null!;
        public DateOnly OrderDate { get; set; }
        public int TotalItems { get; set; } // sum of all OrderItem quantities
    }
}
