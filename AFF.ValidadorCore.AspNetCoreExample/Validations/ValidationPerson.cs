using AFF.ValidadorCore.AspNetCoreExample.Models;
using AFF.ValidadorCore.Validations;

namespace AFF.ValidadorCore.AspNetCoreExample.Validations
{
  public class ValidationPerson : ValidationBase<PersonRequest>
  {
    // MVC validates the attributes before calling IValidatableObject.
    public ValidationPerson(PersonRequest request) : base(request, validateAttributes: false) { }

    protected override void AddRules()
    {
      RuleFor(p => p.Name).Required().MaxLength(50);
      RuleFor(p => p.Age).Required().MinValue(18).MaxValue(120);
    }
  }
}
