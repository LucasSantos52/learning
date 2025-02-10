using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<string> Login(UserLogin userLogin);

        Task<string> Register(UserRegister userRegister);
    }
}
