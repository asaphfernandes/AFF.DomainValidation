# AFF.DomainValidation

Domain validation with fluent rules, localized messages and DataAnnotations. The existing directory organization and namespaces are preserved.

## Packages

| Package 2.0.0 | Namespace | Targets |
| --- | --- | --- |
| AFF.DomainValidation | AFF.DomainValidation | .NET Framework 4.8 / 4.8.1 and .NET 9 / 10 |
| AFF.ValidadorCore | AFF.ValidadorCore | .NET 9 / 10 |

Choose the package matching your namespace. Build with the .NET 10 SDK and C# 14. Framework execution requires Windows. C# 14 is explicitly configured as requested; shared code uses syntax and APIs available on the target runtimes. Microsoft officially associates C# 14 with .NET 10.

```sh
dotnet add package AFF.DomainValidation --version 2.0.0
```

## Fluent rules

```csharp
using AFF.DomainValidation.Validations;

public class PersonValidation : ValidationBase<Person>
{
  public PersonValidation(Person person) : base(person) { }

  protected override void AddRules()
  {
    RuleFor(p => p.Name).Required().MinLength(2).MaxLength(50);
    RuleFor(p => p.Age).Required().MinValue(18).MaxValue(120);
    RuleFor(p => p.Cpf).IsCpf();
  }
}

var response = new PersonValidation(person).ValidationResult;
foreach (var item in response.ItensError)
  Console.WriteLine(item.Message);
```

Each condition in a chain is retained and automatically emits SUCCESS or ERROR; calling `Validate()` in `AddRules` is optional. Explicit `Validate` calls remain available for custom messages and statuses. The existing `ValidateSuccess`, `ValidateInfo`, `ValidateAlert`, `ValidateWarning` and `ValidateError` emit their named status **when the condition is true**, otherwise nothing, preserving their original behavior.

Use `.Must(value => predicate).WithMessage("Custom message.")` for custom rules. `WithMessage` applies to the immediately preceding condition. Messages support positional arguments (`{0}` is the display name). `RuleFor` honors localized `[Display]` attributes, member conversions and nested paths such as `p => p.Address.City`; nested objects must exist when evaluated.

Existing comparison extensions are preserved. Added validators cover `float`, `DateTimeOffset`, `TimeSpan`, `DateOnly`, `TimeOnly`, nullable values, booleans (`IsTrue` / `IsFalse`), enums (`IsDefined`), strings / arrays / collections (`MinLength`, `MaxLength`, `RangeLength`), email (`IsEmail`) and decimal precision (`Precision`). `DateOnly` and `TimeOnly` require a modern .NET target. `MinValue`, `MaxValue` and `RangeValue` support comparable values with inclusive bounds. Null optional values pass range checks; use `Required` for mandatory fields. `Required` accepts zero and false, rejects blank strings, empty collections, `Guid.Empty` and `DateTime.MinValue`.

String length rules are defined in `ValidationString` and report the number of characters, including the current length. `RangeLength(n, n)` requires an exact length. Null strings pass length checks; use `Required` to reject missing or blank text. `OnlyNumber` requires a nonempty string containing only digits. Collection length rules use the item count. `RangeDefaultValue` supports `DateTime` (01/01/1900 through 31/12/2099) and `TimeSpan` (00:00:00 through 23:59:59), including nullable forms.

Both packages expose the same rules by type:

| Types | Rules |
| --- | --- |
| `string` | `Required`, `MinLength`, `MaxLength`, `RangeLength`, `OnlyNumber`, `IsEmail`, `IsCpf` |
| `short`, `int`, `long`, `float`, `double`, `decimal` and nullable forms | `Required`, `MinValue`, `MaxValue`, `RangeValue` |
| `decimal`, `decimal?` | `Precision` with the allowed decimal places and current value in the message |
| `DateTime`, `DateTimeOffset`, `TimeSpan`, `DateOnly`, `TimeOnly` and nullable forms | `Required`, `MinValue`, `MaxValue`, `RangeValue` |
| `Guid`, `Guid?` | `Required` rejects `Guid.Empty` |
| `bool`, `bool?` | `Required`, `IsTrue`, `IsFalse` |
| Enums and nullable enums | `Required`, `IsDefined` |
| Arrays and collections | `Required`, `MinLength`, `MaxLength`, `RangeLength` |

Numeric and temporal rules are available in their type-specific validation classes. The generic comparable rules remain available for other types. Bounds are inclusive; equal range bounds require that exact value. Optional nullable values pass comparisons; `Required` rejects their absence. Numeric zero and boolean false remain valid required values. The original comparison methods remain available.

`ValidationResponse.Itens` preserves insertion order and normalizes null assignments to an empty collection. `Add` merges responses; protected `AddRange` merges items. Items expose `MemberNames` and `Created` (UTC). `IsValid` retains its SUCCESS-only behavior. `ToValidationResults()` converts ALERT, WARNING and ERROR into DataAnnotations results, excluding SUCCESS and INFO.

Derived validators can await `AddErrorAsync` and `AddStatusAsync` with cancellation. An error is emitted when the error predicate is true; a null status is skipped. Invoke and await asynchronous checks explicitly after construction. `AddRules` runs in the base constructor; checks depending on injected services must run afterwards.

## ASP.NET model validation

`[Cpf]` works on MVC ViewModels and requests alongside standard DataAnnotations. It accepts digits or the standard CPF mask, rejects invalid characters without throwing, and allows missing values. Use `[Required, Cpf]` for mandatory CPF fields.

To integrate fluent rules with `ModelState`, implement `IValidatableObject`:

```csharp
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AFF.DomainValidation.DataAnnotations;
using AFF.DomainValidation.Validations;

public class PersonRequest : IValidatableObject
{
  [Required, Display(Name = "Nome")]
  public string Name { get; set; }
  [Required, Cpf]
  public string Cpf { get; set; }
  [Required]
  public int? Age { get; set; }

  public IEnumerable<ValidationResult> Validate(ValidationContext context)
  {
    return new RequestValidation(this).ValidationResult.ToValidationResults();
  }
}

public class RequestValidation : ValidationBase<PersonRequest>
{
  public RequestValidation(PersonRequest request) : base(request, validateAttributes: false) { }

  protected override void AddRules()
  {
    RuleFor(p => p.Name).MaxLength(50);
    RuleFor(p => p.Age).MinValue(18);
  }
}
```

Inside `IValidatableObject`, use `validateAttributes: false` because MVC already validates the attributes; this also avoids recursion. By default, the library validates annotations using the actual model context, supporting `[Compare]`, class attributes and `IValidatableObject`, following standard DataAnnotations validation order.

MVC uses `ModelState.IsValid` / `TryValidateModel`; `[ApiController]` returns HTTP 400 automatically with member names in `ValidationProblemDetails`. The library needs no MVC dependency or custom registration. Minimal APIs need their own framework validation setup.

## Examples and tests

The existing console examples are retained. `AFF.DomainValidation.AspNet472Example` keeps its directory name and targets Framework 4.8.1; open it in Visual Studio with the ASP.NET workload for IIS Express.

`AFF.ValidadorCore.AspNetCoreExample` runs on .NET 9/10 and combines annotations with fluent rules:

```sh
dotnet run --project AFF.ValidadorCore.AspNetCoreExample -f net10.0 --urls http://localhost:5080
curl -i http://localhost:5080/people -H "Content-Type: application/json" -d '{"name":"Ana","cpf":"52998224725","age":16}'
```

Age 16 returns HTTP 400 with an `Age` error; age 18 returns HTTP 200.

```sh
dotnet build AFF.ValidadorCore.sln -c Release
dotnet test AFF.ValidadorCore.Tests -c Release
dotnet test AFF.DomainValidation.Tests -c Release
```

The shared xUnit suite covers both namespaces and all six targets: annotations, model context, fluent chains, custom messages, nested paths, optional values, boundaries, CPF, enums, collections, localization, aggregation and asynchronous cancellation. Build `AFF.DomainValidation.sln` with Visual Studio MSBuild to include the classic ASP.NET project.

## Migration and NuGet

2.0 drops .NET Framework versions below 4.8 and .NET Core 3.0. Fluent chains now validate every condition instead of just the last. CPF follows DataAnnotations optional-field semantics and accepts masks. Custom `IValidation` implementations must now expose `ValidationResult`. Existing namespaces, status ordering, the `Itens` spelling and terminal rule semantics remain available.

SDK project files replace the standalone nuspec. Packages contain README, MIT license, XML API files, repository metadata and portable symbols (`.snupkg`). The SDK supplies GitHub Source Link metadata. Pack releases from a clean committed checkout so source links match the distributed code.

```sh
dotnet pack AFF.DomainValidation/AFF.DomainValidation.csproj -c Release -o artifacts/packages
dotnet pack AFF.ValidadorCore/AFF.ValidadorCore.csproj -c Release -o artifacts/packages
```

Review the packages before publishing 2.0.0 to NuGet.org. No automatic publication is configured.

References: [C# versions](https://learn.microsoft.com/dotnet/csharp/language-reference/language-versioning), [target frameworks](https://learn.microsoft.com/dotnet/standard/frameworks), [MVC validation](https://learn.microsoft.com/aspnet/core/mvc/models/validation), [NuGet authoring](https://learn.microsoft.com/nuget/create-packages/package-authoring-best-practices).
