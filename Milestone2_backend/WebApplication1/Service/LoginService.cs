using WebApplication1.DTO.Request;
using WebApplication1.IRepositroy;
using WebApplication1.IService;
using WebApplication1.Modals;

namespace WebApplication1.Service
{
    public class LoginService : ILoginService
    {
        private ILoginRepository loginRepository;
        private IUserRepository userRepository;

        public LoginService(ILoginRepository loginRepository,IUserRepository User)
        {
            this.loginRepository = loginRepository;
            this.userRepository = User;
        }

        public async Task<string> LoginCustomer(LoginRequest login)
        {
            var User= await userRepository.GetByUserName(login.Username);
            if (User!=null&&login.password==User.password)
            {
                var obj = new Login
                {
                    id = Guid.NewGuid(),
                    Username = login.Username,
                    password = login.password,
                };
                var data = await loginRepository.UserLogin(obj);
                return data;
            }
            else
            {
                return "Login Failed";
            }
        } 
        public async Task<string> Logout(Guid id)
        {
            var data = await loginRepository.Logout(id);    
            return data;
        }
    }
}
