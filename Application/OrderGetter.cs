using Application.DTOs;
using Application.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class OrderGetter : IGetOrders
    {
        private readonly IGenericRepository<Order> _orderRepo;

        public OrderGetter(IGenericRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public OrderDTO GetOrder(int orderId)
        {
            var orderDto = _orderRepo.Get (o => o.OrderId == orderId)
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