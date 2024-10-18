namespace WebApplication1.DTO.Request
{
    public class ConfirmOrderRequest
    {
      
        public string Movie { get; set; }
        public decimal TotalRent { get; set; }
        public Guid UserId { get; set; }
        public string RentedDate { get; set; }
        public string ReturnDate { get; set; }
        public Guid MovieId { get; set; }
    }
}
