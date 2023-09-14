using System.ComponentModel.DataAnnotations;

namespace Banks.Domain.Entities;

public class Credit : IValidatableObject
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public int MaturityMonths { get; set; }
    public int ClientId { get; set; }

    public Client Client { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Amount < 0)
        {
            yield return new ValidationResult("Сумма не может быть отрицательной");
        }

        if (MaturityMonths < 0)
        {
            yield return new ValidationResult("Количество месяцев не может быть отрицательным");
        }
    }
}