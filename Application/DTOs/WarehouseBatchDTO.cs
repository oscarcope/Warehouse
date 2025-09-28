namespace Application.DTOs
{
    public class WarehouseBatchDTO
    {
        public int WarehouseBatchId { get; set; }
        public int LocationId { get; set; }
        public string LocationNumber { get; set; } = null!;
        public int QuantityAvailable { get; set; }
    }
}