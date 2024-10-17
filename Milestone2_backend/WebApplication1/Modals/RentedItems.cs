namespace WebApplication1.Modals
{
    public class RentedItems
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; }
        public int RentQuantity { get; set; }
        public string RentedDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
