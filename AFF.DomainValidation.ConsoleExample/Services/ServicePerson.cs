using System.Collections.Generic;
using AFF.DomainValidation.ConsoleExample.Entity;
using AFF.DomainValidation.ConsoleExample.Validations;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.ConsoleExample.Services
{
    internal class ServicePerson
    {
        public ServicePerson()
        {
            _Persons = new List<Person>();
        }

        private List<Person> _Persons;

        public List<Person> Get()
        {
            return _Persons;
        }

        public ValidationResponse Add(Person entity)
        {
            var validation = new ValidationPerson(entity, _Persons);

            validation.Validate();

            if (validation.ValidationResult.IsValid)
                _Persons.Add(entity);

            return validation.ValidationResult;
        }
    }
}
