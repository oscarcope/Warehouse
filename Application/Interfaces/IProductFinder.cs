using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductFinder
    {
        OrderDetailsDTO GetOrderDetails(int orderId);
    }
}