using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Interfaces;

  public interface IValidation
  {
      ValidationResponse ValidationResult { get; }
  }
