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
    }
}
