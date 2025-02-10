using DevIO.Api.Configuration;
using DevIO.Api.Extensions;
using DevIO.Data.Context;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(connectionString!);
});

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.WebApiConfig();

builder.Services.AddSwaggerConfig();

builder.Services.ResolveDependencies();

builder.Services.AddHealthChecksUI()
    .AddInMemoryStorage(); // Armazenamento temporário em memória

builder.Services.AddHealthChecks()
    .AddCheck(name: "Produtos", new SqlServerHealthCheck(connectionString))
    .AddSqlServer(connectionString!, name: "SqlDb");


// app
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts(); // Adiciona o middleware de HSTS

    // Configuração personalizada (opcional)
    app.UseHttpsRedirection(); // Redireciona para HTTPS automaticamente
}

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.UseMvcConfiguration();

app.UseSwaggerConfig(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.MapHealthChecksUI(options =>
{
    options.UIPath = "/hc-ui"; // Substitua pelo caminho desejado
});
app.MapHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
}); // Endpoint básico do HealthChecks

app.Run();
