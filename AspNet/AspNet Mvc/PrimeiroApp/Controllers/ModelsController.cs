using Microsoft.AspNetCore.Mvc;
using PrimeiroApp.Models;

namespace PrimeiroApp.Controllers
{
    public class ModelsController : Controller
    {
        public IActionResult Index()
        {
            var aluno = new Aluno();

            // validar se foi preenchido corretamente
            // se o item tivesse sido recebido de um formulário, a model state faria essa validação automaticamente assim:

            // a view chama a controller que por sua vez cria uma instancia da model com os dados passados pela view.
            // nesse momento acontece o data bind, onde é atribuido os valores das prorpiedades para a instancia da model
            // fazendo dessa maneira a validação automatica nessa model state

            //  view -> controller -> model

            // mas vamos fazer na mão pra entender

            if (TryValidateModel(aluno))
            {
                return View(aluno);
            }

            var ms = ModelState;

            var erros = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            erros.ForEach(r => Console.WriteLine(r.First().ErrorMessage));

            return View();
        }
    }
}
