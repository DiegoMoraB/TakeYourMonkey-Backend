using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using testing.Monardos.Domain.Model.Aggregates;
using testing.Owners.Domain.Model.Aggregates;

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
        builder.Entity<Owner>().HasKey(x => x.Id);
        builder.Entity<Owner>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Owner>().OwnsOne(x => x.Username, n =>
        {
            n.WithOwner().HasForeignKey("Id");
            
            n.Property(u => u.username).IsRequired().HasMaxLength(16);
        });
        
        builder.Entity<TypeOfMonkey>().HasKey(x => x.Id);
        builder.Entity<TypeOfMonkey>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TypeOfMonkey>().Property(x => x.Name).IsRequired().HasMaxLength(30);
        
        builder.Entity<Monkey>().HasKey(x => x.Id);
        builder.Entity<Monkey>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Monkey>().Property(x => x.Name).IsRequired().HasMaxLength(16);
        builder.Entity<Monkey>().HasOne(x => x.TypeOfMonkey)
            .WithMany(n => n.Monkeys)
            .HasForeignKey(x => x.TypeOfMonkeyId)
            .IsRequired();
    }
    
}