using WebApplication1.Modals;

namespace WebApplication1.DTO.Request
{
    public class UserRequest
    {
        public string position { get; set; }
        public string firstname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nic { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
    }
}
