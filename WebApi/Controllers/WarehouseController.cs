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

        public WarehouseController(IGetOrders orderGetter, IBatchMover batchMover)
        {
            _orderGetter = orderGetter;
            _batchMover = batchMover;
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
    }
}
