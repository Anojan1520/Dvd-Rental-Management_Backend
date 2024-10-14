namespace WebApplication1.DTO.Response
{
    public class MovieResponse
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Genere { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public List<string> Images { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Release { get; set; }
    }
}
