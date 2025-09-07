using Application.DTOs;

namespace Application.Interfaces
{
    public interface IGetOrders
    {
        OrderDTO GetOrder(int orderId);
    }
}