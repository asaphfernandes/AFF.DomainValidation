using AFF.DomainValidation.AspNet472Example.Models;
using AFF.DomainValidation.Entity;
using AFF.DomainValidation.Validations;
using System.Collections.Generic;
using System.Linq;

namespace AFF.DomainValidation.AspNet472Example.Validations
{
    public class ValidationPerson : ValidationBase<PersonModel>
    {
        private List<PersonModel> _Persons;

        public ValidationPerson(PersonModel obj, List<PersonModel> persons) : base(obj)
        {
            _Persons = persons;
        }

        protected override void AddRules()
        {
            RuleFor(c => c.Age).IsGreaterOrEqual(18).Validate();
        }

        public void Validate()
        {
            AddStatus("Cod must is unique.", CodUnique);
            AddStatus("Name must have 50 characters.", NameLenght);
        }

        private EStatus CodUnique(PersonModel entity) => _Persons.Any(w => w.Cod == entity.Cod).SuccessOrError(false);
        private EStatus NameLenght(PersonModel entity) => entity.Name.IsLessOrEqual(50) ? EStatus.SUCCESS : EStatus.ERROR;
    }
}