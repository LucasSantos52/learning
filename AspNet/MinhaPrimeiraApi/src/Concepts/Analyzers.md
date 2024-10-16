Analyzers

Os analisadores são ferramentas valiosas que ajudam a manter o código consistente. Eles decoram os métodos com os possíveis códigos de status que podem ser retornados, facilitando a documentação da API.

Para utilizá-los, você precisa instalar o pacote:

    ide -> Microsoft.AspNetCore.Mvc.Api.Analyzers

        Install-Package Microsoft.AspNetCore.Mvc.Api.Analyzers


    cli -> navegue até a pasta do seu projeto e execute o seguinte comando:
        
        dotnet add package Microsoft.AspNetCore.Mvc.Api.Analyzers



Após a instalação, adicione a seguinte configuração ao seu arquivo .csproj:

<PropertyGroup>
    ...
    <IncludeOpenAPIAnalyzers>true</IncludeOpenAPIAnalyzers>
</PropertyGroup>
