namespace Application.DTOs
{
    public class MoveBatchDto
    {
        public int WarehouseBatchId { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public int Quantity { get; set; } // 0 = create a new batch, otherwise move quantity
    }
}
