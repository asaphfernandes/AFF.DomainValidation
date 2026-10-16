#if NET6_0_OR_GREATER
using System;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations;

public static class ValidationDateOnly
{
  public static Rule<DateOnly> Required(this Rule<DateOnly> rule) => ValidationValue.Required(rule);

  public static Rule<DateOnly> MinValue(this Rule<DateOnly> rule, DateOnly min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateOnly> MaxValue(this Rule<DateOnly> rule, DateOnly max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateOnly> RangeValue(this Rule<DateOnly> rule, DateOnly min, DateOnly max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static Rule<DateOnly?> Required(this Rule<DateOnly?> rule) => ValidationValue.Required(rule);

  public static Rule<DateOnly?> MinValue(this Rule<DateOnly?> rule, DateOnly min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateOnly?> MaxValue(this Rule<DateOnly?> rule, DateOnly max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateOnly?> RangeValue(this Rule<DateOnly?> rule, DateOnly min, DateOnly max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static bool IsLess(this DateOnly value, DateOnly max) => value < max;
  public static bool IsLess(this DateOnly? value, DateOnly max) => value.HasValue ? value < max : true;

  public static bool IsLessOrEqual(this DateOnly value, DateOnly max) => value <= max;
  public static bool IsLessOrEqual(this DateOnly? value, DateOnly max) => value.HasValue ? value <= max : true;

  public static bool IsGreater(this DateOnly value, DateOnly min) => value > min;
  public static bool IsGreater(this DateOnly? value, DateOnly min) => value.HasValue ? value > min : true;

  public static bool IsGreaterOrEqual(this DateOnly value, DateOnly min) => value >= min;
  public static bool IsGreaterOrEqual(this DateOnly? value, DateOnly min) => value.HasValue ? value >= min : true;

  public static bool Between(this DateOnly value, DateOnly min, DateOnly max) => value >= min && value <= max;
  public static bool Between(this DateOnly? value, DateOnly min, DateOnly max) => value.HasValue ? value >= min && value <= max : true;


  public static Rule<DateOnly> IsLess(this Rule<DateOnly> rule, DateOnly max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<DateOnly?> IsLess(this Rule<DateOnly?> rule, DateOnly max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateOnly> IsLessOrEqual(this Rule<DateOnly> rule, DateOnly max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<DateOnly?> IsLessOrEqual(this Rule<DateOnly?> rule, DateOnly max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateOnly> IsGreater(this Rule<DateOnly> rule, DateOnly min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<DateOnly?> IsGreater(this Rule<DateOnly?> rule, DateOnly min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateOnly> IsGreaterOrEqual(this Rule<DateOnly> rule, DateOnly min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<DateOnly?> IsGreaterOrEqual(this Rule<DateOnly?> rule, DateOnly min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateOnly> Between(this Rule<DateOnly> rule, DateOnly min, DateOnly max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
  public static Rule<DateOnly?> Between(this Rule<DateOnly?> rule, DateOnly min, DateOnly max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
}
#endif
