using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/nome-do-recurso")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("teste")]
        //[Route("teste")]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
