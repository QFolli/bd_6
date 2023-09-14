using System.ComponentModel.DataAnnotations;

namespace Banks.Domain.Entities;

public class Bank : IValidatableObject
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Atm> Atms { get; set; }
    public ICollection<Client> Clients { get; set; }
    
    public Bank(string name)
    {
        Name = name;
        Atms = new HashSet<Atm>();
        Clients = new HashSet<Client>();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Name.Length is < 2 or > 255)
        {
            yield return new ValidationResult("Название банка должно содержать от 2 до 255 символов");
        }
    }
}