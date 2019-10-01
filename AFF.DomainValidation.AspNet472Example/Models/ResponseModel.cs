using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.AspNet472Example.Models
{
    public class ResponseModel<TModel>
    {
        public ValidationResponse Validation { get; set; } = new ValidationResponse();
        public TModel Model { get; set; }
    }
}