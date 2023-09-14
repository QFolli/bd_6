using Banks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banks.Infrastructure.Configurations;

public class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.ToTable("Bank");

        builder.HasIndex(e => e.Name, "UQ__Bank__737584F644F65807")
            .IsUnique();

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);
    }
}