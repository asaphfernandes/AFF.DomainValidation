using System;

namespace AFF.DomainValidation.Validations
{
    public static class ValidationDateTime
    {
        public static bool HasValue(this DateTime value) => value != DateTime.MinValue;
        public static bool HasValue(this DateTime? value) => value.HasValue && value.Value.HasValue();
    }
}
