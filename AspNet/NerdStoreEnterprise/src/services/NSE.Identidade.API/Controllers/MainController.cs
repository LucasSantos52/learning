using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace NSE.Identidade.API.Controllers
{
    [ApiController]
    // abstract pq essa classe não pode ser manipulada, apenas herdada
    public abstract class MainController : Controller
    {
        // protected para que apenas quem herde dessa classe possa ter acesso a essa propriedade
        protected ICollection<string> Errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(result);
            }

            return BadRequest(
                new ValidationProblemDetails( // pratica recomendada ao trabalhar com api - classe implementa um padrão de uma rfc que define como uma api deve responder sobre detalhes de errors
                    new Dictionary<string, string[]> // dictionary é como os objetos js, chave: valor, então chave= string: valor= string[]
            {
                // todos os erros serão passados em coleção dentro de um objeto chamado mensagens
                {"Messages", Errors.ToArray() },
            }));
        }

        // Custom response com assinatura diferente para resolução de erros com a view model
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddProcessError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        // valida se existem erros
        protected bool ValidOperation() 
        {
            return !Errors.Any();
        }

        // adiciona erro a lista de erros
        protected void AddProcessError(string error)
        {
            Errors.Add(error);
        }

        // limpa os erros
        protected void ClearProcessError()
        {
            Errors.Clear();
        }
    }
}
