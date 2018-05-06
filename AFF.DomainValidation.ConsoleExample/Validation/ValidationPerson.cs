using System.Collections.Generic;
using System.Linq;
using AFF.DomainValidation.ConsoleExample.Entity;
using AFF.DomainValidation.Entity;
using AFF.DomainValidation.Validations;

namespace AFF.DomainValidation.ConsoleExample.Validation
{
    class ValidationPerson : ValidationBase<Person>
    {
        private List<Person> _Persons;

        public ValidationPerson(Person obj, List<Person> persons) : base(obj)
        {
            _Persons = persons;
        }

        public void Validate()
        {
            AddStatus("Cod must is unique.", CodUnique);
            AddStatus("Name must have 50 characters.", NameLenght);
        }

        private EStatus CodUnique(Person entity) => _Persons.Any(w => w.Cod == entity.Cod).SuccessOrError(false);
        private EStatus NameLenght(Person entity) => entity.Name.IsLessOrEqual(50) ? EStatus.SUCCESS : EStatus.ERROR;
    }
}
