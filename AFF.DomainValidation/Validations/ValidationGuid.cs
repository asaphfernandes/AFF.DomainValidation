using System;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations
{
    public static class ValidationGuid
    {
        public static bool HasValue(this Guid value) => value != Guid.Empty;
        public static bool HasValue(this Guid? value) => value.HasValue && value.Value.HasValue();

        public static Rule<Guid> HasValue(this Rule<Guid> rule)
        {
            rule.IsValid = rule.Value.HasValue();
            return rule;
        }
        public static Rule<Guid?> HasValue(this Rule<Guid?> rule)
        {
            rule.IsValid = rule.Value.HasValue();
            return rule;
        }
    }
}
