using Banks.Domain.Entities;
using Banks.Infrastructure;
using Banks.Infrastructure.Implementations;

await using var context = new BanksDbContext();
var bankRepository = new BankRepository(context);
var atmRepository = new AtmRepository(context);

var bank1 = new Bank("Sberbank");
await bankRepository.AddBankAsync(bank1);

var bank2 = new Bank("Exim");
await bankRepository.AddBankAsync(bank2);

var atm = new Atm("Тирасполь", bank1.Id);
await atmRepository.AddAtmAsync(atm);

//await bankRepository.DeleteBankAsync(bank1);
//await bankRepository.DeleteBankAsync(bank2);