using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;

namespace WebApplication1.IService
{
    public interface INotificationService
    {
        Task<string> AddNotification(NotificationRequest notification);
        Task<List<NotificationResponse>> GetNotifications();
        Task<string> DeleteNotification(Guid notificationId);
        Task<string> UpdateNotification(NotificationRequest notificationRequest, Guid notificationId);

    }
}
