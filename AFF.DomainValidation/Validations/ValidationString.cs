using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations
{
    public static class ValidationString
    {
        public static bool HasValue(this string value) => value != null;

        public static bool IsLess(this string value, int max) => value.HasValue() ? value.Length < max : true;

        public static bool IsLessOrEqual(this string value, int max) => value.HasValue() ? value.Length <= max : true;

        public static bool IsGreater(this string value, int min) => value.HasValue() ? value.Length > min : true;

        public static bool IsGreaterOrEqual(this string value, int min) => value.HasValue() ? value.Length >= min : true;


        public static Rule<string> HasValue(this Rule<string> rule)
        {
            rule.IsValid = rule.Value.HasValue();
            return rule;
        }

        public static Rule<string> IsLess(this Rule<string> rule, int max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            return rule;
        }

        public static Rule<string> IsLessOrEqual(this Rule<string> rule, int max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            return rule;
        }

        public static Rule<string> IsGreater(this Rule<string> rule, int min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            return rule;
        }

        public static Rule<string> IsGreaterOrEqual(this Rule<string> rule, int min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            return rule;
        }
    }
}
