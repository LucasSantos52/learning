using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Configuration;
using NSE.Catalogo.API.Data;
using NSE.Catalogo.API.Data.Repository;
using NSE.Catalogo.API.Models;
using NSE.WebApi.Core.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
app.UseApiConfiguration(builder.Environment);
app.UseSwaggerConfiguration();
app.Run();
