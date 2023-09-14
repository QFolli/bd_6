using System.ComponentModel.DataAnnotations;

namespace Banks.Domain.Entities;

public class Atm : IValidatableObject
{
    public int Number { get; set; }
    public string Address { get; set; }
    public decimal RemainingCurrency { get; set; }
    public int BankId { get; set; }

    public Bank Bank { get; set; }
    public ICollection<Operation> Operations { get; set; }
        
    public Atm(string address, int bankId)
    {
        Address = address;
        BankId = bankId;
        Operations = new HashSet<Operation>();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (RemainingCurrency < 0)
        {
            yield return new ValidationResult("Количество оставшейся валюты не может быть отрицательным");
        }
        
        if (Address.Length is < 20 or > 255)
        {
            yield return new ValidationResult("Адрес банкомата должен содержать от 20 до 255 символов");
        }
    }
}