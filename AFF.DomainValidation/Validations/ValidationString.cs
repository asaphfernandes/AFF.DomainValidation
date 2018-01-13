namespace AFF.DomainValidation.Validations
{
    public static class ValidationString
    {
        public static bool HasValue(this string value) => !string.IsNullOrWhiteSpace(value);

        public static bool IsLess(this string value, int max) => !string.IsNullOrWhiteSpace(value) ? value.Length < max : true;

        public static bool IsLessOrEqual(this string value, int max) => !string.IsNullOrWhiteSpace(value) ? value.Length <= max : true;

        public static bool IsGreater(this string value, int min) => !string.IsNullOrWhiteSpace(value) ? value.Length > min : true;

        public static bool IsGreaterOrEqual(this string value, int min) => !string.IsNullOrWhiteSpace(value) ? value.Length >= min : true;
    }
}
