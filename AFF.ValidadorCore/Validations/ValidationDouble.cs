using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations
{
    public static class ValidationDouble
    {
        public static bool IsLess(this double value, double max) => value < max;
        public static bool IsLess(this double? value, double max) => value.HasValue ? value < max : true;

        public static bool IsLessOrEqual(this double value, double max) => value <= max;
        public static bool IsLessOrEqual(this double? value, double max) => value.HasValue? value <= max: true;

        public static bool IsGreater(this double value, double min) => value > min;
        public static bool IsGreater(this double? value, double min) => value.HasValue? value > min: true;

        public static bool IsGreaterOrEqual(this double value, double min) => value >= min;
        public static bool IsGreaterOrEqual(this double? value, double min) => value.HasValue? value >= min: true;

        public static bool Between(this double value, double min, double max) => value >= min && value <= max;
        public static bool Between(this double? value, double min, double max) => value.HasValue ? value >= min && value <= max : true;


        public static Rule<double> IsLess(this Rule<double> rule, double max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<double?> IsLess(this Rule<double?> rule, double max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<double> IsLessOrEqual(this Rule<double> rule, double max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<double?> IsLessOrEqual(this Rule<double?> rule, double max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<double> IsGreater(this Rule<double> rule, double min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<double?> IsGreater(this Rule<double?> rule, double min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<double> IsGreaterOrEqual(this Rule<double> rule, double min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<double?> IsGreaterOrEqual(this Rule<double?> rule, double min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<double> Between(this Rule<double> rule, double min, double max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
        public static Rule<double?> Between(this Rule<double?> rule, double min, double max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
    }
}
