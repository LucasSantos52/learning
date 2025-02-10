using AutoMapper;
using DevIO.Api.Configuration;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!);
});

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ResolveDependencies();

var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Run();
