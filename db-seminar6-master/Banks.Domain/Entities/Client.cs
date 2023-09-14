using System.ComponentModel.DataAnnotations;
using Banks.Domain.Enums;

namespace Banks.Domain.Entities;

public class Client : IValidatableObject
{
    public int PassportId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Patronymic { get; set; }
    public decimal Balance { get; set; }
    public string? Phone { get; set; }
    public string Address { get; set; } = null!;
    public ClientCategories Category { get; set; }
    public int BankId { get; set; }

    public Bank Bank { get; set; } = null!;
    public ICollection<CreditCard> CreditCards { get; set; }
    public ICollection<Credit> Credits { get; set; }

    public Client()
    {
        CreditCards = new HashSet<CreditCard>();
        Credits = new HashSet<Credit>();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (FirstName.Length is < 2 or > 20)
        {
            yield return new ValidationResult("Имя клиента должно содержать от 2 до 20 символов");
        }

        if (LastName.Length < 2)
        {
            yield return new ValidationResult("Фамилия клиента должно содержать от 2 до 20 символов");
        }

        if (Patronymic?.Length < 2)
        {
            yield return new ValidationResult("Отчество клиента должно содержать от 2 до 20 символов");
        }

        if (Phone?.Length is < 8 or > 14)
        {
            yield return new ValidationResult("Номер телефона клиента должен содержать от 8 до 14 символов");
        }

        if (Address.Length < 255)
        {
            yield return new ValidationResult("Адрес клиента должен содержать не более 255-ти символов");
        }
    }
}