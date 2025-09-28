namespace Application.DTOs
{
    public class OrderDetailsDTO
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = null!;
        public DateOnly OrderDate { get; set; }

        public List<OrderProductDTO> Products { get; set; } = new();
    }
}