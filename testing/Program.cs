using Microsoft.EntityFrameworkCore;
using testing.Shared.Infrastructure.Persistence.EF.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TakeYourMonkeyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TakeYourMonkeyDbContext>();
    context.Database.EnsureCreated();
}
app.UseHttpsRedirection();



app.Run();
