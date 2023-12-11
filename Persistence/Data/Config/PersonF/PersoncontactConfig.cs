using Domain.Entities.PersonF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.PersonF;

public class PersoncontactConfig : IEntityTypeConfiguration<Personcontact>
{
    public void Configure(EntityTypeBuilder<Personcontact> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("personcontact");

        builder.HasIndex(e => e.FkIdContactType, "fk_idContactType");

        builder.HasIndex(e => e.FkIdPerson, "fk_idPersonCont");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(60)
            .HasColumnName("description");
        builder.Property(e => e.FkIdContactType).HasColumnName("fkIdContactType");
        builder.Property(e => e.FkIdPerson).HasColumnName("fkIdPerson");

        builder.HasOne(d => d.FkIdContactTypeNavigation).WithMany(p => p.Personcontacts)
            .HasForeignKey(d => d.FkIdContactType)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idContactType");

        builder.HasOne(d => d.FkIdPersonNavigation).WithMany(p => p.Personcontacts)
            .HasForeignKey(d => d.FkIdPerson)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_idPersonCont");

    }
}