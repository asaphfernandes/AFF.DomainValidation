namespace AFF.DomainValidation.Validations
{
    public static class ValidationDecimal
    {
        public static bool HasValue(this decimal? value) => value.HasValue;

        public static bool IsLess(this decimal value, decimal max) => value < max;

        public static bool IsLessOrEqual(this decimal value, decimal max) => value <= max;

        public static bool IsGreater(this decimal value, decimal min) => value > min;

        public static bool IsGreaterOrEqual(this decimal value, decimal min) => value >= min;
    }
}
