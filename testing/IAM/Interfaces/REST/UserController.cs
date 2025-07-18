using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using testing.IAM.Application.Internal.QueryServices;
using testing.IAM.Domain.Model.Aggregates;
using testing.IAM.Domain.Model.Queries;
using testing.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using testing.IAM.Interfaces.REST.Transform;

namespace testing.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("User REST API")]
public class UserController(UserQueryService userQueryService) : ControllerBase
{
    [HttpGet("users")]
    public async Task<IActionResult> getAllUsers()
    {
        var queryGetAll = new GetAllUsersQuery();
        var users = await userQueryService.Handle(queryGetAll);
        
        
        return Ok(users.Select(UserResourceFromEntityAssembler.ToUserResourceFromEntity));
    }
}