using testing.IAM.Infrastructure.Pipeline.Middleware.Components;

namespace testing.IAM.Infrastructure.Pipeline.Middleware.Extensions;

public static class RequestAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestAuthorizationMiddleware(this IApplicationBuilder builder)
        /*
        IApplicationBuilder, que es el tipo que se usa en Program.cs o Startup.cs para construir la app.

        Por eso tiene el this IApplicationBuilder builder: eso lo convierte en método de extensión.

        Ahora puedes usarlo como si fuera un método nativo del builder.

        app.UseRequestAuthorization();
        */
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}