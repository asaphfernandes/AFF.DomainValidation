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
    }
}
