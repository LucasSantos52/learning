using Microsoft.AspNetCore.Mvc;

namespace MinhaApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        /// <summary>
        /// Lista todos os produtos.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetProdutos()
        {
            return Ok(new string[] { "value1", "value 2" });
        }

        /// <summary>
        /// Retorna um produto específico pelo Id.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<string>> GetProduto(int id)
        {
            return Ok("value1");
        }

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<string>> CreateProduto([FromBody] string produto)
        {
            return "criado!";
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] string produto)
        {
           return NoContent();
        }

        /// <summary>
        /// Exclui um produto pelo Id.
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            return NoContent();
        }
    }
}
