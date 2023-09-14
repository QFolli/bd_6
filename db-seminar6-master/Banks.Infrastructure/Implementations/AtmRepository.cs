using Banks.Application.Repositories;
using Banks.Domain.Entities;

namespace Banks.Infrastructure.Implementations;

public class AtmRepository : IAtmRepository
{
    private readonly BanksDbContext _context;

    public AtmRepository(BanksDbContext context)
    {
        _context = context;
    }

    public async Task<Atm?> FindAtmByNumberAsync(int number) =>
        await _context.Atms.FindAsync(number);

    public async Task AddAtmAsync(Atm atm)
    {
        await _context.Atms.AddAsync(atm);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAtmAsync(Atm atm)
    {
        _context.Atms.Remove(atm);
        await _context.SaveChangesAsync();
    }

    public async Task ChangeAtmAddressAsync(Atm atm, string newAddress)
    {
        atm.Address = newAddress;
        await _context.SaveChangesAsync();
    }

    public async Task ChangeAtmBankAsync(Atm atm, Bank newBank)
    {
        atm.Bank = newBank;
        await _context.SaveChangesAsync();
    }
}