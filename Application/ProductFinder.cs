using Application.DTOs;
using Application.Interfaces;
using DataAccess.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application
{
    public class ProductFinder : IProductFinder
    {
        private readonly IGenericRepository<Order> _orderRepo;

        public ProductFinder(IGenericRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public OrderDetailsDTO GetOrderDetails(int orderId)
        {
            var order = _orderRepo.Get(o => o.OrderId == orderId)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Batch)
                        .ThenInclude(b => b.ManufacturingLot)
                            .ThenInclude(ml => ml.Product)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.OrderItemLocations)
                        .ThenInclude(oil => oil.WarehouseBatch)
                            .ThenInclude(wb => wb.Location)
                .FirstOrDefault();

            if (order == null)
                throw new System.Exception("Order not found");

            return new OrderDetailsDTO
            {
                OrderId = order.OrderId,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                Products = order.OrderItems.Select(orderItem =>
                {
                    var batches = orderItem.OrderItemLocations
                        .Select(oil => oil.WarehouseBatch)
                        .Where(wb => wb != null)
                        .OrderBy(wb => wb.Quantity)
                        .Select(wb => new WarehouseBatchDTO
                        {
                            WarehouseBatchId = wb.WarehouseBatchId,
                            LocationId = wb.LocationId,
                            LocationNumber = wb.Location.LocationNumber,
                            QuantityAvailable = wb.Quantity
                        })
                        .ToList();

                    return new OrderProductDTO
                    {
                        ProductId = orderItem.Product.ProductId,
                        Name = orderItem.Product.Name,
                        QuantityNeeded = orderItem.Quantity,
                        Batches = batches
                    };
                }).ToList()
            };
        }
    }
}
