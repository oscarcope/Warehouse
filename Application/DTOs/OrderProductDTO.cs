namespace Application.DTOs
{
    public class OrderProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public int QuantityNeeded { get; set; }
        public List<WarehouseBatchDTO> Batches { get; set; } = new();
    }
}