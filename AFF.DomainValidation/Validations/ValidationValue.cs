using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations;

public static class ValidationValue
{
  public static Rule<T> Required<T>(this Rule<T> rule)
  {
    var value = (object)rule.Value;
    var isValid = value != null;
    if (value is string text) isValid = !string.IsNullOrWhiteSpace(text);
    else if (value is Guid guid) isValid = guid != Guid.Empty;
    else if (value is DateTime date) isValid = date != DateTime.MinValue;
    else if (value is ICollection collection) isValid = collection.Count > 0;
    else if (value is IEnumerable enumerable) isValid = enumerable.Cast<object>().Any();
    rule.SetValidation(isValid, Langs.Resource.Validation_HasValue, rule.Property);
    return rule;
  }

  public static Rule<T> HasValue<T>(this Rule<T> rule) => rule.Required();

  public static Rule<T> MinValue<T>(this Rule<T> rule, T min)
  {
    rule.SetValidation((object)rule.Value == null || Comparer<T>.Default.Compare(rule.Value, min) >= 0, Langs.Resource.Validation_MinValue, rule.Property, min, rule.Value);
    return rule;
  }

  public static Rule<T> MaxValue<T>(this Rule<T> rule, T max)
  {
    rule.SetValidation((object)rule.Value == null || Comparer<T>.Default.Compare(rule.Value, max) <= 0, Langs.Resource.Validation_MaxValue, rule.Property, max, rule.Value);
    return rule;
  }

  public static Rule<T> RangeValue<T>(this Rule<T> rule, T min, T max)
  {
    if (Comparer<T>.Default.Compare(min, max) > 0) throw new ArgumentException("Minimum must not exceed maximum.", nameof(min));
    var message = Comparer<T>.Default.Compare(min, max) == 0 ? Langs.Resource.Validation_ExactValue : Langs.Resource.Validation_RangeValue;
    var isValid = (object)rule.Value == null
      || Comparer<T>.Default.Compare(rule.Value, min) >= 0 && Comparer<T>.Default.Compare(rule.Value, max) <= 0;
    rule.SetValidation(isValid, message, rule.Property, min, max, rule.Value);
    return rule;
  }

  public static Rule<T> MinLength<T>(this Rule<T> rule, int min) where T : IEnumerable
  {
    if (min < 0) throw new ArgumentOutOfRangeException(nameof(min));
    var length = GetLength(rule.Value);
    rule.SetValidation(rule.Value == null || length >= min, Langs.Resource.Validation_IsGreaterOrEqual, rule.Property, min, length);
    return rule;
  }

  public static Rule<T> MaxLength<T>(this Rule<T> rule, int max) where T : IEnumerable
  {
    if (max < 0) throw new ArgumentOutOfRangeException(nameof(max));
    var length = GetLength(rule.Value);
    rule.SetValidation(rule.Value == null || length <= max, Langs.Resource.Validation_IsLessOrEqual, rule.Property, max, length);
    return rule;
  }

  public static Rule<T> RangeLength<T>(this Rule<T> rule, int min, int max) where T : IEnumerable
  {
    if (min < 0 || min > max) throw new ArgumentOutOfRangeException(nameof(min));
    var length = GetLength(rule.Value);
    rule.SetValidation(rule.Value == null || (length >= min && length <= max), Langs.Resource.Validation_Between, rule.Property, min, max, length);
    return rule;
  }

  public static Rule<T> IsDefined<T>(this Rule<T> rule)
  {
    var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
    if (!type.IsEnum) throw new ArgumentException("The selected member must be an enum.", nameof(rule));
    rule.SetValidation((object)rule.Value == null || Enum.IsDefined(type, rule.Value), Langs.Resource.Validation_Invalid, rule.Property);
    return rule;
  }

  public static Rule<string> IsEmail(this Rule<string> rule)
  {
    rule.SetValidation(new EmailAddressAttribute().IsValid(rule.Value), Langs.Resource.Validation_Invalid, rule.Property);
    return rule;
  }

  public static Rule<string> IsCpf(this Rule<string> rule)
  {
    rule.SetValidation(new DataAnnotations.CpfAttribute().IsValid(rule.Value), Langs.Resource.CpfAttribute, rule.Property);
    return rule;
  }

  private static int GetLength(IEnumerable value)
  {
    if (value == null) return 0;
    if (value is string text) return text.Length;
    if (value is ICollection collection) return collection.Count;
    return value.Cast<object>().Count();
  }
}
