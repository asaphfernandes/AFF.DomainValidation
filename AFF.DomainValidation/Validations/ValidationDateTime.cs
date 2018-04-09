using System;

namespace AFF.DomainValidation.Validations
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
    }
}
