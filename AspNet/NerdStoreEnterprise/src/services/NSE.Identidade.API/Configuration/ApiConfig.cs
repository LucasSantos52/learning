using NSE.Identidade.API.configuration;

namespace NSE.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfigurationBuilder configuration, IWebHostEnvironment env)
        {
            configuration
            //.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: env.IsDevelopment())
            .AddJsonFile("appsettings.{builder.Environmnent.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                configuration.AddUserSecrets<Program>();
            }

            services.AddControllers();

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseIdentityconfiguration(); // precisa estar nesse lugar

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
