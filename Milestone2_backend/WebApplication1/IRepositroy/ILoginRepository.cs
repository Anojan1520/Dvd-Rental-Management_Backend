using WebApplication1.Modals;

namespace WebApplication1.IRepositroy
{
    public interface ILoginRepository
    {
        Task<string> UserLogin(Login detail);
        Task<string> UpdateLogin(Guid id);
        Task<string> Logout(Guid id);
        Task<List<Login>> GetLoginDetails();
    }
}