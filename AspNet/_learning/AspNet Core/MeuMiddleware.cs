using Serilog;
using System.Diagnostics;

namespace aspnet_core
{
    public class TemplateMiddleware
    {
        private readonly RequestDelegate _next;

        public TemplateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // faz algo antes

            // chama o próximo middleware no pipeline
            await _next(httpContext);

            // faz algo depois
        }

    }

    public class LogTempoMiddleware
    {
        private readonly RequestDelegate _next;

        public LogTempoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // faz algo antes
            var sw = Stopwatch.StartNew();

            // chama o próximo middleware no pipeline
            await _next(httpContext);

            sw.Stop();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Information($"A execucao demorou {sw.Elapsed.Microseconds}ms ({sw.Elapsed.TotalSeconds} segundos)");

            // faz algo depois
        }

    }

    public static class SerilogExtensions
    {
        public static void AddSerilog(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog();
        }
    }

    public static class LogTempoMiddlewareExtensions
    {
        public static void UseLogtempo(this WebApplication app)
        {
            app.UseMiddleware<LogTempoMiddleware>();
        }
    }

}
