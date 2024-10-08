namespace WebApplication1.Modals
{
    public class ConfirmOrders
    {
        public Guid id { get; set; }
        public string movie { get; set; }
        public decimal totalRent { get; set; }
        public Guid userId { get; set; }
        public DateOnly rentDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public Guid movieId { get; set; }


       
    }
}
