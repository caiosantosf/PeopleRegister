using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Data.Mappings;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasMaxLength(36);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.LastName).HasMaxLength(50);
        builder.Property(x => x.CPF).HasMaxLength(11);
        builder.Property(x => x.Nacionality).HasMaxLength(50);
        builder.Property(x => x.State).HasMaxLength(2);
        builder.Property(x => x.CEP).HasMaxLength(8);
        builder.Property(x => x.City).HasMaxLength(50);
        builder.Property(x => x.Address).HasMaxLength(100);
        builder.Property(x => x.Email).HasMaxLength(200);
        builder.Property(x => x.Phone).HasMaxLength(11);
    }
}