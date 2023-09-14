using System.ComponentModel.DataAnnotations;

namespace Banks.Domain.Entities;

public class Operation : IValidatableObject
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public int AtmNumber { get; set; }
    public string? CreditCardNumber { get; set; }

    public virtual Atm AtmNumberNavigation { get; set; } = null!;
    public virtual CreditCard? CreditCardNumberNavigation { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Amount < 0)
        {
            yield return new ValidationResult("Сумма операции не может быть отрицательной");
        }
    }
}