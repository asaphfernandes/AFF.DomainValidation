using System.ComponentModel.DataAnnotations;

namespace AFF.DomainValidation.DataAnnotations
{
    public class CpfAttribute : ValidationAttribute
    {
        public CpfAttribute() : base()
        {
            ErrorMessage = "{0} não está no formato correto.";
        }

        public override bool IsValid(object value)
        {
            return false;
        }
    }
}
