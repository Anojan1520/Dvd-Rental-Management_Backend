namespace WebApplication1.Modals
{
    public class ConfirmOrders
    {
        public Guid id { get; set; }
        public string Movie { get; set; }
        public decimal TotalRent { get; set; }
        public Guid UserId { get; set; }
        public string RentedDate { get; set; }
        public string ReturnDate { get; set; }
        public Guid MovieId { get; set; }

    }
}
