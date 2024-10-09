namespace WebApplication1.DTO.Request
{
    public class NotificationRequest
    {
        public Guid RentedId { get; set; }
        public int RentedQuantity { get; set; }
        public Guid movieId { get; set; }
        public Guid UserId { get; set; }
        public string RequestDate { get; set; }
        public string Status { get; set; }
    }
}
