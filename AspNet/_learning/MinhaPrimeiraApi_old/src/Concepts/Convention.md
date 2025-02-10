Conventions (Convenções)

As convenções podem ser usadas em vez de analisadores (analyzers) para automatizar a decoração dos métodos, sugerindo os tipos de retorno apropriados com base nos verbos HTTP utilizados.

Por exemplo, ao usar uma convenção padrão como:

[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]


As convenções seguem as boas práticas de HTTP, sugerindo o status correto para cada verbo. Por exemplo:

POST: Retorna 201 Created ao criar um novo recurso.
GET: Retorna 200 OK ao buscar um recurso com sucesso.
PUT: Retorna 200 OK ou 204 No Content se a atualização for bem-sucedida.
DELETE: Retorna 204 No Content se o recurso for excluído com sucesso.


Veja um exemplo de uso com o verbo PUT:

[HttpPut("{id:int}")]
[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
public ActionResult Put(int id, [FromForm] Product product)
{
    if (!ModelState.IsValid) 
        return BadRequest();

    if (id != product.id) 
        return NotFound();

    return NoContent();
}

Neste exemplo, a convenção aplicada sugere o comportamento esperado e os códigos de status adequados, mas a lógica de retorno ainda deve ser implementada no método.


-- SIMPLIFICANDO

Em vez de adicionar em cada metodo, é possivel adicionar como decorador da controller, fazendo a implementação para todos os métodos da controller

[ApiConventionMethod(typeof(DefaultApiConventions)]
[Route("api/{controller}")]
public class minhaController : ControllerBase {}


-- AINDA MAIS SIMPLES

na program.cs

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

isso siginifica que toda a sua aplicação vai usar essa convenção