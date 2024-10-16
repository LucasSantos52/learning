using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MinhaApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinhaApiCoreController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id:int}")]
        public ActionResult<string> GetOne(int id)
        {
            return id.ToString();
        }

        [HttpPost]        
        // [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(int id)
        {
            return CreatedAtAction(nameof(GetOne), new { id }, id);
        }

        [HttpPut("{id:int}")]        
        public async Task<IActionResult> UpdateOne(int id, [FromBody] string value)
        {
            return NoContent();            
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }

}