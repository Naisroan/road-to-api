using Domain.Entities.Persons;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            personId => personId.Value,
            value => new PersonId(value)
        );

        builder.Property(c => c.FirstName).HasMaxLength(50);

        builder.Property(c => c.MiddleName).HasMaxLength(50).IsRequired(false);

        builder.Property(c => c.LastName).HasMaxLength(50);

        builder.Property(c => c.MaternalLastName).HasMaxLength(50).IsRequired(false);

        builder.Property(c => c.Rfc).HasConversion(
            rfc => rfc == null ? null : rfc.Value,
            value => Rfc.Create(value, default)
        )
        .HasMaxLength(13);

        builder.Property(c => c.Curp).HasConversion(
            curp => curp == null ? null : curp.Value,
            value => Curp.Create(value)
        )
        .HasMaxLength(18)
        .IsRequired(false);

        builder.Property(c => c.Active);

        builder.Ignore(c => c.FullName);

        builder.Ignore(c => c.ShortName);

        builder.Ignore(c => c.InformalShortName);

        builder.HasIndex(c => c.FirstName);

        builder.HasIndex(c => c.MiddleName);

        builder.HasIndex(c => c.LastName);

        builder.HasIndex(c => c.MaternalLastName);

        builder.HasIndex(c => c.Rfc);

        builder.HasIndex(c => c.Curp);
    }
}