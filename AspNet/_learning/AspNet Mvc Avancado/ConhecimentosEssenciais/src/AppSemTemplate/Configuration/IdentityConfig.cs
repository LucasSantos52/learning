using AppSemTemplate.Data;
using Microsoft.AspNetCore.Identity;

namespace AppSemTemplate.Configuration
{
    public static class IdentityConfig
    {
        public static WebApplicationBuilder AddIdentityConfiguration(this WebApplicationBuilder builder)
        {

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();


            builder.Services.AddAuthorization(options =>
            {
                // implementando policy
                options.AddPolicy("PodeExcluirPermanentemente", policy => policy.RequireRole("Admin"));

                // implementando claim
                options.AddPolicy("VerProdutos", policy => policy.RequireClaim("Produtos", "VI"));
            });


            return builder;
        }
    }
}
