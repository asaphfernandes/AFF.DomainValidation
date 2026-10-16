using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations;

public static class ValidationInt32
{
  public static Rule<int> Required(this Rule<int> rule) => ValidationValue.Required(rule);

  public static Rule<int> MinValue(this Rule<int> rule, int min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<int> MaxValue(this Rule<int> rule, int max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<int> RangeValue(this Rule<int> rule, int min, int max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static Rule<int?> Required(this Rule<int?> rule) => ValidationValue.Required(rule);

  public static Rule<int?> MinValue(this Rule<int?> rule, int min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<int?> MaxValue(this Rule<int?> rule, int max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<int?> RangeValue(this Rule<int?> rule, int min, int max)
  {
    if (min > max) throw new System.ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = min == max ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    rule.SetValidation(rule.Value.Between(min, max), message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static bool IsLess(this int value, int max) => value < max;
  public static bool IsLess(this int? value, int max) => value.HasValue ? value < max : true;

  public static bool IsLessOrEqual(this int value, int max) => value <= max;
  public static bool IsLessOrEqual(this int? value, int max) => value.HasValue ? value <= max : true;

  public static bool IsGreater(this int value, int min) => value > min;
  public static bool IsGreater(this int? value, int min) => value.HasValue ? value > min : true;

  public static bool IsGreaterOrEqual(this int value, int min) => value >= min;
  public static bool IsGreaterOrEqual(this int? value, int min) => value.HasValue ? value >= min : true;

  public static bool Between(this int value, int min, int max) => value >= min && value <= max;
  public static bool Between(this int? value, int min, int max) => value.HasValue ? value >= min && value <= max : true;


  public static Rule<int> IsLess(this Rule<int> rule, int max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<int?> IsLess(this Rule<int?> rule, int max)
  {
    rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<int> IsLessOrEqual(this Rule<int> rule, int max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }
  public static Rule<int?> IsLessOrEqual(this Rule<int?> rule, int max)
  {
    rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<int> IsGreater(this Rule<int> rule, int min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<int?> IsGreater(this Rule<int?> rule, int min)
  {
    rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<int> IsGreaterOrEqual(this Rule<int> rule, int min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }
  public static Rule<int?> IsGreaterOrEqual(this Rule<int?> rule, int min)
  {
    rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<int> Between(this Rule<int> rule, int min, int max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
  public static Rule<int?> Between(this Rule<int?> rule, int min, int max)
  {
    rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
    return rule;
  }
}
