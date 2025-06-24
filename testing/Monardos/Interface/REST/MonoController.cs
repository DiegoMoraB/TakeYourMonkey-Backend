using Microsoft.AspNetCore.Mvc;
using testing.Monardos.Domain.Services;

namespace testing.Monardos.Interface.REST;

[ApiController]
[Route("api/v1/monkeys")]

public class MonoController(IMonkeyQueryService queryService, IMonkeyCommandService commandService) : ControllerBase
{
    
}