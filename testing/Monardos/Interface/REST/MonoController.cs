using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using testing.Monardos.Domain.Model.Queries;
using testing.Monardos.Domain.Services;

namespace testing.Monardos.Interface.REST;

[ApiController]
[Route("api/v1/monkeys")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Monkeys API")]
public class MonoController(IMonkeyQueryService queryService, IMonkeyCommandService commandService) : ControllerBase
{
    [HttpGet]
    [Route("{monkeyId}")]
    [SwaggerOperation(Summary = "Gets a monkey",
        Description = "Gets a monkey by id",
        OperationId = "GetMonkeyById"
        )]
    [SwaggerResponse(200, "Gets a monkey")]
    [SwaggerResponse(404, "The monkey could not be found")]
    public async Task<IActionResult> GetMonkey(int monkeyId)
    {
        var getMonkeyById = new GetMonkeyByIdQuery(monkeyId);
        var monkey = await queryService.Handle(getMonkeyById);
        
        if(monkey == null)
            return NotFound();
        return Ok(monkey);
    }
}