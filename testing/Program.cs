using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using testing.IAM.Application.Internal.CommandServices;
using testing.IAM.Application.Internal.OutboundServices;
using testing.IAM.Application.Internal.QueryServices;
using testing.IAM.Domain.Repositories;
using testing.IAM.Domain.Services;
using testing.IAM.Infrastructure.Hashing.BCrypt.Services;
using testing.IAM.Infrastructure.Persistence.EFC.Repositories;
using testing.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using testing.IAM.Infrastructure.Token.JWT.Configuration;
using testing.IAM.Infrastructure.Token.JWT.Services;
using testing.Monardos.Application.ACL;
using testing.Monardos.Application.Internal.CommandServices;
using testing.Monardos.Application.Internal.QueryServices;
using testing.Monardos.Domain.Repositories;
using testing.Monardos.Domain.Services;
using testing.Monardos.Infrastructure.Persistence.EF.Repositories;
using testing.Monardos.Interface.ACL;
using testing.Shared.Domain.Repositories;
using testing.Shared.Infrastructure.Mediator.Cortex.Configuration;
using testing.Shared.Infrastructure.Persistence.EF.Configuration;
using testing.Shared.Infrastructure.Persistence.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();    // ← esto habilita los atributos de Swashbuckle.AspNetCore.Annotations

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TakeYourMonkey.API",
        Version = "v1",
        Description = "TakeYourMonkey.API",
        Contact = new OpenApiContact
        {
            Name = "TakeYourMonkey",
            Email = "dam0806blas@gmail.com"
        },
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
        }
    });
});
builder.Services.AddControllers();

builder.Services.AddDbContext<TakeYourMonkeyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IMonkeyRepository, MonkeyRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IMonkeyQueryService, MonkeyQueryService>();
builder.Services.AddScoped<IMonkeyCommandService, MonkeyCommandService>();

builder.Services.AddScoped<IMonkeyContextFacade, MonkeyContextFacade>();

builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));// Es para que se inyecte como IOptions<TokenSettings> en TokenService

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserQueryService,UserQueryService>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();

builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ITokenService,TokenService>();


builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: new[] {typeof(Program)},
    configure : options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TakeYourMonkeyDbContext>();
    context.Database.EnsureCreated();
}
app.UseHttpsRedirection();
app.UseRequestAuthorizationMiddleware();

app.MapControllers();

app.Run();
