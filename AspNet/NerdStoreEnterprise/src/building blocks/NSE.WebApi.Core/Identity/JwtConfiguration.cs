using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NSE.WebApi.Core.Identity
{
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //JWT
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = true; // requer o acesso via https por questão de segurança
                bearerOptions.SaveToken = true; // salvar token na estancia
                bearerOptions.TokenValidationParameters = new TokenValidationParameters // parametros de validação
                {
                    ValidateIssuerSigningKey = true, // validar token com base na assinatura
                    IssuerSigningKey = new SymmetricSecurityKey(key), // chave de criptografia
                    ValidateIssuer = true, // validar emissor, quem gerou o token 
                    ValidateAudience = true, // valida a audiencia, onde o token é válido
                    ValidIssuer = appSettings.Issuer, // informa o emissor valido
                    ValidAudience = appSettings.Audience // informa a audiencia válida
                };
            });

            return services;
        }

        public static IApplicationBuilder UseJwtConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
