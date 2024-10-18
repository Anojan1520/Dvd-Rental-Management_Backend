using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
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
            if (User!=null)
            {
                var checkPass = userRepository.EncryptPassword(User.password);
                var loginPass=userRepository.EncryptPassword(login.password);
                if (User.username == login.Username && loginPass == checkPass)
                {
                    var obj = new Login
                    {
                        id = Guid.NewGuid(),
                        Username = login.Username,
                        password = loginPass,
                    };
                    var data = await loginRepository.UserLogin(obj);
                    return data;
                }
                else
                {
                    return "Username or Password is Invalid..";
                }
            }
            else
            {
                return "Username or Password is Invalid..";
            }
           
        } 
        public async Task<string> Logout(Guid id)
        {
            var User=userRepository.GetByUserID(id);
            if (User!=null)
            {
                var data = await loginRepository.Logout(id);
                return data;
            }
            else
            {
                return "Deleted UnSuccesfull";
            }
          
        }
        public async Task<List<LoginResponse>> GetLoginDetails()
        {
            var LoginList = new List<LoginResponse>();
            
            var data = await loginRepository.GetLoginDetails();
            foreach (var item in data)
            {
                var obj = new LoginResponse
                {
                    id = item.id,
                    password = item.password,
                    Username = item.Username
                };
                LoginList.Add(obj);
            }
            return LoginList;
        }
    }
}
