using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Modals
{
    public class Notifications
    {
        public Guid id { get; set; }
        public Guid RentedId { get; set; }
        public int RentedQuantity { get; set; }
        public Guid movieId { get; set; }
        public Guid UserId { get; set; }
        public string RequestDate { get; set; }
        public string Status { get; set; }

    }
}
