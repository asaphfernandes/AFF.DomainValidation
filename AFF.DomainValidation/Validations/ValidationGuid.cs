using System;

namespace AFF.DomainValidation.Validations
{
    public static class ValidationGuid
    {
        public static bool HasValue(this Guid value) => value != Guid.Empty;
        public static bool HasValue(this Guid? value) => value.HasValue && value.Value.HasValue();
    }
}
