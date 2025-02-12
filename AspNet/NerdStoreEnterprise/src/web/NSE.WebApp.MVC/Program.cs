using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;

// Criando ConfigurationBuilder
var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Adicionando User Secrets apenas no ambiente de desenvolvimento
if (env.IsDevelopment())
{
    configurationBuilder.AddUserSecrets<Program>();
}

// Construindo a configuração final
var configuration = configurationBuilder.Build();

// Adicionando a configuração ao builder
builder.Configuration.AddConfiguration(configuration);

builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterServices();

var app = builder.Build();
app.UseMvcConfiguration(builder.Environment);
app.Run();
