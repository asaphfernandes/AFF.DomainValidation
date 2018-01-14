# AFF.DomainValidation

This is a simple library cross cutting to DDD, but you can use to any project.

The main idea of that library is to create a concept and a standart of implementation for treatment of the message. Since we have a class of the validate data, that same class can use to validate other many interation moments  of the same data.

See the example project which is in console. In it we’ll find a person entity (EntityPerson), a service class (ServicePerson) to manage the CRUD and another class for data validation (ValidationPerson). In the validation class we have the main validate, the method Validate, but is possible to add other methods of validation to the person entity, such as example, DeleteValidation, that will validate the possibility of delete the chosen registry.

When all messages are centralized in the class, that facilitates control of show for any project that is under developement. And based on the status pattern, the control how the messages will be displayed become easier.

Download the example project and see better the implementation of the Validation.

## Pre-requisites
- .Net Framework 4.5 or more
