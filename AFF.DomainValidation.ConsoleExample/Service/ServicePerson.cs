using System;
using AFF.DomainValidation.ConsoleExample.Entity;
using AFF.DomainValidation.ConsoleExample.Validation;

namespace AFF.DomainValidation.ConsoleExample.Service
{
    class ServicePerson
    {
        public void Add(Person entity)
        {
            var response = new ValidationPerson(entity).Validate();

            if (response.IsValid)
                Console.WriteLine("Person was inserted with success.");
            else
            {
                foreach (var error in response.ItensError)
                    Console.WriteLine(error.Message);
            }
        }
    }
}
