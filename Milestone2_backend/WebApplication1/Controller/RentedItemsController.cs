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

        [HttpPost("Rented_Item")]
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

        [HttpGet("Get_All_Item")]
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

        [HttpDelete("Delete_Rented_Item")]
        public IActionResult DeleteRentedItems(Guid Id)
        {
            try
            {
                var Returndata = _itemsService.GetRentedItems(Id);
                return Ok(Returndata);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
