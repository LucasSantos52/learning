using DevIO.Api.Controllers;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.v2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/test")]
    public class TestController : MainController
    {
        private ILogger<TestController> _logger;

        public TestController(INotificador notificador, 
                             IUser user,
                             ILogger<TestController> logger) : base(notificador, user)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
            => "sou a v2";

        [HttpGet("logs")]
        public string TiposDeLog()
        {
            _logger.LogTrace("Log de trace");
            _logger.LogDebug("Log de debug");
            _logger.LogInformation("Log de informação");
            _logger.LogWarning("Log de aviso");
            _logger.LogError("Log de erro");
            _logger.LogCritical("Log de problemas criticos");

            return "logs";
        }
    }
}
