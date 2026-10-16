using System.Collections.Generic;
using System.Linq;
using AFF.ValidadorCore.ConsoleExample.Entity;
using AFF.ValidadorCore.Entity;
using AFF.ValidadorCore.Validations;

namespace AFF.ValidadorCore.ConsoleExample.Validations;

class ValidationPerson(Person obj, List<Person> persons) : ValidationBase<Person>(obj)
{
  private readonly List<Person> _persons = persons ?? [];

  protected override void AddRules()
  {
    RuleFor(c => c.Name).Required();
    RuleFor(c => c.Name).MinLength(2);
    RuleFor(c => c.Name).MaxLength(50);
    RuleFor(c => c.Age).MinValue(18);
  }

  public void Validate()
  {
    AddStatus("Cod must is unique.", CodUnique);
  }

  private EStatus CodUnique() => _persons.Any(w => w.Cod == Entity.Cod).SuccessOrError(false);
}
