using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations;

public static class ValidationDecimal
{
  public static Rule<decimal> Required(this Rule<decimal> rule) => ValidationValue.Required(rule);

  public static Rule<decimal> MinValue(this Rule<decimal> rule, decimal min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<decimal> MaxValue(this Rule<decimal> rule, decimal max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<decimal> RangeValue(this Rule<decimal> rule, decimal min, decimal max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static Rule<decimal?> Required(this Rule<decimal?> rule) => ValidationValue.Required(rule);

  public static Rule<decimal?> MinValue(this Rule<decimal?> rule, decimal min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<decimal?> MaxValue(this Rule<decimal?> rule, decimal max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<decimal?> RangeValue(this Rule<decimal?> rule, decimal min, decimal max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static bool HasPrecision(this decimal value, int decimals)
  {
    if (decimals < 0 || decimals > 28) throw new System.ArgumentOutOfRangeException(nameof(decimals));
    return decimal.Round(value, decimals) == value;
  }

  public static Rule<decimal> Precision(this Rule<decimal> rule, int decimals)
  {
    rule.SetValidation(rule.Value.HasPrecision(decimals), Langs.Resource.Validation_Precision, rule.Property, decimals, rule.Value);
    return rule;
  }
  public static Rule<decimal?> Precision(this Rule<decimal?> rule, int decimals)
  {
    if (decimals < 0 || decimals > 28) throw new System.ArgumentOutOfRangeException(nameof(decimals));
    rule.SetValidation(!rule.Value.HasValue || rule.Value.Value.HasPrecision(decimals), Langs.Resource.Validation_Precision, rule.Property, decimals, rule.Value);
    return rule;
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
