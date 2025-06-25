using Microsoft.EntityFrameworkCore;
using testing.Owners.Domain.Model.Aggregates;

namespace testing.Owners.Infrastructure.Persistence.EF.Configuration.Extensions;

public static class ModelBuilderExtension
{
    public static void ApplyOwnersConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Owner>().HasKey(x => x.Id);
        builder.Entity<Owner>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Owner>().OwnsOne(x => x.Username, n =>
        {
            n.WithOwner().HasForeignKey("Id");
            
            n.Property(u => u.username).IsRequired().HasMaxLength(16);
        });
    }
}