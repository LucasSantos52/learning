using AppSemTemplate.Data;
using AppSemTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace AppSemTemplate.Configuration
{
    public static class MvcConfig
    {
        public static WebApplicationBuilder AddMvcConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            builder.Services.AddControllersWithViews(options =>
            {
                // aplica globalmente a tag de segurança [ValidateAntiForgeryToken] em todas as rotas
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            
            // Adicionando suporte a mudança de convenção de rota das areas.
            builder.Services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            
            // Contexto
            builder.Services.AddDbContext<AppDbContext>(o =>
                o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // HSTS
            builder.Services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

            // melhor maneira de obter configurações no appsettings
            // homecontroller | com base na section, popule o modelo de api configuration
            // disponibiliza a configuração via interface IOptions
            builder.Services.Configure<ApiConfiguration>(
                builder.Configuration.GetSection(ApiConfiguration.ConfigName));


            return builder;
        }

        public static WebApplication UseMvcConfiguration(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {

            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // SLUGIFY - exemplo
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller:slugify=Home}/{action:slugify=Index}/{id?}"
            //    );

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );

            // Rota de áreas especializadas
            app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
            app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Gestao}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            // podendo ja ter a instancia antes da execução
            // pode ser usado em background-services no aspnet que roda em uma instancia definida singleton
            // e não podemos criar nenhum objeto injetado que não seja do tipo singleton, ai vamos precisar
            // obter dessa maneira, porque não poderemos injetar e sim obter do serviço
            using (var serviceScope = app.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var singService = services.GetRequiredService<IOperacaoSingleton>();
                // essa linha não vai funcionar pq o console precisa do app.run que vem depois,
                // mas serve pra mostrar como utilizar uma instancia antes de executar o app.    
                Console.WriteLine("Direto na program.cs" + singService.OperacaoId);
            }

            return app;
        }
    }
}
