using Unicam.Paradigmi.Application.Middlewares;

namespace Unicam.Paradigmi.Application.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddApplicationMiddleware(this WebApplication? app)
        {
            app.UseMiddleware<MiddlewareExample>();
            return app;
        }
    }
}
