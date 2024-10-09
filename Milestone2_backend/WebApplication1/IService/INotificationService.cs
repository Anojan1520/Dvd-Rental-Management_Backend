using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;

namespace WebApplication1.IService
{
    public interface INotificationService
    {
        string AddNotification(NotificationRequest notification);
        List<NotificationResponse> GetNotifications();
        string DeleteNotification(Guid notificationId);
        string UpdateNotification(NotificationRequest notificationRequest, Guid notificationId);

    }
}
