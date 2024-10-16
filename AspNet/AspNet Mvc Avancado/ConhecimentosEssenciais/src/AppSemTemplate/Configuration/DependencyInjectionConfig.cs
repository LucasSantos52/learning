using AppSemTemplate.Services;

namespace AppSemTemplate.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            /*  DI = Dependency Injection

                Transiente
                    -> Obtém uma nova instância do objeto a cada solicitação

                Scoped
                    -> Retiliza a mesma instância do objeto durante todo o request (web)

                Singleton
                    -> Utiliza a mesma instância para toda a aplicação (cuidado)     
            */

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            //builder.Services.AddScoped<IOperacao, Operacao>();
            
            builder.Services.AddTransient<IOperacaoTransient, Operacao>(); // vai ser gerada sempre que solicitar
            builder.Services.AddScoped<IOperacaoScoped, Operacao>(); // gerada 1x por request - dura o tempo do request
            builder.Services.AddSingleton<IOperacaoSingleton, Operacao>(); // sempre a mesma a partir do start da aplicação
            builder.Services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty)); // mesma de cima, com a diferença de receber parametro

            builder.Services.AddTransient<OperacaoService>(); // usado para o teste, pq não pode armazenar nenhum tipo de estado

            return builder;
        }
    }
}
