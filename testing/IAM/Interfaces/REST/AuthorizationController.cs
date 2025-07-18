using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using testing.IAM.Domain.Services;
using testing.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using testing.IAM.Interfaces.REST.Resources;
using testing.IAM.Interfaces.REST.Transform;

namespace testing.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Authorization API Controller")]
public class AuthorizationController(IUserCommandService userCommandService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("sing-in")]
    public async Task<IActionResult> signIn([FromBody]SignInResource userResource)
    {
        var singInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(userResource);
        var authentication = await userCommandService.Handle(singInCommand);
        
        var resource = AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authentication.user, authentication.token);
        return Ok(resource);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> signUp([FromBody] SignUpResource userResource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(userResource);
        
        await userCommandService.Handle(signUpCommand);
        
        return Ok(new {message = "Sign up success"});
    }
}