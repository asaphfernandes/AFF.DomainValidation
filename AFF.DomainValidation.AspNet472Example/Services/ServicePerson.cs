using AFF.DomainValidation.AspNet472Example.Models;
using AFF.DomainValidation.AspNet472Example.Validations;
using System.Collections.Generic;
using System.Linq;

namespace AFF.DomainValidation.AspNet472Example.Services
{
    public class ServicePerson
    {
        private static List<PersonModel> Persons { get; } = new List<PersonModel> { };

        public List<PersonModel> Get()
        {
            return Persons;
        }

        public PersonModel Get(int cod)
        {
            return Persons.Where(w => w.Cod == cod).SingleOrDefault();
        }

        public ResponseModel<PersonModel> Add(PersonModel entity)
        {
            var validation = new ValidationPerson(entity, Persons);

            validation.Validate();

            if (validation.ValidationResult.IsValid)
                Persons.Add(entity);

            return new ResponseModel<PersonModel> { Model = entity, Validation = validation.ValidationResult };
        }
    }
}