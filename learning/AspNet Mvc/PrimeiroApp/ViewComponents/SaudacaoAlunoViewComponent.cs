using Microsoft.AspNetCore.Mvc;
using PrimeiroApp.Models;

namespace PrimeiroApp.ViewComponents
{
    public class SaudacaoAlunoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // pegar o aluno na base de dados
            // pegar o dado (nome) do aluni que esta logadl
            var aluno = new Aluno() { Nome = "Lucas" };

            return View(aluno);
        }
    }
}
