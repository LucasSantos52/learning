using ApiFuncional.Data;
using ApiFuncional.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ApiFuncional.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        // injeção de dependencia
        public ProdutosController(ApiDbContext context)
        {
            _context = context;
        }

        /*
            O método originalmente seria assim:

            public IActionResult GetProdutos() {}

            Mas como precisamos trazer uma lista de produtos e queremos fazer isso de forma assíncrona,
            mudaremos a assinatura do método para suportar operações assíncronas.

            public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
            {
                return await _context.Produtos.ToListAsync();
            }

            Entendendo passo a passo:

            -> async    indica que o método é assíncrono, ou seja, ele pode fazer operações longas, como consultas ao banco de dados,
                        sem bloquear a execução de outras tarefas.

            -> Task<>   quando usamos async, o método precisa retornar um tipo `Task`, que representa uma operação assíncrona.

            -> Task<ActionResult>   ao invés de usar a interface `IActionResult`, usamos `ActionResult`, que é uma implementação concreta
                                    dessa interface e permite especificar o tipo de retorno.

            -> Task<ActionResult<IEnumerable<Produto>>>   retornamos uma coleção (IEnumerable) de objetos do tipo `Produto`.
            
            -> O método ToListAsync() retorna uma `List<Produto>`, que é compatível com `IEnumerable<Produto>`.
        */

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            if (_context.Produtos == null) return NotFound();

            return await _context.Produtos.ToListAsync();
        }

        [AllowAnonymous]
        //[EnableCors("Production")] //sobrescreve a politica do cors
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            if (_context.Produtos == null) return NotFound();

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null) return NotFound();

            return produto;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            if (_context.Produtos == null) return Problem("Erro ao criar um produto, contate o suporte!");

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                //return ValidationProblem(ModelState);

                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = "Um ou mais erros de validação ocorreram"
                });
            }


            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id) return BadRequest();

            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            //_context.Produtos.Update(produto);
            _context.Entry(produto).State = EntityState.Modified;

            //await _context.SaveChangesAsync();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            if (_context.Produtos == null) return NotFound();

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null) return NotFound("Produto não encontrado");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
