using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.IService;
using WebApplication1.Modals;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmOrderController : ControllerBase
    {
        private IConfirmOrderService _confirmOrderService;

        public ConfirmOrderController(IConfirmOrderService confirmOrderService)
        {
            _confirmOrderService = confirmOrderService;
        }

        [HttpPost("ConfirmOrder")]
        public IActionResult AddConfirmOrder(ConfirmOrderRequest confirmOrderRequest)
        {
            try
            {
                var data = _confirmOrderService.AddConfirmOrder(confirmOrderRequest);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet ("ConfirmOrder")]
        public IActionResult GetConfirmOrders()
        {
            try
            {
                var data = _confirmOrderService.GetConfirmOrders();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete ("ConfirmOrder")]
        public IActionResult DeleteConfirmOrder(Guid confirmOrderId)
        {
            var data = _confirmOrderService.DeleteConfirmOrder(confirmOrderId);
            return Ok(data);
        }


        [HttpPut ("confirmorder")]
        public IActionResult UpdateConfirmorder(ConfirmOrderRequest confirmOrderRequest, Guid confirmorderId)
        {
            try
            {
                var data = _confirmOrderService.UpdateConfirmorder(confirmOrderRequest, confirmorderId);
                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
