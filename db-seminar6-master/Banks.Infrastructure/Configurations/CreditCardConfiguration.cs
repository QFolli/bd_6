using Banks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banks.Infrastructure.Configurations;

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.HasKey(e => e.Number)
            .HasName("PK__CreditCa__78A1A19C553FBB93");

        builder.ToTable("CreditCard");

        builder.Property(e => e.Number)
            .HasMaxLength(16)
            .IsUnicode(false);

        builder.Property(e => e.Cvv).HasColumnName("CVV");

        builder.Property(e => e.Fee).HasColumnType("decimal(18, 0)");

        builder.Property(e => e.ValidityPerson).HasColumnType("date");

        builder.HasOne(d => d.ClientPassport)
            .WithMany(p => p.CreditCards)
            .HasForeignKey(d => d.ClientPassportId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK__CreditCar__Clien__36B12243");
    }
}