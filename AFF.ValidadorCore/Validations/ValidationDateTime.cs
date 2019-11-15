using System;
using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations
{
    public static class ValidationDateTime
    {
        public static bool HasValue(this DateTime value) => value != DateTime.MinValue;
        public static bool HasValue(this DateTime? value) => value.HasValue && value.Value.HasValue();

        public static bool IsLess(this DateTime value, DateTime max) => value.HasValue() ? value < max : true;
        public static bool IsLess(this DateTime? value, DateTime max) => value.HasValue() ? value < max : true;

        public static bool IsLessOrEqual(this DateTime value, DateTime max) => value.HasValue() ? value <= max : true;
        public static bool IsLessOrEqual(this DateTime? value, DateTime max) => value.HasValue() ? value <= max : true;

        public static bool IsGreater(this DateTime value, DateTime min) => value.HasValue() ? value > min : true;
        public static bool IsGreater(this DateTime? value, DateTime min) => value.HasValue() ? value > min : true;

        public static bool IsGreaterOrEqual(this DateTime value, DateTime min) => value.HasValue() ? value >= min : true;
        public static bool IsGreaterOrEqual(this DateTime? value, DateTime min) => value.HasValue() ? value >= min : true;

        public static bool Between(this DateTime value, DateTime min, DateTime max) => value.HasValue() ? value >= min && value <= max : true;
        public static bool Between(this DateTime? value, DateTime min, DateTime max) => value.HasValue() ? value >= min && value <= max : true;


        public static Rule<DateTime> IsLess(this Rule<DateTime> rule, DateTime max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<DateTime?> IsLess(this Rule<DateTime?> rule, DateTime max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<DateTime> IsLessOrEqual(this Rule<DateTime> rule, DateTime max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<DateTime?> IsLessOrEqual(this Rule<DateTime?> rule, DateTime max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<DateTime> IsGreater(this Rule<DateTime> rule, DateTime min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<DateTime?> IsGreater(this Rule<DateTime?> rule, DateTime min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<DateTime> IsGreaterOrEqual(this Rule<DateTime> rule, DateTime min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<DateTime?> IsGreaterOrEqual(this Rule<DateTime?> rule, DateTime min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<DateTime> Between(this Rule<DateTime> rule, DateTime min, DateTime max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
        public static Rule<DateTime?> Between(this Rule<DateTime?> rule, DateTime min, DateTime max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
    }
}
