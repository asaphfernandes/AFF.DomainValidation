using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations;

public static class Validationlong64
{
  public static Rule<long> Required(this Rule<long> rule) => ValidationValue.Required(rule);

  public static Rule<long> MinValue(this Rule<long> rule, long min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<long> MaxValue(this Rule<long> rule, long max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<long> RangeValue(this Rule<long> rule, long min, long max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static Rule<long?> Required(this Rule<long?> rule) => ValidationValue.Required(rule);

  public static Rule<long?> MinValue(this Rule<long?> rule, long min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<long?> MaxValue(this Rule<long?> rule, long max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<long?> RangeValue(this Rule<long?> rule, long min, long max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static bool IsLess(this long value, long max) => value < max;
  public static bool IsLess(this long? value, long max) => value.HasValue ? value < max : true;

  public static bool IsLessOrEqual(this long value, long max) => value <= max;
  public static bool IsLessOrEqual(this long? value, long max) => value.HasValue ? value <= max : true;

  public static bool IsGreater(this long value, long min) => value > min;
  public static bool IsGreater(this long? value, long min) => value.HasValue ? value > min : true;

  public static bool IsGreaterOrEqual(this long value, long min) => value >= min;
  public static bool IsGreaterOrEqual(this long? value, long min) => value.HasValue ? value >= min : true;

  public static bool Between(this long value, long min, long max) => value >= min && value <= max;
  public static bool Between(this long? value, long min, long max) => value.HasValue ? value >= min && value <= max : true;


  public static Rule<long> IsLess(this Rule<long> rule, long max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<long?> IsLess(this Rule<long?> rule, long max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<long> IsLessOrEqual(this Rule<long> rule, long max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<long?> IsLessOrEqual(this Rule<long?> rule, long max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<long> IsGreater(this Rule<long> rule, long min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<long?> IsGreater(this Rule<long?> rule, long min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<long> IsGreaterOrEqual(this Rule<long> rule, long min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<long?> IsGreaterOrEqual(this Rule<long?> rule, long min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<long> Between(this Rule<long> rule, long min, long max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
  public static Rule<long?> Between(this Rule<long?> rule, long min, long max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
}
