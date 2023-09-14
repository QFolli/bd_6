using Banks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banks.Infrastructure.Configurations;

public class CreditConfiguration : IEntityTypeConfiguration<Credit>
{
    public void Configure(EntityTypeBuilder<Credit> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("Credit");

        builder.Property(e => e.Amount).HasColumnType("money");

        builder.HasOne(d => d.Client)
            .WithMany(p => p.Credits)
            .HasForeignKey(d => d.ClientId);
    }
}