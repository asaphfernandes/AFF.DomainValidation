using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations
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
            rule.Message = Langs.Resource.Validation_HasValue;
            rule.Values = new object[] { rule.Property };
            return rule;
        }

        public static Rule<string> IsLess(this Rule<string> rule, int max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<string> IsLessOrEqual(this Rule<string> rule, int max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<string> IsGreater(this Rule<string> rule, int min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<string> IsGreaterOrEqual(this Rule<string> rule, int min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
    }
}
