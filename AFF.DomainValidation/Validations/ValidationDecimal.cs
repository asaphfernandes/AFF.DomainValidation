﻿using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations
{
    public static class ValidationDecimal
    {
        public static bool IsLess(this decimal value, decimal max) => value < max;
        public static bool IsLess(this decimal? value, decimal max) => value.HasValue ? value < max : true;

        public static bool IsLessOrEqual(this decimal value, decimal max) => value <= max;
        public static bool IsLessOrEqual(this decimal? value, decimal max) => value.HasValue? value <= max: true;

        public static bool IsGreater(this decimal value, decimal min) => value > min;
        public static bool IsGreater(this decimal? value, decimal min) => value.HasValue? value > min: true;

        public static bool IsGreaterOrEqual(this decimal value, decimal min) => value >= min;
        public static bool IsGreaterOrEqual(this decimal? value, decimal min) => value.HasValue? value >= min: true;

        public static bool Between(this decimal value, decimal min, decimal max) => value >= min && value <= max;
        public static bool Between(this decimal? value, decimal min, decimal max) => value.HasValue ? value >= min && value <= max : true;


        public static Rule<decimal> IsLess(this Rule<decimal> rule, decimal max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<decimal?> IsLess(this Rule<decimal?> rule, decimal max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            rule.Message = Langs.Resource.Validation_IsLess;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<decimal> IsLessOrEqual(this Rule<decimal> rule, decimal max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }
        public static Rule<decimal?> IsLessOrEqual(this Rule<decimal?> rule, decimal max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            rule.Message = Langs.Resource.Validation_IsLessOrEqual;
            rule.Values = new object[] { rule.Property, max, rule.Value };
            return rule;
        }

        public static Rule<decimal> IsGreater(this Rule<decimal> rule, decimal min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<decimal?> IsGreater(this Rule<decimal?> rule, decimal min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            rule.Message = Langs.Resource.Validation_IsGreater;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<decimal> IsGreaterOrEqual(this Rule<decimal> rule, decimal min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }
        public static Rule<decimal?> IsGreaterOrEqual(this Rule<decimal?> rule, decimal min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            rule.Message = Langs.Resource.Validation_IsGreaterOrEqual;
            rule.Values = new object[] { rule.Property, min, rule.Value };
            return rule;
        }

        public static Rule<decimal> Between(this Rule<decimal> rule, decimal min, decimal max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
        public static Rule<decimal?> Between(this Rule<decimal?> rule, decimal min, decimal max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            rule.Message = Langs.Resource.Validation_Between;
            rule.Values = new object[] { rule.Property, min, max, rule.Value };
            return rule;
        }
    }
}
