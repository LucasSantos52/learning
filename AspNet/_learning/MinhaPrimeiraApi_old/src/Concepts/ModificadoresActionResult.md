Modificadores de Comportamento da Ação (Actions)

- Os modificadores de comportamento são usados em métodos de ação para especificar os tipos de resposta que podem ser retornados. Eles não apenas definem as possíveis respostas, mas também ajudam na documentação e na geração automática de especificações, como no Swagger.

//Exemplo de Método:
[HttpPost]
[ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public ActionResult Post(Product product) 
{ 
    if (product.Id == 0) 
        return BadRequest(); // Retorna 400 se o produto não for válido

    // Lógica para adicionar o produto ao banco de dados

    return CreatedAtAction(nameof(Post), product); // Retorna 201 ao criar o produto
}

Explicação dos Modificadores:
[HttpPost]: Indica que este método responde a requisições HTTP POST, que geralmente são usadas para criar novos recursos.

[ProducesResponseType]:
    [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]: Especifica que, se a criação do produto for bem-sucedida, o método retornará um status HTTP 201 (Created) com o objeto Product no corpo da resposta.

    [ProducesResponseType(StatusCodes.Status400BadRequest)]: Indica que, se houver um erro de validação (como um product.Id igual a 0), o método retornará um status HTTP 400 (Bad Request).

Benefícios dos Modificadores:
    - Documentação: Os modificadores ajudam a gerar documentação mais clara e precisa para a API, mostrando quais são os tipos de retorno esperados em cada cenário. Isso é especialmente útil para desenvolvedores que usam a API, pois facilita a compreensão do que esperar em diferentes condições.

    - Swagger: Quando integrado ao Swagger, esses modificadores permitem que a documentação da API seja gerada automaticamente, exibindo os diferentes códigos de status e tipos de resposta que podem ser retornados por cada método, melhorando a usabilidade e a experiência do desenvolvedor.
