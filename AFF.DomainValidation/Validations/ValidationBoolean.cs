using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations;

public static class ValidationBoolean
{
  public static Rule<bool> IsTrue(this Rule<bool> rule) => rule.Must(value => value);
  public static Rule<bool?> IsTrue(this Rule<bool?> rule) => rule.Must(value => !value.HasValue || value.Value);
  public static Rule<bool> IsFalse(this Rule<bool> rule) => rule.Must(value => !value);
  public static Rule<bool?> IsFalse(this Rule<bool?> rule) => rule.Must(value => !value.HasValue || !value.Value);

  public static EStatus SuccessOrError(this bool result) => result ? EStatus.SUCCESS : EStatus.ERROR;
  public static EStatus SuccessOrError(this bool result, bool equal) => result == equal ? EStatus.SUCCESS : EStatus.ERROR;

  public static EStatus SuccessOr(this bool result, EStatus status) => result ? EStatus.SUCCESS : status;
  public static EStatus SuccessOr(this bool result, EStatus status, bool equal) => result == equal ? EStatus.SUCCESS : status;
}
