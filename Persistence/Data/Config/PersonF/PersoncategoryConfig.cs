using Domain.Entities.PersonF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.PersonF;

public class PersoncategoryConfig : IEntityTypeConfiguration<Personcategory>
{
    public void Configure(EntityTypeBuilder<Personcategory> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("personcategory");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("description");

    }
}