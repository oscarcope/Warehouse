using Application.DTOs;
using Application.Interfaces;
using DataAccess;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class OrderGetter : IGetOrders
    {
        private readonly WarehouseDbContext _context;

        public OrderGetter(WarehouseDbContext context)
        {
            _context = context;
        }

        public OrderDTO GetOrder(int orderId)
        {
            var orderDto = _context.Orders
                .Where(o => o.OrderId == orderId)
                .Select(o => new OrderDTO
                {
                    OrderId = o.OrderId,
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.OrderDate,
                    TotalItems = o.OrderItems.Sum(oi => oi.Quantity)
                })
                .FirstOrDefault();

            return orderDto;
        }
    }
}