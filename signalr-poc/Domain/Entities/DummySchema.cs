using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace signalr_poc.Domain.Entities;

public class DummySchema : IEntityTypeConfiguration<Dummy>
{
    public void Configure(EntityTypeBuilder<Dummy> builder)
    {
        builder.ToTable(builder.Metadata.ClrType.Name);

        builder.Property(m => m.Id).IsRequired();
        builder.Property(m => m.Label).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(500).IsRequired();

        builder.HasKey(it => it.Id);
    }
}