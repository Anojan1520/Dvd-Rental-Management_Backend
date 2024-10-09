using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.IService;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("Notification")]
        public IActionResult AddNotification(NotificationRequest notification)
        {
            try
            {
                var ReturnData = _notificationService.AddNotification(notification);
                return Ok(ReturnData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All_Notification")]
        public IActionResult GetNotifications()
        {
            try
            {
                var data = _notificationService.GetNotifications();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Notification")]
        public IActionResult DeleteNotification(Guid notificationId)
        {
            try
            {
                var data = _notificationService.DeleteNotification(notificationId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("Notification")]
        public IActionResult UpdateNotification(NotificationRequest notificationRequest, Guid notificationId)
        {
            try
            {
                var data = _notificationService.UpdateNotification(notificationRequest, notificationId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }
    }
}
