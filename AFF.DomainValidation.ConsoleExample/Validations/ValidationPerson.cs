using System.Collections.Generic;
using System.Linq;
using AFF.DomainValidation.ConsoleExample.Entity;
using AFF.DomainValidation.Entity;
using AFF.DomainValidation.Validations;

namespace AFF.DomainValidation.ConsoleExample.Validations
{
  class ValidationPerson : ValidationBase<Person>
  {
    private List<Person> _Persons = new List<Person>();

    public ValidationPerson(Person obj, List<Person> persons) : base(obj)
    {
      _Persons = persons ?? new List<Person>();
    }

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

    private EStatus CodUnique(Person entity) => _Persons.Any(w => w.Cod == entity.Cod).SuccessOrError(false);
  }
}
