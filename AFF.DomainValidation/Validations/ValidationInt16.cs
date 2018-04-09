namespace AFF.DomainValidation.Validations
{
    public static class ValidationInt16
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
    }
}
