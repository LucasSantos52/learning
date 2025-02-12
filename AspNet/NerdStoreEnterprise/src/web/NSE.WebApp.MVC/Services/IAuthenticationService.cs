using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<UsuarioRespostaLogin> Login(UserLogin userLogin);

        Task<UsuarioRespostaLogin> Register(UserRegister userRegister);
    }
}
