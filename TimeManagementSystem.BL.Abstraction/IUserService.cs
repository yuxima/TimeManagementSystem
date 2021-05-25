using System.Threading.Tasks;
using TimeManagementSystem.BL.DTO;

namespace TimeManagementSystem.BL.Abstraction
{
    public interface IUserService
    {
        Task<object> Register(UserRegisterModel userRegisterModel);
        Task<object> Login(UserLoginModel userLoginModel);
        Task SignOut();
    }
}
