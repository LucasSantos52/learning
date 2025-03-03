using NSE.Identidade.API.Configuration;
using NSE.WebApi.Core.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration(builder.Configuration,builder.Environment);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
app.UseApiConfiguration();
app.UseSwaggerConfiguration(builder.Environment);
app.Run();
