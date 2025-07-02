using Microsoft.EntityFrameworkCore;
using testing.IAM.Domain.Model.Aggregates;

namespace testing.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIamConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
        modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.PasswordHashed).IsRequired();
    }
}