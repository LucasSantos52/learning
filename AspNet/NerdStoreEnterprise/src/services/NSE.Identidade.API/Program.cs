using NSE.Identidade.API.Configuration;
using NSE.Identidade.API.configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddIdentityconfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
app.UseApiConfiguration();
app.UseSwaggerConfiguration(builder.Environment);
app.Run();
