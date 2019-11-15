using System;
using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations
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
            rule.Message = Langs.Resource.Validation_HasValue;
            rule.Values = new object[] { rule.Property };
            return rule;
        }
    }
}
