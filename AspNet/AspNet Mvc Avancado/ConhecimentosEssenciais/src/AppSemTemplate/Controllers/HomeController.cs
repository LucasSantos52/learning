using AppSemTemplate.Configuration;
using AppSemTemplate.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace AppSemTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ApiConfiguration ApiConfig;
        private readonly ILogger<HomeController> Logger;
        private readonly IStringLocalizer<HomeController> _localizer;

        // injeção via Options
        public HomeController(IConfiguration configuration,
                              IOptions<ApiConfiguration> apiConfiguration,
                              ILogger<HomeController> logger,
                              IStringLocalizer<HomeController> localizer)
        {
            Configuration = configuration;
            ApiConfig = apiConfiguration.Value;
            Logger = logger;
            _localizer = localizer;
        }

        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var apiConfig = new ApiConfiguration();
            Configuration.GetSection(ApiConfiguration.ConfigName).Bind(apiConfig);

            var secret = apiConfig.UserSecret;

            // outra forma de obter o valor
            var user = Configuration[$"{ApiConfiguration.ConfigName}:UserKey"];

            // usando configuração via Options
            var domain = ApiConfig.Domain;

            ViewData["Message"] = _localizer["Seja bem vindo!"];

            ViewData["Horario"] = DateTime.Now;

            return View();
        }

        [Route("teste")]
        public IActionResult Teste()
        {
            throw new Exception("ALGO ERRADO NÃO ESTAVA CERTO!");

            return View("Index");
        }


        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1)}
            );

            return LocalRedirect(returnUrl);
        }


        // obrigatorio ter 3 caracteres para tratar o codg. de erro, 400, 403, 500 ...
        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem = "A página que está procurando não existe! <\br /> Em caso de dúvidas contate nosso suporte";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isso.";
                modelErro.Titulo = "Acesso negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
