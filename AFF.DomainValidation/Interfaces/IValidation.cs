using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Interfaces;

public interface IValidation
{
  ValidationResponse ValidationResult { get; }
}
