using WebApplication1.Modals;

namespace WebApplication1.IRepository
{
    public interface INotificationRepository
    {
        Task<string> AddNotification(Notifications notifications);
        Task<List<Notifications>> GetNotifications();
        Task<string> DeleteNotification(Guid notificationId);
        Task<string> UpdateNotification(Notifications notifications);
    }
}
