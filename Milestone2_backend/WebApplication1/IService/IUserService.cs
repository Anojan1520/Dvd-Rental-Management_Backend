using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;

namespace WebApplication1.IService
{
    public interface IUserService
    {
        Task<string> Register(UserRequest user);
        Task<List<UsersResponse>> GetAllUser();
        Task<string> UpdateUser(UserRequest user, Guid id);
        Task<string> DeleteUser(Guid userid);
    }
}
