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
    RuleFor(c => c.Age).IsGreaterOrEqual(18);
  }

  public void Validate()
  {
    AddStatus("Cod must is unique.", CodUnique);
    AddStatus("Name must have 50 characters.", NameLenght);
  }

  private EStatus CodUnique() => _persons.Any(w => w.Cod == Entity.Cod).SuccessOrError(false);
  private EStatus NameLenght() => Entity.Name.IsLessOrEqual(50) ? EStatus.SUCCESS : EStatus.ERROR;
}
