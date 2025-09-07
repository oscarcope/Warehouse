using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IGetOrders _orderGetter;

        public WarehouseController(IGetOrders orderGetter)
        {
            _orderGetter = orderGetter;
        }

        [HttpGet("{orderId}")]
        public ActionResult<OrderDTO> Get(int orderId)
        {
            var order = _orderGetter.GetOrder(orderId);
            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}
