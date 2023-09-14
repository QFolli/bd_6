using Banks.Domain.Entities;
using Banks.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Banks.Infrastructure;

public class BanksDbContext : DbContext
{
    public virtual DbSet<Atm> Atms { get; set; } = null!;
    public virtual DbSet<Bank> Banks { get; set; } = null!;
    public virtual DbSet<Client> Clients { get; set; } = null!;
    public virtual DbSet<CreditCard> CreditCards { get; set; } = null!;
    public virtual DbSet<Operation> Operations { get; set; } = null!;
    
    public BanksDbContext()
    {
    }

    public BanksDbContext(DbContextOptions<BanksDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=BanksDB;Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AtmConfiguration());
        modelBuilder.ApplyConfiguration(new BankConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
        modelBuilder.ApplyConfiguration(new OperationConfiguration());
    }
}