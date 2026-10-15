using System;
using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations;

public static class ValidationSingle
{
  public static bool IsLess(this float value, float max) => value < max;
  public static bool IsLess(this float? value, float max) => value.HasValue ? value < max : true;

  public static bool IsLessOrEqual(this float value, float max) => value <= max;
  public static bool IsLessOrEqual(this float? value, float max) => value.HasValue ? value <= max : true;

  public static bool IsGreater(this float value, float min) => value > min;
  public static bool IsGreater(this float? value, float min) => value.HasValue ? value > min : true;

  public static bool IsGreaterOrEqual(this float value, float min) => value >= min;
  public static bool IsGreaterOrEqual(this float? value, float min) => value.HasValue ? value >= min : true;

  public static bool Between(this float value, float min, float max) => value >= min && value <= max;
  public static bool Between(this float? value, float min, float max) => value.HasValue ? value >= min && value <= max : true;


  public static Rule<float> IsLess(this Rule<float> rule, float max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<float?> IsLess(this Rule<float?> rule, float max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<float> IsLessOrEqual(this Rule<float> rule, float max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<float?> IsLessOrEqual(this Rule<float?> rule, float max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<float> IsGreater(this Rule<float> rule, float min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<float?> IsGreater(this Rule<float?> rule, float min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<float> IsGreaterOrEqual(this Rule<float> rule, float min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<float?> IsGreaterOrEqual(this Rule<float?> rule, float min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<float> Between(this Rule<float> rule, float min, float max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
  public static Rule<float?> Between(this Rule<float?> rule, float min, float max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
}
