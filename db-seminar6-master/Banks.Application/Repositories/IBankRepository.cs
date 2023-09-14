using Banks.Domain.Entities;

namespace Banks.Application.Repositories;

public interface IBankRepository
{
    Task<Bank?> FindBankByNameAsync(string name);
    Task AddBankAsync(Bank bank);
    Task ChangeBankNameAsync(Bank bank, string newName);
    Task DeleteBankAsync(Bank bank);
}