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
        private readonly IBatchMover _batchMover;
        private readonly IProductFinder _productFinder;

        public WarehouseController(
            IGetOrders orderGetter,
            IBatchMover batchMover,
            IProductFinder productFinder)
        {
            _orderGetter = orderGetter;
            _batchMover = batchMover;
            _productFinder = productFinder;
        }

        [HttpGet("{orderId}")]
        public ActionResult<OrderDTO> Get(int orderId)
        {
            var order = _orderGetter.GetOrder(orderId);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost("MoveBatch")]
        public IActionResult MoveBatch([FromBody] MoveBatchDto dto)
        {
            if (dto == null)
                return BadRequest();

            try
            {
                _batchMover.MoveBatch(dto);
                return Ok("Batch moved successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("OrderDetails/{orderId}")]
        public ActionResult<OrderDetailsDTO> GetOrderDetails(int orderId)
        {
            try
            {
                var details = _productFinder.GetOrderDetails(orderId);
                return Ok(details);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
