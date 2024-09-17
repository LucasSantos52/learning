using aspnet_core;

// configura��o de Builder
var builder = WebApplication.CreateBuilder(args);

// configura��o do Pipeline

builder.AddSerilog();

builder.Services.AddControllersWithViews();

// Configura��o da app
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
