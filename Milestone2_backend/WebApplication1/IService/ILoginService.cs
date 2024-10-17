using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;

namespace WebApplication1.IService
{
    public interface ILoginService
    {
        Task<string> LoginCustomer(LoginRequest login);
        Task<string> Logout(Guid id);
        Task<List<LoginResponse>> GetLoginDetails();
    }
}