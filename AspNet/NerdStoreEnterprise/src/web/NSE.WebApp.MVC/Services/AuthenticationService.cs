using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;

public class AuthenticationService : Service, IAuthenticationService
{
    private readonly HttpClient _httpClient;    

    public AuthenticationService(HttpClient httpClient, IOptions<AppSettings> appSettings)
    {
        httpClient.BaseAddress = new Uri(appSettings.Value.UrlAuthentication);
        _httpClient = httpClient;        
    }

    public async Task<UsuarioRespostaLogin> Login(UserLogin userLogin)
    {
        var loginContent = GetContent(userLogin);
        var response = await _httpClient.PostAsync("/api/identity/login", loginContent);

        if (!TreatErrorsResponse(response))
        {
            return new UsuarioRespostaLogin
            {
                ResponseResult = await DeserializeResponseObject<ResponseResult>(response)
            };
        }
        return await DeserializeResponseObject<UsuarioRespostaLogin>(response);
    }

    public async Task<UsuarioRespostaLogin> Register(UserRegister userRegister)
    {
        var registerContent = GetContent(userRegister);
        var response = await _httpClient.PostAsync("/api/identity/register", registerContent);

        if (!TreatErrorsResponse(response))
        {
            return new UsuarioRespostaLogin
            {
                ResponseResult = await DeserializeResponseObject<ResponseResult>(response)
            };
        }
        return await DeserializeResponseObject<UsuarioRespostaLogin>(response);
    }
}
