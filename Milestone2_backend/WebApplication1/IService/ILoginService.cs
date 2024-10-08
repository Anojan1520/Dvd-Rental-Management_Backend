using WebApplication1.DTO.Request;

namespace WebApplication1.IService
{
    public interface ILoginService
    {
        Task<string> LoginCustomer(LoginRequest login);
        Task<string> Logout(Guid id);
    }
}