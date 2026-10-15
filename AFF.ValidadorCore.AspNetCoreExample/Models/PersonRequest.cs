using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AFF.ValidadorCore.AspNetCoreExample.Validations;
using AFF.ValidadorCore.DataAnnotations;

namespace AFF.ValidadorCore.AspNetCoreExample.Models
{
  public class PersonRequest : IValidatableObject
  {
    [Required, Display(Name = "Nome")]
    public string Name { get; set; }

    [Required, Cpf, Display(Name = "CPF")]
    public string Cpf { get; set; }

    [Required, Display(Name = "Idade")]
    public int? Age { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      return new ValidationPerson(this).ValidationResult.ToValidationResults();
    }
  }
}
