using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations
{
    public static class ValidationInt64
    {
        public static bool IsLess(this long value, long max) => value < max;
        public static bool IsLess(this long? value, long max) => value.HasValue ? value < max : true;

        public static bool IsLessOrEqual(this long value, long max) => value <= max;
        public static bool IsLessOrEqual(this long? value, long max) => value.HasValue? value <= max: true;

        public static bool IsGreater(this long value, long min) => value > min;
        public static bool IsGreater(this long? value, long min) => value.HasValue? value > min: true;

        public static bool IsGreaterOrEqual(this long value, long min) => value >= min;
        public static bool IsGreaterOrEqual(this long? value, long min) => value.HasValue? value >= min: true;

        public static bool Between(this long value, long min, long max) => value >= min && value <= max;
        public static bool Between(this long? value, long min, long max) => value.HasValue ? value >= min && value <= max : true;


        public static Rule<long> IsLess(this Rule<long> rule, long max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            return rule;
        }
        public static Rule<long?> IsLess(this Rule<long?> rule, long max)
        {
            rule.IsValid = rule.Value.IsLess(max);
            return rule;
        }

        public static Rule<long> IsLessOrEqual(this Rule<long> rule, long max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            return rule;
        }
        public static Rule<long?> IsLessOrEqual(this Rule<long?> rule, long max)
        {
            rule.IsValid = rule.Value.IsLessOrEqual(max);
            return rule;
        }

        public static Rule<long> IsGreater(this Rule<long> rule, long min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            return rule;
        }
        public static Rule<long?> IsGreater(this Rule<long?> rule, long min)
        {
            rule.IsValid = rule.Value.IsGreater(min);
            return rule;
        }

        public static Rule<long> IsGreaterOrEqual(this Rule<long> rule, long min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            return rule;
        }
        public static Rule<long?> IsGreaterOrEqual(this Rule<long?> rule, long min)
        {
            rule.IsValid = rule.Value.IsGreaterOrEqual(min);
            return rule;
        }

        public static Rule<long> Between(this Rule<long> rule, long min, long max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            return rule;
        }
        public static Rule<long?> Between(this Rule<long?> rule, long min, long max)
        {
            rule.IsValid = rule.Value.Between(min, max);
            return rule;
        }
    }
}
