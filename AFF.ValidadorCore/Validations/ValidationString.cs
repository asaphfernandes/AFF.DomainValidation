using System;
using System.Linq;
using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations;

public static class ValidationString
{
  public static Rule<string> Required(this Rule<string> rule) => ValidationValue.Required(rule);

  public static bool HasValue(this string value) => value != null;

  public static bool IsLess(this string value, int max) => value.HasValue() ? value.Length < max : true;

  public static bool IsLessOrEqual(this string value, int max) => value.HasValue() ? value.Length <= max : true;

  public static bool IsGreater(this string value, int min) => value.HasValue() ? value.Length > min : true;

  public static bool IsGreaterOrEqual(this string value, int min) => value.HasValue() ? value.Length >= min : true;

  public static bool Between(this string value, int min, int max) => value == null || value.Length >= min && value.Length <= max;

  public static bool IsOnlyNumber(this string value) => !string.IsNullOrWhiteSpace(value) && value.All(char.IsDigit);


  public static Rule<string> MinLength(this Rule<string> rule, int min)
  {
    if (min < 0) throw new ArgumentOutOfRangeException(nameof(min));
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinLength, rule.Property, min, rule.Value?.Length ?? 0);
    return rule;
  }

  public static Rule<string> MaxLength(this Rule<string> rule, int max)
  {
    if (max < 0) throw new ArgumentOutOfRangeException(nameof(max));
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxLength, rule.Property, max, rule.Value?.Length ?? 0);
    return rule;
  }

  public static Rule<string> RangeLength(this Rule<string> rule, int min, int max)
  {
    if (min < 0 || min > max) throw new ArgumentOutOfRangeException(nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactLength : Langs.Resource.Validation_RangeLength;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value?.Length ?? 0);
    return rule;
  }

  public static Rule<string> OnlyNumber(this Rule<string> rule)
  {
    rule.SetValidation(rule.Value.IsOnlyNumber(), Langs.Resource.Validation_OnlyNumber, rule.Property);
    return rule;
  }


  public static Rule<string> HasValue(this Rule<string> rule)
  {
    rule.SetValidation(rule.Value.HasValue(), Langs.Resource.Validation_HasValue, rule.Property);
    return rule;
  }

  public static Rule<string> IsLess(this Rule<string> rule, int max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<string> IsLessOrEqual(this Rule<string> rule, int max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<string> IsGreater(this Rule<string> rule, int min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<string> IsGreaterOrEqual(this Rule<string> rule, int min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }
}
