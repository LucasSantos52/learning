using AppSemTemplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppSemTemplate.Controllers
{
    /* DI = Dependency Injection
     
       Transiente
            -> Obtém uma nova instância do objeto a cada solicitação

        Scoped
            -> Retiliza a mesma instância do objeto durante todo o request (web)

        Singleton
            -> Utiliza a mesma instância para toda a aplicação (cuidado)     
    */

    [Route("teste-di")]
    public class DiLifecycleController : Controller
    {
        public OperacaoService OperacaoService { get; set; }
        public OperacaoService OperacaoService2 { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
      

        public DiLifecycleController(OperacaoService operacaoService,
                                     OperacaoService operacaoService2,
                                     IServiceProvider serviceProvider)
        {
            OperacaoService = operacaoService;
            OperacaoService2 = operacaoService2;
            ServiceProvider = serviceProvider;
        }

        public string Index()
        {
            return
                "Primeira instância" + Environment.NewLine +
                OperacaoService.Transiet.OperacaoId + Environment.NewLine +
                OperacaoService.Scoped.OperacaoId + Environment.NewLine +
                OperacaoService.Singleton.OperacaoId + Environment.NewLine +
                OperacaoService.SingletonInstance.OperacaoId + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Segunda instancia" + Environment.NewLine +
                OperacaoService2.Transiet.OperacaoId + Environment.NewLine +
                OperacaoService2.Scoped.OperacaoId + Environment.NewLine +
                OperacaoService2.Singleton.OperacaoId + Environment.NewLine +
                OperacaoService2.SingletonInstance.OperacaoId + Environment.NewLine;
        }

        //
        // Outra maneira de fazer a injeção de dependencia, diretamente na action
        //

        [Route("teste")]
        public string Teste([FromServices] OperacaoService operacaoService)
        {
            return OperacaoService.Transiet.OperacaoId + Environment.NewLine +
                   OperacaoService.Scoped.OperacaoId + Environment.NewLine +
                   OperacaoService.Singleton.OperacaoId + Environment.NewLine +
                   OperacaoService.SingletonInstance.OperacaoId + Environment.NewLine;
        }

        [Route("view")]
        public IActionResult TesteView()
        {
            return View("Index");
        }

        [Route("container")]
        public string TesteContainer()
        {
            using (var serviceScope = ServiceProvider.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var singService = services.GetRequiredService<IOperacaoSingleton>();

                return "InstanciaSingleton: " + Environment.NewLine +
                        singService.OperacaoId + Environment.NewLine;
            }
        }
    }
}
