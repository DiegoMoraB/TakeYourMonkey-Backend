using Microsoft.EntityFrameworkCore;
using testing.Monardos.Domain.Model.Entities;

namespace testing.Monardos.Infrastructure.Persistence.EF.Configuration.Extensions;

public static class ModelBuilderExtension
{
    public static void ApplyMonkeysConfiguration(this ModelBuilder builder)
    {
        builder.Entity<TypeOfMonkey>().HasKey(x => x.Id);
        builder.Entity<TypeOfMonkey>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TypeOfMonkey>().Property(x => x.Name).IsRequired().HasMaxLength(30);

        builder.Entity<TypeOfMonkey>().HasData(
            new {Id = -1, Name = "Fire"},
            new {Id = -2, Name = "Water"},
            new {Id = -3, Name = "Earth"},
            new {Id = -4, Name = "Galactic Fire"},
            new {Id = -5, Name = "Dragon Fire"},
            new {Id = -6, Name = "Sword Soul"},
            new {Id = -7, Name = "Dragon Soul"},
            new {Id = -8, Name = "Sword Soul"},
            new {Id = -9, Name = "Dragon Qilin Soul"}
            );
        
        builder.Entity<Monkey>().HasKey(x => x.Id);
        builder.Entity<Monkey>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Monkey>().Property(x => x.Name).IsRequired().HasMaxLength(16);
        builder.Entity<Monkey>().HasOne(x => x.TypeOfMonkey)
            .WithMany(n => n.Monkeys)
            .HasForeignKey(x => x.TypeOfMonkeyId)
            .IsRequired();
    }
}