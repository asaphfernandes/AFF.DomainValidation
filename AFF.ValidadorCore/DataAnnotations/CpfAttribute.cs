using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace AFF.ValidadorCore.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class CpfAttribute : ValidationAttribute
{
  public CpfAttribute() : base(() => Langs.Resource.CpfAttribute) { }

  public override bool IsValid(object value)
  {
    if (value == null) return true;
    if (!(value is string cpf)) return false;
    if (string.IsNullOrWhiteSpace(cpf)) return true;
    cpf = cpf.Trim();
    if (Regex.IsMatch(cpf, @"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}$", RegexOptions.CultureInvariant, TimeSpan.FromSeconds(1)))
      cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
    if (cpf.Length != 11 || cpf.Any(c => c < '0' || c > '9') || cpf.All(c => c == cpf[0])) return false;
    for (var digit = 9; digit < 11; digit++)
    {
      var sum = 0;
      for (var i = 0; i < digit; i++)
        sum += (cpf[i] - '0') * (digit + 1 - i);
      var check = 11 - sum % 11;
      if (check >= 10) check = 0;
      if (cpf[digit] - '0' != check) return false;
    }
    return true;
  }
}
