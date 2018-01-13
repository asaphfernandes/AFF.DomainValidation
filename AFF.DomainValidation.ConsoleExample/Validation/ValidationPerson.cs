using AFF.DomainValidation.ConsoleExample.Entity;
using AFF.DomainValidation.Entity;
using AFF.DomainValidation.Validations;

namespace AFF.DomainValidation.ConsoleExample.Validation
{
    class ValidationPerson : ValidationBase<Person>
    {
        public ValidationPerson(Person obj) : base(obj)
        {
        }

        public override ValidationResult Validate()
        {
            AddIsSatisfiedBy("Name must have 50 characters.", NameLenght);

            return _ValidationResult;
        }

        private EStatus NameLenght(Person arg)
        {
            return arg.Name.IsLessOrEqual(50) ? EStatus.SUCCESS : EStatus.ERROR;
        }
    }
}
