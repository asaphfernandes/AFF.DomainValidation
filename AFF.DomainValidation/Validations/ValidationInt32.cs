using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations
{
    public static class ValidationInt32
    {
        public static bool IsLess(this int value, int max) => value < max;
        public static bool IsLess(this int? value, int max) => value.HasValue ? value < max : true;

        public static bool IsLessOrEqual(this int value, int max) => value <= max;
        public static bool IsLessOrEqual(this int? value, int max) => value.HasValue ? value <= max : true;

        public static bool IsGreater(this int value, int min) => value > min;
        public static bool IsGreater(this int? value, int min) => value.HasValue ? value > min : true;

        public static bool IsGreaterOrEqual(this int value, int min) => value >= min;
        public static bool IsGreaterOrEqual(this int? value, int min) => value.HasValue ? value >= min : true;

        public static bool Between(this int value, int min, int max) => value >= min && value <= max;
        public static bool Between(this int? value, int min, int max) => value.HasValue ? value >= min && value <= max : true;


        public static Rule<int> IsLess(this Rule<int> rule, int max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<int?> IsLess(this Rule<int?> rule, int max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<int> IsLessOrEqual(this Rule<int> rule, int max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<int?> IsLessOrEqual(this Rule<int?> rule, int max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<int> IsGreater(this Rule<int> rule, int min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<int?> IsGreater(this Rule<int?> rule, int min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<int> IsGreaterOrEqual(this Rule<int> rule, int min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<int?> IsGreaterOrEqual(this Rule<int?> rule, int min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<int> Between(this Rule<int> rule, int min, int max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
        public static Rule<int?> Between(this Rule<int?> rule, int min, int max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
    }
}
