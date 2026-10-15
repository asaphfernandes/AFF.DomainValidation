using System;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations;

public static class ValidationDateTimeOffset
{
  public static bool IsLess(this DateTimeOffset value, DateTimeOffset max) => value < max;
  public static bool IsLess(this DateTimeOffset? value, DateTimeOffset max) => value.HasValue ? value < max : true;

  public static bool IsLessOrEqual(this DateTimeOffset value, DateTimeOffset max) => value <= max;
  public static bool IsLessOrEqual(this DateTimeOffset? value, DateTimeOffset max) => value.HasValue ? value <= max : true;

  public static bool IsGreater(this DateTimeOffset value, DateTimeOffset min) => value > min;
  public static bool IsGreater(this DateTimeOffset? value, DateTimeOffset min) => value.HasValue ? value > min : true;

  public static bool IsGreaterOrEqual(this DateTimeOffset value, DateTimeOffset min) => value >= min;
  public static bool IsGreaterOrEqual(this DateTimeOffset? value, DateTimeOffset min) => value.HasValue ? value >= min : true;

  public static bool Between(this DateTimeOffset value, DateTimeOffset min, DateTimeOffset max) => value >= min && value <= max;
  public static bool Between(this DateTimeOffset? value, DateTimeOffset min, DateTimeOffset max) => value.HasValue ? value >= min && value <= max : true;


  public static Rule<DateTimeOffset> IsLess(this Rule<DateTimeOffset> rule, DateTimeOffset max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<DateTimeOffset?> IsLess(this Rule<DateTimeOffset?> rule, DateTimeOffset max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateTimeOffset> IsLessOrEqual(this Rule<DateTimeOffset> rule, DateTimeOffset max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<DateTimeOffset?> IsLessOrEqual(this Rule<DateTimeOffset?> rule, DateTimeOffset max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<DateTimeOffset> IsGreater(this Rule<DateTimeOffset> rule, DateTimeOffset min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<DateTimeOffset?> IsGreater(this Rule<DateTimeOffset?> rule, DateTimeOffset min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateTimeOffset> IsGreaterOrEqual(this Rule<DateTimeOffset> rule, DateTimeOffset min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<DateTimeOffset?> IsGreaterOrEqual(this Rule<DateTimeOffset?> rule, DateTimeOffset min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<DateTimeOffset> Between(this Rule<DateTimeOffset> rule, DateTimeOffset min, DateTimeOffset max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
  public static Rule<DateTimeOffset?> Between(this Rule<DateTimeOffset?> rule, DateTimeOffset min, DateTimeOffset max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
}
