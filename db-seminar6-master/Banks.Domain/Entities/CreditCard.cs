using System.ComponentModel.DataAnnotations;

namespace Banks.Domain.Entities;

public class CreditCard : IValidatableObject
{
    public string Number { get; set; } = null!;
    public DateTime ValidityPerson { get; set; }
    public short Cvv { get; set; }
    public decimal Fee { get; set; }
    public int ClientPassportId { get; set; }

    public Client? ClientPassport { get; set; }
    public ICollection<Operation> Operations { get; set; }
        
    public CreditCard()
    {
        Operations = new HashSet<Operation>();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Number.Length is < 16 or > 24 || !CheckLuna())
        {
            yield return new ValidationResult("Некорректный номер карты");
        }

        var today = DateTime.Now;
        if (ValidityPerson < today)
        {
            yield return new ValidationResult("Некорректный срок действия");
        }
        
        if (Cvv is < 0 or > 10000)
        {
            yield return new ValidationResult("Некорректный cvv");
        }
    }
    
    // Проверка валидности номера карты алгоритмом Луна
    // Почему бы и нет:)
    private bool CheckLuna()
    {
        var number = Number.Replace(" ", "");
        var sum = 0;
        var isSecond = false;
    
        for (var i = number.Length - 1; i >= 0; i--)
        {
            var currentDigit = int.Parse(number[i].ToString());
        
            if (isSecond)
            {
                currentDigit *= 2;
            
                if (currentDigit > 9)
                {
                    currentDigit -= 9;
                }
            }
        
            sum += currentDigit;
            isSecond = !isSecond;
        }
    
        return sum % 10 == 0;
    }
}