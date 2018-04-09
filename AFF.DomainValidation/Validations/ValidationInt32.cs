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
    }
}
