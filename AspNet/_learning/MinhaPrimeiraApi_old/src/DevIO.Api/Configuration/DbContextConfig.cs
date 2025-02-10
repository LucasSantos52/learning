using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Api.Configuration
{
    public static class DbContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MeuDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return builder;
        }
    }
}