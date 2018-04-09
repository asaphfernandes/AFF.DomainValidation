namespace AFF.DomainValidation.Validations
{
    public static class ValidationString
    {
        public static bool HasValue(this string value) => value != null;

        public static bool IsLess(this string value, int max) => value.HasValue() ? value.Length < max : true;

        public static bool IsLessOrEqual(this string value, int max) => value.HasValue() ? value.Length <= max : true;

        public static bool IsGreater(this string value, int min) => value.HasValue() ? value.Length > min : true;

        public static bool IsGreaterOrEqual(this string value, int min) => value.HasValue() ? value.Length >= min : true;
    }
}
