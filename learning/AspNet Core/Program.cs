using aspnet_core;

// configuração de Builder
var builder = WebApplication.CreateBuilder(args);

// configuração do Pipeline

builder.AddSerilog();

builder.Services.AddControllersWithViews();

// Configuração da app
var app = builder.Build();

app.UseLogtempo();

app.UseMiddleware<LogTempoMiddleware>();

app.MapGet("/", () => "Hello World!");
app.MapGet("/teste", () =>
{
    Thread.Sleep(1500);
    return "teste 2";
});

app.Run();
