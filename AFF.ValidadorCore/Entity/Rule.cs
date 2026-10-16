using System;
using System.Collections.Generic;
using System.Globalization;

namespace AFF.ValidadorCore.Entity;

public class Rule<TKey> : Rule
{
  public Rule(string property, object value) : base(property)
  {
    Value = (TKey)value;
  }

  public TKey Value { get; private set; }

  public Rule<TKey> Must(Func<TKey, bool> predicate)
  {
    if (predicate == null) throw new ArgumentNullException(nameof(predicate));
    SetValidation(predicate(Value), Langs.Resource.Validation_Invalid, Property);
    return this;
  }

  public Rule<TKey> SetMessage(string message)
  {
    Message = message ?? throw new ArgumentNullException(nameof(message));
    return this;
  }
}

public class Rule
{
  public Rule(string property)
  {
    Property = property;
  }

  internal string Property { get; set; }
  internal string MemberName { get; set; }
  internal bool? IsValid { get; set; }
  internal EStatus? EStatus { get; set; }
  internal object[] Values { get; set; } = new object[0];
  private readonly List<Rule> _conditions = new List<Rule>();

  internal IEnumerable<Rule> Conditions
  {
    get
    {
      foreach (var condition in _conditions)
        yield return condition;
      yield return this;
    }
  }

  internal void SetValidation(bool isValid, string message, params object[] values)
  {
    if (IsValid.HasValue)
      _conditions.Add(new Rule(Property) { MemberName = MemberName, IsValid = IsValid, EStatus = EStatus, Message = _message, Values = Values });
    IsValid = isValid;
    EStatus = isValid ? Entity.EStatus.SUCCESS : Entity.EStatus.ERROR;
    Message = message;
    Values = values;
  }

  private string _message { get; set; } = string.Empty;
  public string Message
  {
    get
    {
      return string.Format(CultureInfo.CurrentCulture, _message, Values);
    }
    internal set
    {
      _message = value;
    }
  }

  public void Validate()
  {
    Validate(Entity.EStatus.SUCCESS, Entity.EStatus.ERROR);
  }
  public void Validate(string message)
  {
    Validate(message, Entity.EStatus.SUCCESS, Entity.EStatus.ERROR);
  }

  public void Validate(EStatus isValidStatus)
  {
    Validate(isValidStatus, Entity.EStatus.ERROR);
  }
  public void Validate(EStatus isValidStatus, EStatus? isNotValidStatus)
  {
    foreach (var condition in Conditions)
    {
      if (condition.IsValid.HasValue)
        condition.EStatus = condition.IsValid.Value ? isValidStatus : isNotValidStatus;
    }
  }

  public void Validate(string message, EStatus isValidStatus)
  {
    Validate(message, isValidStatus, Entity.EStatus.ERROR);
  }
  public void Validate(string message, EStatus isValidStatus, EStatus? isNotValidStatus)
  {
    Validate(isValidStatus, isNotValidStatus);
    Message = message;
  }

  public void ValidateSuccess()
  {
    Validate(Entity.EStatus.SUCCESS, null);
  }
  public void ValidateSuccess(string message)
  {
    Validate(message, Entity.EStatus.SUCCESS, null);
  }

  public void ValidateInfo()
  {
    Validate(Entity.EStatus.INFO, null);
  }
  public void ValidateInfo(string message)
  {
    Validate(message, Entity.EStatus.INFO, null);
  }

  public void ValidateAlert()
  {
    Validate(Entity.EStatus.ALERT, null);
  }
  public void ValidateAlert(string message)
  {
    Validate(message, Entity.EStatus.ALERT, null);
  }

  public void ValidateWarning()
  {
    Validate(Entity.EStatus.WARNING, null);
  }
  public void ValidateWarning(string message)
  {
    Validate(message, Entity.EStatus.WARNING, null);
  }

  public void ValidateError()
  {
    Validate(Entity.EStatus.ERROR, null);
  }
  public void ValidateError(string message)
  {
    Validate(message, Entity.EStatus.ERROR, null);
  }
}
