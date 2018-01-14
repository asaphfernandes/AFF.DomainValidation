using System;
using System.Collections.Generic;
using AFF.DomainValidation.ConsoleExample.Entity;
using AFF.DomainValidation.ConsoleExample.Validation;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.ConsoleExample.Service
{
    class ServicePerson
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

        public ValidationResult Add(Person entity)
        {
            var response = new ValidationPerson(entity, _Persons).Validate();

            if (response.IsValid)
                _Persons.Add(entity);

            return response;
        }
    }
}
