using Domain.Entities.PersonF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.PersonF;

public class ContractstatusConfig : IEntityTypeConfiguration<Contractstatus>
{
    public void Configure(EntityTypeBuilder<Contractstatus> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("contractstatus");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("description");

    }

}