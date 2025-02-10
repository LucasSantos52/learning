using ApiFuncional.Data;
using ApiFuncional.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiFuncional.Configuration
{
    public static class IdentityConfig
    {
        public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
        {
            /*  IdentityUser - usuário interativo da app, usuário logado
                IdentityRole - perfil do usuário logado, administrador, cliente....   
             */
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApiDbContext>(); // contexto que será usado

            // Jwt
            // Pegando o token e gerando a chave encodada
            var JwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
            builder.Services.Configure<JwtSettings>(JwtSettingsSection);
            // instancia da jwtSettings populada
            var jwtSettings = JwtSettingsSection.Get<JwtSettings>();
            // gerando a key
            var key = Encoding.ASCII.GetBytes(jwtSettings.Segredo);
            // configurando autenticação
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audiencia,
                    ValidIssuer = jwtSettings.Emissor
                };
            });

            return builder;
        }
    }
}
