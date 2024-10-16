Anotações

Dentro de uma rota de um controlador, existem alguns tipos de anotações que definem como os parâmetros são extraídos da requisição.

[HttpPut("{id:int}")]
public void Put([FromRoute] int id, [FromBody] string value) { }

- Parâmetro id: Ao utilizar id na rota e ter esse parâmetro no método com o mesmo nome, a anotação [FromRoute] é aplicada implicitamente, por isso ela não precisa ser declarada explicitamente.

- Parâmetro value: O parâmetro [FromBody] pode ser substituído por [FromForm], desde que o valor seja enviado como form-data dentro do request.

- Content-Type: Deve ser especificado como multipart/form-data ou application/x-www-form-urlencoded.

- Tipos Complexos: Não é necessário declarar [FromBody] para receber tipos complexos dentro do método, desde que a anotação [ApiController] esteja declarada na classe do controlador. O ASP.NET Core automaticamente lida com a desserialização do corpo da requisição.

- Outros Tipos de Modificadores:
    [FromHeader]: Extrai o valor do cabeçalho da requisição.

    [FromQuery]: Extrai o parâmetro que é passado via query string e que não faz parte da rota.

