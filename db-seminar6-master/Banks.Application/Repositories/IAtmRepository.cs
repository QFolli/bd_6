using Banks.Domain.Entities;

namespace Banks.Application.Repositories;

public interface IAtmRepository
{
    Task<Atm?> FindAtmByNumberAsync(int number);
    Task AddAtmAsync(Atm atm);
    Task DeleteAtmAsync(Atm atm);
    Task ChangeAtmAddressAsync(Atm atm, string newAddress);
    Task ChangeAtmBankAsync(Atm atm, Bank newBank);
}