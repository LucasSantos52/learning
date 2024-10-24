using AppSemTemplate.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddGlobalizationConfig()    
    .AddMvcConfiguration()
    .AddIdentityConfiguration()
    .AddDependencyInjectionConfiguration();

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseMvcConfiguration();

app.Run();
