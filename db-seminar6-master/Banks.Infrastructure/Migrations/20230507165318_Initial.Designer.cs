﻿// <auto-generated />
using System;
using Banks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Banks.Infrastructure.Migrations
{
    [DbContext(typeof(BanksDbContext))]
    [Migration("20230507165318_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Banks.Domain.Entities.Atm", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<decimal>("RemainingCurrency")
                        .HasColumnType("money");

                    b.HasKey("Number")
                        .HasName("PK__ATM__78A1A19CF2E68C66");

                    b.HasIndex("BankId");

                    b.ToTable("ATM", (string)null);
                });

            modelBuilder.Entity("Banks.Domain.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ__Bank__737584F644F65807")
                        .IsUnique();

                    b.ToTable("Bank", (string)null);
                });

            modelBuilder.Entity("Banks.Domain.Entities.Client", b =>
                {
                    b.Property<int>("PassportId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.HasKey("PassportId")
                        .HasName("PK__Client__185653D09941AA6E");

                    b.HasIndex("BankId");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Banks.Domain.Entities.CreditCard", b =>
                {
                    b.Property<string>("Number")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<int>("ClientPassportId")
                        .HasColumnType("int");

                    b.Property<short>("Cvv")
                        .HasColumnType("smallint")
                        .HasColumnName("CVV");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,0)");

                    b.Property<DateTime>("ValidityPerson")
                        .HasColumnType("date");

                    b.HasKey("Number")
                        .HasName("PK__CreditCa__78A1A19C553FBB93");

                    b.HasIndex("ClientPassportId");

                    b.ToTable("CreditCard", (string)null);
                });

            modelBuilder.Entity("Banks.Domain.Entities.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int>("AtmNumber")
                        .HasColumnType("int");

                    b.Property<string>("CreditCardNumber")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("AtmNumber");

                    b.HasIndex("CreditCardNumber");

                    b.ToTable("Operation", (string)null);
                });

            modelBuilder.Entity("Banks.Domain.Entities.Atm", b =>
                {
                    b.HasOne("Banks.Domain.Entities.Bank", "Bank")
                        .WithMany("Atms")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ATM__BankId__29572725");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Banks.Domain.Entities.Client", b =>
                {
                    b.HasOne("Banks.Domain.Entities.Bank", "Bank")
                        .WithMany("Clients")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Client__BankId__31EC6D26");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Banks.Domain.Entities.CreditCard", b =>
                {
                    b.HasOne("Banks.Domain.Entities.Client", "ClientPassport")
                        .WithMany("CreditCards")
                        .HasForeignKey("ClientPassportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__CreditCar__Clien__36B12243");

                    b.Navigation("ClientPassport");
                });

            modelBuilder.Entity("Banks.Domain.Entities.Operation", b =>
                {
                    b.HasOne("Banks.Domain.Entities.Atm", "AtmNumberNavigation")
                        .WithMany("Operations")
                        .HasForeignKey("AtmNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Operation__AtmNu__3A81B327");

                    b.HasOne("Banks.Domain.Entities.CreditCard", "CreditCardNumberNavigation")
                        .WithMany("Operations")
                        .HasForeignKey("CreditCardNumber")
                        .HasConstraintName("FK__Operation__Credi__3B75D760");

                    b.Navigation("AtmNumberNavigation");

                    b.Navigation("CreditCardNumberNavigation");
                });

            modelBuilder.Entity("Banks.Domain.Entities.Atm", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("Banks.Domain.Entities.Bank", b =>
                {
                    b.Navigation("Atms");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Banks.Domain.Entities.Client", b =>
                {
                    b.Navigation("CreditCards");
                });

            modelBuilder.Entity("Banks.Domain.Entities.CreditCard", b =>
                {
                    b.Navigation("Operations");
                });
#pragma warning restore 612, 618
        }
    }
}
