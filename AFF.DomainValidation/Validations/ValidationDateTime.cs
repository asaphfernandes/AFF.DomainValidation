using System;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations;

public static class ValidationDateTime
{
  public static Rule<DateTime> Required(this Rule<DateTime> rule) => ValidationValue.Required(rule);

  public static Rule<DateTime> MinValue(this Rule<DateTime> rule, DateTime min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateTime> MaxValue(this Rule<DateTime> rule, DateTime max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateTime> RangeValue(this Rule<DateTime> rule, DateTime min, DateTime max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static Rule<DateTime?> Required(this Rule<DateTime?> rule) => ValidationValue.Required(rule);

  public static Rule<DateTime?> MinValue(this Rule<DateTime?> rule, DateTime min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateTime?> MaxValue(this Rule<DateTime?> rule, DateTime max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateTime?> RangeValue(this Rule<DateTime?> rule, DateTime min, DateTime max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  /// <summary>Validates dates between 01/01/1900 and 31/12/2099, inclusive.</summary>
  public static Rule<DateTime> RangeDefaultValue(this Rule<DateTime> rule) => rule.RangeValue(new DateTime(1900, 1, 1), new DateTime(2099, 12, 31));
  public static Rule<DateTime?> RangeDefaultValue(this Rule<DateTime?> rule) => rule.RangeValue(new DateTime(1900, 1, 1), new DateTime(2099, 12, 31));

  public static bool HasValue(this DateTime value) => value != DateTime.MinValue;
  public static bool HasValue(this DateTime? value) => value.HasValue && value.Value.HasValue();

  public static bool IsLess(this DateTime value, DateTime max) => value.HasValue() ? value < max : true;
  public static bool IsLess(this DateTime? value, DateTime max) => value.HasValue() ? value < max : true;

  public static bool IsLessOrEqual(this DateTime value, DateTime max) => value.HasValue() ? value <= max : true;
  public static bool IsLessOrEqual(this DateTime? value, DateTime max) => value.HasValue() ? value <= max : true;

  public static bool IsGreater(this DateTime value, DateTime min) => value.HasValue() ? value > min : true;
  public static bool IsGreater(this DateTime? value, DateTime min) => value.HasValue() ? value > min : true;

  public static bool IsGreaterOrEqual(this DateTime value, DateTime min) => value.HasValue() ? value >= min : true;
  public static bool IsGreaterOrEqual(this DateTime? value, DateTime min) => value.HasValue() ? value >= min : true;

  public static bool Between(this DateTime value, DateTime min, DateTime max) => value.HasValue() ? value >= min && value <= max : true;
  public static bool Between(this DateTime? value, DateTime min, DateTime max) => value.HasValue() ? value >= min && value <= max : true;


  public static Rule<DateTime> IsLess(this Rule<DateTime> rule, DateTime max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<DateTime?> IsLess(this Rule<DateTime?> rule, DateTime max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateTime> IsLessOrEqual(this Rule<DateTime> rule, DateTime max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<DateTime?> IsLessOrEqual(this Rule<DateTime?> rule, DateTime max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateTime> IsGreater(this Rule<DateTime> rule, DateTime min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<DateTime?> IsGreater(this Rule<DateTime?> rule, DateTime min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateTime> IsGreaterOrEqual(this Rule<DateTime> rule, DateTime min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<DateTime?> IsGreaterOrEqual(this Rule<DateTime?> rule, DateTime min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateTime> Between(this Rule<DateTime> rule, DateTime min, DateTime max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
  public static Rule<DateTime?> Between(this Rule<DateTime?> rule, DateTime min, DateTime max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
}
