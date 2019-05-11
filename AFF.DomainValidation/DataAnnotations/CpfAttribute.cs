using System.ComponentModel.DataAnnotations;

namespace AFF.DomainValidation.DataAnnotations
{
    public class CpfAttribute : ValidationAttribute
    {
        public CpfAttribute() : base()
        {
            ErrorMessage = Langs.Resource.CpfAttribute;
        }

        public override bool IsValid(object value)
        {
            return false;
        }
    }
}
