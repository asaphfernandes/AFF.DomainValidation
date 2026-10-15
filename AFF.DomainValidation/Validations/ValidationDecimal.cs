using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations
{
  public static class ValidationDecimal
  {
    public static bool HasPrecision(this decimal value, int decimals)
    {
      if (decimals < 0 || decimals > 28) throw new System.ArgumentOutOfRangeException(nameof(decimals));
      return decimal.Round(value, decimals) == value;
    }

    public static Rule<decimal> Precision(this Rule<decimal> rule, int decimals) => rule.Must(value => value.HasPrecision(decimals));
    public static Rule<decimal?> Precision(this Rule<decimal?> rule, int decimals)
    {
      if (decimals < 0 || decimals > 28) throw new System.ArgumentOutOfRangeException(nameof(decimals));
      return rule.Must(value => !value.HasValue || value.Value.HasPrecision(decimals));
    }

    public static bool IsLess(this decimal value, decimal max) => value < max;
    public static bool IsLess(this decimal? value, decimal max) => value.HasValue ? value < max : true;

    public static bool IsLessOrEqual(this decimal value, decimal max) => value <= max;
    public static bool IsLessOrEqual(this decimal? value, decimal max) => value.HasValue ? value <= max : true;

    public static bool IsGreater(this decimal value, decimal min) => value > min;
    public static bool IsGreater(this decimal? value, decimal min) => value.HasValue ? value > min : true;

    public static bool IsGreaterOrEqual(this decimal value, decimal min) => value >= min;
    public static bool IsGreaterOrEqual(this decimal? value, decimal min) => value.HasValue ? value >= min : true;

    public static bool Between(this decimal value, decimal min, decimal max) => value >= min && value <= max;
    public static bool Between(this decimal? value, decimal min, decimal max) => value.HasValue ? value >= min && value <= max : true;


    public static Rule<decimal> IsLess(this Rule<decimal> rule, decimal max)
    {
      rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
      return rule;
    }
    public static Rule<decimal?> IsLess(this Rule<decimal?> rule, decimal max)
    {
      rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
      return rule;
    }

    public static Rule<decimal> IsLessOrEqual(this Rule<decimal> rule, decimal max)
    {
      rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
      return rule;
    }
    public static Rule<decimal?> IsLessOrEqual(this Rule<decimal?> rule, decimal max)
    {
      rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
      return rule;
    }

    public static Rule<decimal> IsGreater(this Rule<decimal> rule, decimal min)
    {
      rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
      return rule;
    }
    public static Rule<decimal?> IsGreater(this Rule<decimal?> rule, decimal min)
    {
      rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
      return rule;
    }

    public static Rule<decimal> IsGreaterOrEqual(this Rule<decimal> rule, decimal min)
    {
      rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
      return rule;
    }
    public static Rule<decimal?> IsGreaterOrEqual(this Rule<decimal?> rule, decimal min)
    {
      rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
      return rule;
    }

    public static Rule<decimal> Between(this Rule<decimal> rule, decimal min, decimal max)
    {
      rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
      return rule;
    }
    public static Rule<decimal?> Between(this Rule<decimal?> rule, decimal min, decimal max)
    {
      rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
      return rule;
    }
  }
}
