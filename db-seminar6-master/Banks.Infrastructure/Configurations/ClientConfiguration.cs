using Banks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banks.Infrastructure.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(e => e.PassportId)
            .HasName("PK__Client__185653D09941AA6E");

        builder.ToTable("Client");

        builder.Property(e => e.PassportId).ValueGeneratedNever();

        builder.Property(e => e.Address)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(e => e.Balance).HasColumnType("money");

        builder.Property(e => e.FirstName)
            .HasMaxLength(20)
            .IsUnicode(false);

        builder.Property(e => e.LastName)
            .HasMaxLength(20)
            .IsUnicode(false);

        builder.Property(e => e.Patronymic)
            .HasMaxLength(20)
            .IsUnicode(false);

        builder.Property(e => e.Phone)
            .HasMaxLength(14)
            .IsUnicode(false);

        builder.HasOne(d => d.Bank)
            .WithMany(p => p.Clients)
            .HasForeignKey(d => d.BankId)
            .HasConstraintName("FK__Client__BankId__31EC6D26");
    }
}