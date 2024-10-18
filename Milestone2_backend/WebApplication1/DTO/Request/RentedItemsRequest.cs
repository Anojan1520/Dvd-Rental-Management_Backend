namespace WebApplication1.DTO.Request
{
    public class RentedItemsRequest
    {
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; }
        public int RentedQuantity { get; set; }
        public string RentedDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
