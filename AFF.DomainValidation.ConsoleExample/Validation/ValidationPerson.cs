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
            AddValidateStatus("Cod must is unique.", CodUnique);
            AddValidateStatus("Name must have 50 characters.", NameLenght);
        }

        private EStatus CodUnique(Person arg) => _Persons.Any(w => w.Cod == arg.Cod).SuccessOrError(false);
        private EStatus NameLenght(Person arg) => arg.Name.IsLessOrEqual(50) ? EStatus.SUCCESS : EStatus.ERROR;
    }
}
