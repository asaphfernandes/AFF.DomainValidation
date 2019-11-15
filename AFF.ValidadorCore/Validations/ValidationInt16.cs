using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations
{
    public static class Validationshort16
    {
        public static bool IsLess(this short value, short max) => value < max;
        public static bool IsLess(this short? value, short max) => value.HasValue ? value < max : true;

        public static bool IsLessOrEqual(this short value, short max) => value <= max;
        public static bool IsLessOrEqual(this short? value, short max) => value.HasValue ? value <= max : true;

        public static bool IsGreater(this short value, short min) => value > min;
        public static bool IsGreater(this short? value, short min) => value.HasValue ? value > min : true;

        public static bool IsGreaterOrEqual(this short value, short min) => value >= min;
        public static bool IsGreaterOrEqual(this short? value, short min) => value.HasValue ? value >= min : true;

        public static bool Between(this short value, short min, short max) => value >= min && value <= max;
        public static bool Between(this short? value, short min, short max) => value.HasValue ? value >= min && value <= max : true;


        public static Rule<short> IsLess(this Rule<short> rule, short max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<short?> IsLess(this Rule<short?> rule, short max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<short> IsLessOrEqual(this Rule<short> rule, short max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<short?> IsLessOrEqual(this Rule<short?> rule, short max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<short> IsGreater(this Rule<short> rule, short min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<short?> IsGreater(this Rule<short?> rule, short min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<short> IsGreaterOrEqual(this Rule<short> rule, short min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<short?> IsGreaterOrEqual(this Rule<short?> rule, short min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<short> Between(this Rule<short> rule, short min, short max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
        public static Rule<short?> Between(this Rule<short?> rule, short min, short max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
    }
}
