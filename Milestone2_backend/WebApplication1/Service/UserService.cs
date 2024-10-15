using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.IRepositroy;
using WebApplication1.IService;
using WebApplication1.Modals;

namespace WebApplication1.Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<string> Register(UserRequest user)
        {
            if (user != null)
            {
                var obj = new Users
                {
                    position = user.position,
                    firstname = user.firstname,
                    username = user.username,
                    password = user.password,
                    phone = user.phone,
                    email = user.email,
                    nic = user.nic,
                };

                var ReturnData = await userRepository.Register(obj);

                return ReturnData;
            }
            else
            {
                throw new ArgumentException("User information is required.");
            }

        }
        public async Task<List<UsersResponse>> GetAllUser()
        {

            var data = await userRepository.GetAll();

            var Obj = new List<UsersResponse>();
            foreach (var user in data)
            {
                var response = new UsersResponse()
                {
                    id = user.id,
                    position = user.position,
                    firstname=user.firstname,
                    username = user.username,
                    password = user.password,
                    phone = user.phone,
                    email = user.email,
                    nic = user.nic,
                };
                Obj.Add(response);
            };
            return Obj;

        }

        public async Task<string> UpdateUser(UserRequest user, Guid id)
        {
            if (user != null)
            {
                var ReqUser = new Users
                {
                    id = id,
                    position = user.position,
                    firstname = user.firstname,
                    username = user.username,
                    password = user.password,
                    phone = user.phone,
                    email = user.email,
                    nic = user.nic,

                };
                var data = await userRepository.UpdateUser(ReqUser);
                return data;
            }
            else
            {
                throw new Exception("Field is Required");
            }
        }
        public async Task<string> DeleteUser(Guid userid)
        {
            var User = await userRepository.GetByUserID(userid);
            if (User != null)
            {
                var data = await userRepository.DeleteUser(userid);
                return data;

            }
            else
            {
                throw new Exception("Your Id is Invalid...");
            }
        }

    }
}
