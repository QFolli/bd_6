using Banks.Application.Repositories;
using Banks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banks.Infrastructure.Implementations;

public class BankRepository : IBankRepository
{
    private readonly BanksDbContext _context;

    public BankRepository(BanksDbContext context)
    {
        _context = context;
    }
    
    public async Task<Bank?> FindBankByNameAsync(string name) =>
        await _context.Banks.FirstOrDefaultAsync(b => b.Name == name);

    public async Task AddBankAsync(Bank bank)
    {
        await _context.Banks.AddAsync(bank);
        await _context.SaveChangesAsync();
    }

    public async Task ChangeBankNameAsync(Bank bank, string newName)
    {
        bank.Name = newName;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBankAsync(Bank bank)
    {
        _context.Banks.Remove(bank);
        await _context.SaveChangesAsync();
    }
}