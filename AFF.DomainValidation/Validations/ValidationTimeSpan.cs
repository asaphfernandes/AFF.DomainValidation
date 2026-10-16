using System;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations;

public static class ValidationTimeSpan
{
  public static Rule<TimeSpan> Required(this Rule<TimeSpan> rule) => ValidationValue.Required(rule);

  public static Rule<TimeSpan> MinValue(this Rule<TimeSpan> rule, TimeSpan min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<TimeSpan> MaxValue(this Rule<TimeSpan> rule, TimeSpan max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<TimeSpan> RangeValue(this Rule<TimeSpan> rule, TimeSpan min, TimeSpan max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static Rule<TimeSpan?> Required(this Rule<TimeSpan?> rule) => ValidationValue.Required(rule);

  public static Rule<TimeSpan?> MinValue(this Rule<TimeSpan?> rule, TimeSpan min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<TimeSpan?> MaxValue(this Rule<TimeSpan?> rule, TimeSpan max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<TimeSpan?> RangeValue(this Rule<TimeSpan?> rule, TimeSpan min, TimeSpan max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  /// <summary>Validates times between 00:00:00 and 23:59:59, inclusive.</summary>
  public static Rule<TimeSpan> RangeDefaultValue(this Rule<TimeSpan> rule) => rule.RangeValue(TimeSpan.Zero, new TimeSpan(23, 59, 59));
  public static Rule<TimeSpan?> RangeDefaultValue(this Rule<TimeSpan?> rule) => rule.RangeValue(TimeSpan.Zero, new TimeSpan(23, 59, 59));

  public static bool IsLess(this TimeSpan value, TimeSpan max) => value < max;
  public static bool IsLess(this TimeSpan? value, TimeSpan max) => value.HasValue ? value < max : true;

  public static bool IsLessOrEqual(this TimeSpan value, TimeSpan max) => value <= max;
  public static bool IsLessOrEqual(this TimeSpan? value, TimeSpan max) => value.HasValue ? value <= max : true;

  public static bool IsGreater(this TimeSpan value, TimeSpan min) => value > min;
  public static bool IsGreater(this TimeSpan? value, TimeSpan min) => value.HasValue ? value > min : true;

  public static bool IsGreaterOrEqual(this TimeSpan value, TimeSpan min) => value >= min;
  public static bool IsGreaterOrEqual(this TimeSpan? value, TimeSpan min) => value.HasValue ? value >= min : true;

  public static bool Between(this TimeSpan value, TimeSpan min, TimeSpan max) => value >= min && value <= max;
  public static bool Between(this TimeSpan? value, TimeSpan min, TimeSpan max) => value.HasValue ? value >= min && value <= max : true;


  public static Rule<TimeSpan> IsLess(this Rule<TimeSpan> rule, TimeSpan max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<TimeSpan?> IsLess(this Rule<TimeSpan?> rule, TimeSpan max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<TimeSpan> IsLessOrEqual(this Rule<TimeSpan> rule, TimeSpan max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<TimeSpan?> IsLessOrEqual(this Rule<TimeSpan?> rule, TimeSpan max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<TimeSpan> IsGreater(this Rule<TimeSpan> rule, TimeSpan min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<TimeSpan?> IsGreater(this Rule<TimeSpan?> rule, TimeSpan min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<TimeSpan> IsGreaterOrEqual(this Rule<TimeSpan> rule, TimeSpan min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<TimeSpan?> IsGreaterOrEqual(this Rule<TimeSpan?> rule, TimeSpan min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<TimeSpan> Between(this Rule<TimeSpan> rule, TimeSpan min, TimeSpan max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
  public static Rule<TimeSpan?> Between(this Rule<TimeSpan?> rule, TimeSpan min, TimeSpan max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
}
