using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        // validação de notificação de erro

        // validação de modelstate

        // validação de negocios

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Funcionando!");
        }
    }
}
