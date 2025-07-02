using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using testing.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using testing.Monardos.Infrastructure.Persistence.EF.Configuration.Extensions;
using testing.Owners.Infrastructure.Persistence.EF.Configuration.Extensions;

namespace testing.Shared.Infrastructure.Persistence.EF.Configuration;

public class TakeYourMonkeyDbContext : DbContext
{
    public TakeYourMonkeyDbContext(DbContextOptions<TakeYourMonkeyDbContext> options) : base(options){}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    
        builder.ApplyOwnersConfiguration();
        builder.ApplyMonkeysConfiguration();
        builder.ApplyIamConfiguration();
    }
    
}