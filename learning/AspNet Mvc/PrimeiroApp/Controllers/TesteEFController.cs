using Microsoft.AspNetCore.Mvc;
using PrimeiroApp.Data;
using PrimeiroApp.Models;

namespace PrimeiroApp.Controllers
{
    public class TesteEFController : Controller
    {
        public AppDbContext Db { get; set; }
        public TesteEFController(AppDbContext db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Nome = "Lucas",
                Email = "a@a.com",
                DataNascimento = new DateTime(1992, 01, 30),
                Avaliacao = 5,
                Ativo = true
            };

            // Adicionando no banco de dados
            //Db.Alunos.Add(aluno);
            //Db.SaveChanges();

            // Atualiza no banco de dados
            //var alunosChange = Db.Alunos.Where(a => a.Name == "Lucas").FirstOrDefault();
            //alunosChange.Name = "Lucas Santos";
            //Db.Alunos.Update(alunosChange);
            //Db.SaveChanges();

            // Remove do banco de dados
            //var alunosDelete = Db.Alunos.Where(a => a.Name.Contains("Lucas")).FirstOrDefault();
            //Db.Alunos.Remove(alunosDelete);
            //Db.SaveChanges();

            return View();
        }
    }
}
