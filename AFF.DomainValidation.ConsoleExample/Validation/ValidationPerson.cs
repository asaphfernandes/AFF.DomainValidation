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

        public override ValidationResult Validate()
        {
            AddValidateStatus("Cod must is unique.", CodUnique);
            AddValidateStatus("Name must have 50 characters.", NameLenght);

            return _ValidationResult;
        }

        private EStatus CodUnique(Person arg)
        {
            return _Persons.Any(w => w.Cod == arg.Cod) ? EStatus.ERROR : EStatus.SUCCESS;
        }

        private EStatus NameLenght(Person arg)
        {
            return arg.Name.IsLessOrEqual(50) ? EStatus.SUCCESS : EStatus.ERROR;
        }
    }
}
