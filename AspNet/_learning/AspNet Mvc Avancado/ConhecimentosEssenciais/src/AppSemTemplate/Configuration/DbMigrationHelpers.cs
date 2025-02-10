using AppSemTemplate.Data;
using AppSemTemplate.Models;
using Microsoft.AspNetCore.Identity;

namespace AppSemTemplate.Configuration
{
    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
            {
                await context.Database.EnsureCreatedAsync();
                await EnsureSeedProducts(context);
            }
        }

        private static async Task EnsureSeedProducts(AppDbContext context)
        {
            if (context.Produtos.Any()) return;

            await context.Produtos.AddAsync(new Produto() { Nome = "Livro css", Imagem = "CSS.jpg", Valor = 50 });
            await context.Produtos.AddAsync(new Produto() { Nome = "Livro JQuery", Imagem = "JQuery.jpg", Valor = 150 });
            await context.Produtos.AddAsync(new Produto() { Nome = "Livro Html", Imagem = "HTML.jpg", Valor = 90 });
            await context.Produtos.AddAsync(new Produto() { Nome = "Livro Razor", Imagem = "Razor.jpg", Valor = 50 });

            await context.SaveChangesAsync();

            if (context.Users.Any()) return;

            await context.Users.AddAsync(new IdentityUser()
            {
                Id = "3a17a58e-5996-43cb-9751-76d9476a31e6",
                UserName = "teste@teste.com",
                NormalizedUserName = "TESTE@TESTE.COM",
                Email = "teste@teste.com",
                NormalizedEmail = "TESTE@TESTE.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEAhkfdiPHWk4/C+ntLtRot45WtDv1U0V+3ekEWcjQSOZIBeLJ1CYS6YiAjK0gHhN+w==",
                SecurityStamp = "NSPJBUGMBQSAX2TXFVZFX2QS46Y7BKBT",
                ConcurrencyStamp = "b0777c61-4d82-41ab-bfa0-bc7a01a2211a",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            });

            await context.SaveChangesAsync();

            if (context.UserClaims.Any()) return;

            await context.UserClaims.AddAsync(new IdentityUserClaim<string>()
            {
                UserId = "3a17a58e-5996-43cb-9751-76d9476a31e6",
                ClaimType = "Produtos",
                ClaimValue = "VI,AD,ED,EX"
            });

            await context.SaveChangesAsync();
        }
    }
}
