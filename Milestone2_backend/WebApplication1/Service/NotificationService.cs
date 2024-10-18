using System.Data.SqlClient;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.IRepository;
using WebApplication1.IService;
using WebApplication1.Modals;
using WebApplication1.Repository;

namespace WebApplication1.Service
{
    public class NotificationService : INotificationService
    {
        private INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public  async Task<string> AddNotification(NotificationRequest notification)
        {
            if (notification.RentedQuantity<1)
            {
                throw new ArgumentException("Rented quantity must be positive");
            }
           
            var obj = new Notifications
            {
                RentedId = notification.RentedId,
                RentedQuantity = notification.RentedQuantity,
                movieId = notification.movieId,
                UserId = notification.UserId,
                RequestDate = notification.RequestDate,
                Status = notification.Status
            };

            var ReturnData = await _notificationRepository.AddNotification(obj);
            return ReturnData;

        }

        public async Task<List<NotificationResponse>> GetNotifications()
        {
            var data = await _notificationRepository.GetNotifications();
            var listresponse = new List<NotificationResponse>();
            foreach (var item in data)
            {
                var response = new NotificationResponse()
                {
                    id = item.id,
                    RentedId = item.RentedId,
                    RentedQuantity = item.RentedQuantity,
                    movieId = item.movieId,
                    UserId = item.UserId,
                    RequestDate = item.RequestDate,
                    Status = item.Status

                };
                listresponse.Add(response);
            };
            return listresponse;
        }

        public async Task<string> DeleteNotification(Guid notificationId)
        {
            var data =await _notificationRepository.DeleteNotification(notificationId);
            return data;
        }

        public async Task<string> UpdateNotification(NotificationRequest notificationRequest, Guid notificationId)
        {
            if (notificationRequest.RentedQuantity < 1)
            {
                throw new ArgumentException("Rented quantity must be positive");
            }
            var requestdata = new Notifications
            {
                id = notificationId,
                RentedId = notificationRequest.RentedId,
                RentedQuantity = notificationRequest.RentedQuantity,
                movieId = notificationRequest.movieId,
                UserId = notificationRequest.UserId,
                RequestDate = notificationRequest.RequestDate,
                Status = notificationRequest.Status
            };

            var data =await _notificationRepository.UpdateNotification(requestdata);
            return data;
        }
        
    }
}



