#if NET6_0_OR_GREATER
using System;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations;

public static class ValidationTimeOnly
{
  public static bool IsLess(this TimeOnly value, TimeOnly max) => value < max;
  public static bool IsLess(this TimeOnly? value, TimeOnly max) => value.HasValue ? value < max : true;

  public static bool IsLessOrEqual(this TimeOnly value, TimeOnly max) => value <= max;
  public static bool IsLessOrEqual(this TimeOnly? value, TimeOnly max) => value.HasValue ? value <= max : true;

  public static bool IsGreater(this TimeOnly value, TimeOnly min) => value > min;
  public static bool IsGreater(this TimeOnly? value, TimeOnly min) => value.HasValue ? value > min : true;

  public static bool IsGreaterOrEqual(this TimeOnly value, TimeOnly min) => value >= min;
  public static bool IsGreaterOrEqual(this TimeOnly? value, TimeOnly min) => value.HasValue ? value >= min : true;

  public static bool Between(this TimeOnly value, TimeOnly min, TimeOnly max) => value >= min && value <= max;
  public static bool Between(this TimeOnly? value, TimeOnly min, TimeOnly max) => value.HasValue ? value >= min && value <= max : true;


  public static Rule<TimeOnly> IsLess(this Rule<TimeOnly> rule, TimeOnly max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<TimeOnly?> IsLess(this Rule<TimeOnly?> rule, TimeOnly max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<TimeOnly> IsLessOrEqual(this Rule<TimeOnly> rule, TimeOnly max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<TimeOnly?> IsLessOrEqual(this Rule<TimeOnly?> rule, TimeOnly max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<TimeOnly> IsGreater(this Rule<TimeOnly> rule, TimeOnly min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<TimeOnly?> IsGreater(this Rule<TimeOnly?> rule, TimeOnly min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<TimeOnly> IsGreaterOrEqual(this Rule<TimeOnly> rule, TimeOnly min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<TimeOnly?> IsGreaterOrEqual(this Rule<TimeOnly?> rule, TimeOnly min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<TimeOnly> Between(this Rule<TimeOnly> rule, TimeOnly min, TimeOnly max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
  public static Rule<TimeOnly?> Between(this Rule<TimeOnly?> rule, TimeOnly min, TimeOnly max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
}
#endif
