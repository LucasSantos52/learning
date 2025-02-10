using DevIO.Api.Controllers;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.v1.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/test")]
    public class TestController : MainController
    {
        public TestController(INotificador notificador, IUser user) : base(notificador, user)
        {
            
        }

        [HttpGet]
        public string Valor()
            => "sou a v1";
    }
}
