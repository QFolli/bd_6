using Banks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banks.Infrastructure.Configurations;

public class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.ToTable("Operation");

        builder.Property(e => e.Amount).HasColumnType("money");

        builder.Property(e => e.CreditCardNumber)
            .HasMaxLength(16)
            .IsUnicode(false);

        builder.Property(e => e.Date).HasColumnType("date");

        builder.HasOne(d => d.AtmNumberNavigation)
            .WithMany(p => p.Operations)
            .HasForeignKey(d => d.AtmNumber)
            .HasConstraintName("FK__Operation__AtmNu__3A81B327");

        builder.HasOne(d => d.CreditCardNumberNavigation)
            .WithMany(p => p.Operations)
            .HasForeignKey(d => d.CreditCardNumber)
            .HasConstraintName("FK__Operation__Credi__3B75D760");
    }
}