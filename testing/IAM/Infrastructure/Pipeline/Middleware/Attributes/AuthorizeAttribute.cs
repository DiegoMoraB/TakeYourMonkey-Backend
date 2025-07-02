using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using testing.IAM.Domain.Model.Aggregates;

namespace testing.IAM.Infrastructure.Pipeline.Middleware.Attributes;


[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]// atributo que puede usarse en metodos y clases
public class AuthorizeAttribute : Attribute, IAuthorizationFilter // la interfaz de authorization hare que se ejecute la funcion OnAuthorization antes de
                                                                  // ejecutar ya sea la clase o el metodo
{
    public void OnAuthorization(AuthorizationFilterContext context) /*
    Es una descripción del endpoint actual (acción/método del controlador) que ASP.NET Core está por ejecutar. Contiene información como:

El nombre del controlador

El nombre del método (acción)

Los atributos que tiene (como [Authorize], [HttpGet], etc.)

Parámetros que recibe

Rutas, filtros, etc.
    */
    {
        var anonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();// Busca si en el endpoint esta declarado el atributo anonymous
        
        if (anonymous)// Si esta declarado entonces no necesita autorizacion
        {
            Console.WriteLine("Skipping authorization");
            return;
        }
        
        var user = context.HttpContext.Items["User"] as User;
        
        //HttpContext.Items : Es un diccionario temporal (clave-valor) que existe durante una única solicitud HTTP.
        //Se usa para compartir datos entre middlewares, filtros y controladores, sin afectar la sesión ni el usuario global.
        //Entonces problablemente el middleware esta guardando "User" en el diccionario
        
        if (user == null) context.Result = new UnauthorizedResult();
        
        // Lo convierte (cast) al tipo User. Si no puede, el resultado será null.
    }
}