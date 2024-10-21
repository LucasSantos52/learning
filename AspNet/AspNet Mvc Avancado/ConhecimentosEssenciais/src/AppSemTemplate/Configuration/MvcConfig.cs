using AppSemTemplate.Data;
using AppSemTemplate.Extensions;
using AppSemTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
                .AddEnvironmentVariables()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true); // -> aponta para o user secret, botão direito no projeto -> Manage user secrets

            // cache do tipo request cache, não pode ser usando em locais de usuários logados pq compartilha os dados com todos que acessarem o recuros
            // o cache mais indicado pra se usar é usando Redis
            builder.Services.AddResponseCaching();

            builder.Services.AddControllersWithViews(options =>
            {
                // aplica globalmente a tag de segurança [ValidateAntiForgeryToken] em todas as rotas
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                options.Filters.Add(typeof(FiltroAuditoria));

                MvcOptionsConfig.ConfigurarMensagensDeModelBinding(options.ModelBindingMessageProvider);
            })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.ConsentCookieValue = "true";
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
                // adiciona pagina detalhada de erros
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Redireciona o usuário para a página /erro/500 quando ocorre uma exceção não tratada.
                app.UseExceptionHandler("/erro/500");

                // Redireciona o usuário para uma página de erro personalizada (ex.: /erro/404)
                // com base no código de status da resposta (o {0} será substituído pelo código de status).
                app.UseStatusCodePagesWithRedirects("/erro/{0}");

                app.UseHsts();
            }

            app.UseResponseCaching();

            app.UseGlobalizationConfig();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

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
