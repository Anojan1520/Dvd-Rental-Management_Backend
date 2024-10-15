using WebApplication1.Modals;

namespace WebApplication1.IRepositroy
{
    public interface IUserRepository
    {
        Task<string> Register(Users user);
        Task<List<Users>> GetAll();
        Task<Users> GetByUserName(string UserName);
        Task<string> UpdateUser(Users user);
        Task<string> DeleteUser(Guid userid);
        Task<Users> GetByUserID(Guid userid);
    }
}
