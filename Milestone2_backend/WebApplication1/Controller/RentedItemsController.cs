using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.IService;
using WebApplication1.Service;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedItemsController : ControllerBase
    {
        private IRentedItemsService _itemsService;

        public RentedItemsController(IRentedItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpPost("RentedItem")]
        public IActionResult AddRentedItems(RentedItemsRequest item)
        {
            try
            {
                var Returndata = _itemsService.AddRentedItems(item);
                return Ok(Returndata);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllRentedItem")]
        public IActionResult GetRentedItems()
        {
            try
            {
                var Returndata = _itemsService.GetAllRentedItems();
                return Ok(Returndata);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RentedItem")]
        public async Task<IActionResult> UpdateRentedItems(Guid id, RentedItemsRequest item)
        {
            try
            {
                var Returndata = await _itemsService.UpdateRentedItem(id, item);
                return Ok(Returndata);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteRentedItem")]
        public IActionResult DeleteRentedItems(Guid Id)
        {
            try
            {
                var Returndata = _itemsService.DeleteRentedItem(Id);
                return Ok(Returndata);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
