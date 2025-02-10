**CLI dotnet**

***executar no diretorio da .csproj***

**Inicio**
- criar solução
dotnet new sln -n NomeDaSolução

- criar projeto
dotnet new modeloDoProjeto -n NomeDoProjeto
    dotnet new webapi -n MinhaWebApi
    dotnet new mvc -n MeuProjetoMvc

- vincular projeto na solução
dotnet sln add caminhoDoProjeto
    dotnet sln add .\src\DevIO.Data\
    dotnet sln add .\src\DevIO.Business\

- listar projetos da solução
dotnet sln list

- adicionando dependencias (reference) no projeto
dotnet add caminhoDoProjeto reference caminhoDoProjetoQueVaiSerReferenciado
    dotnet add MinhaApiCore/MinhaApiCore.csproj reference BibliotecaDeServicos/BibliotecaDeServicos.csproj

- listando refencias do projeto
dotnet list caminhoDoProjeto reference
    dotnet list . reference
    dotnet list MinhaApiCore/MinhaApiCore.csproj reference


**Projeto**
- executar projeto 
dotnet run
dotnet watch run

- limpar solução
dotnet clean

- buildar solução
dotnet build


**Pacotes**
- listar os pacotes instalados
dotnet list package 

- instalação de pacotes nuget
dotnet add package nomeDoPacote    
    dotnet add package Microsoft.EntityFrameworkCore.sqlserver
    dotnet add package Microsoft.AspNetCore.Mvc.Api.Analyzers
    dotnet add package Microsoft.EntityFrameworkCore.sqlserver
    dotnet add package Microsoft.EntityFrameworkCore.tools
    dotnet add package Microsoft.EntityFrameworkCore.design


**Entity framework**
- Instalação
dotnet tool install --global dotnet-ef

- Criar Migration
dotnet ef migrations add NomeDaMigration

- Atualizar banco de dados
dotnet ef database update
dotnet ef database update --project ../DevIO.Data --startup-project .



**Scaffolding**
- Gerar controller baseada em um Model e um DbContext

dotnet aspnet-codegenerator controller -name NomeDaController -m ModelUsada -dc DbContex -namespace MeuNameSpace.Controllers -outDir PastaDeSaida -api
    
    dotnet aspnet-codegenerator controller  // indica ao codegenerator a criação de uma controller
    -name FornecedoresController            // nome da controller que vai ser gerada
    -m NomeDoSeuModel                       // model que vai ser utilizada pra criação da controller
    -dc ApiDbContext                        // dataContext - contexto que vai ser utilizado
    -namespace MinhaApiCore.Controllers     // namespace da controller
    -outDir Controllers                     // especifica a pasta onde a controller vai ser gerada
    -api                                    // impede a criação das views    

    ex.:
    dotnet aspnet-codegenerator controller -name FornecedoresController -m Fornecedor -dc ApiDbContext -namespace MinhaApiCore.Controllers -outDir Controllers -api