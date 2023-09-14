using Banks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banks.Infrastructure.Configurations;

public class AtmConfiguration : IEntityTypeConfiguration<Atm>
{
    public void Configure(EntityTypeBuilder<Atm> builder)
    {
        builder.HasKey(e => e.Number)
            .HasName("PK__ATM__78A1A19CF2E68C66");

        builder.ToTable("ATM");

        builder.Property(e => e.Address)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(e => e.RemainingCurrency).HasColumnType("money");

        builder.HasOne(d => d.Bank)
            .WithMany(p => p.Atms)
            .HasForeignKey(d => d.BankId)
            .HasConstraintName("FK__ATM__BankId__29572725");
    }
}