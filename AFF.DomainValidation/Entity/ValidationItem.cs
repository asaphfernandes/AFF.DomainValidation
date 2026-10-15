using System;
using System.Collections.Generic;
using System.Linq;

namespace AFF.DomainValidation.Entity;

public class ValidationItem
{
  public ValidationItem(string message, EStatus status = EStatus.ERROR) : this(message, status, new string[0]) { }

  public ValidationItem(string message, EStatus status, IEnumerable<string> memberNames)
  {
    Message = message;
    Status = status;
    MemberNames = (memberNames ?? new string[0]).ToArray();
    Created = DateTime.UtcNow;
  }

  public ValidationItem(string message, bool isValid) : this(message, isValid ? EStatus.SUCCESS : EStatus.ERROR) { }

  public string Message { get; private set; }
  public EStatus Status { get; private set; }
  public IReadOnlyCollection<string> MemberNames { get; private set; } = new string[0];
  public DateTime Created { get; private set; }
}

internal static class ValidationItemExtension
{
  public static ICollection<ValidationItem> Add(this ICollection<ValidationItem> list, string msg, EStatus status)
  {
    list.Add(new ValidationItem(msg, status));
    return list;
  }

  public static ICollection<ValidationItem> Add(this ICollection<ValidationItem> list, string msg, bool isValid)
  {
    list.Add(new ValidationItem(msg, isValid));
    return list;
  }

  public static ICollection<ValidationItem> Add(this ICollection<ValidationItem> list, Rule rule)
  {
    foreach (var condition in rule.Conditions)
    {
      if (condition.EStatus.HasValue)
        list.Add(new ValidationItem(condition.Message, condition.EStatus.Value, string.IsNullOrEmpty(condition.MemberName) ? new string[0] : new[] { condition.MemberName }));
    }
    return list;
  }
}
