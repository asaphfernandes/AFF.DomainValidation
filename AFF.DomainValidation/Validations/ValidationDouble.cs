using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations
{
  public static class ValidationDouble
  {
    public static bool IsLess(this double value, double max) => value < max;
    public static bool IsLess(this double? value, double max) => value.HasValue ? value < max : true;

    public static bool IsLessOrEqual(this double value, double max) => value <= max;
    public static bool IsLessOrEqual(this double? value, double max) => value.HasValue ? value <= max : true;

    public static bool IsGreater(this double value, double min) => value > min;
    public static bool IsGreater(this double? value, double min) => value.HasValue ? value > min : true;

    public static bool IsGreaterOrEqual(this double value, double min) => value >= min;
    public static bool IsGreaterOrEqual(this double? value, double min) => value.HasValue ? value >= min : true;

    public static bool Between(this double value, double min, double max) => value >= min && value <= max;
    public static bool Between(this double? value, double min, double max) => value.HasValue ? value >= min && value <= max : true;


    public static Rule<double> IsLess(this Rule<double> rule, double max)
    {
      rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
      return rule;
    }
    public static Rule<double?> IsLess(this Rule<double?> rule, double max)
    {
      rule.SetValidation(rule.Value.IsLess(max), Langs.Resource.Validation_IsLess, rule.Property, max, rule.Value);
      return rule;
    }

    public static Rule<double> IsLessOrEqual(this Rule<double> rule, double max)
    {
      rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
      return rule;
    }
    public static Rule<double?> IsLessOrEqual(this Rule<double?> rule, double max)
    {
      rule.SetValidation(rule.Value.IsLessOrEqual(max), Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, rule.Value);
      return rule;
    }

    public static Rule<double> IsGreater(this Rule<double> rule, double min)
    {
      rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
      return rule;
    }
    public static Rule<double?> IsGreater(this Rule<double?> rule, double min)
    {
      rule.SetValidation(rule.Value.IsGreater(min), Langs.Resource.Validation_IsGreater, rule.Property, min, rule.Value);
      return rule;
    }

    public static Rule<double> IsGreaterOrEqual(this Rule<double> rule, double min)
    {
      rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
      return rule;
    }
    public static Rule<double?> IsGreaterOrEqual(this Rule<double?> rule, double min)
    {
      rule.SetValidation(rule.Value.IsGreaterOrEqual(min), Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, rule.Value);
      return rule;
    }

    public static Rule<double> Between(this Rule<double> rule, double min, double max)
    {
      rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
      return rule;
    }
    public static Rule<double?> Between(this Rule<double?> rule, double min, double max)
    {
      rule.SetValidation(rule.Value.Between(min, max), Langs.Resource.Validation_Between, rule.Property, min, max, rule.Value);
      return rule;
    }
  }
}
