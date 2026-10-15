using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
#if VALIDADOR_CORE
using AFF.ValidadorCore.DataAnnotations;
using AFF.ValidadorCore.Entity;
using AFF.ValidadorCore.Validations;
#else
using AFF.DomainValidation.DataAnnotations;
using AFF.DomainValidation.Entity;
using AFF.DomainValidation.Validations;
#endif

namespace AFF.DomainValidation.Tests
{
  public class ValidationTests
  {
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData(" ", true)]
    [InlineData("52998224725", true)]
    [InlineData("529.982.247-25", true)]
    [InlineData("52998224724", false)]
    [InlineData("00000000000", false)]
    [InlineData("11111111111", false)]
    [InlineData("abcdefghijk", false)]
    [InlineData("５２９９８２２４７２５", false)]
    [InlineData("529x98224725", false)]
    public void CpfValidatesWithoutThrowing(string value, bool expected)
    {
      Assert.Equal(expected, new CpfAttribute().IsValid(value));
    }

    [Fact]
    public void CpfRejectsNonStringValues()
    {
      Assert.False(new CpfAttribute().IsValid(52998224725L));
    }

    [Fact]
    public void RequiredOwnsMissingCpfValidation()
    {
      var response = new AnnotationValidation(new AnnotationModel { Password = "secret", Confirmation = "secret" }).ValidationResult;
      Assert.Single(response.ItensError);
      Assert.Contains("Cpf", response.ItensError.Single().MemberNames);
    }

    [Fact]
    public void AnnotationsReceiveModelContextAndDisplayName()
    {
      var response = new AnnotationValidation(new AnnotationModel { Cpf = "52998224725", Password = "secret", Confirmation = "different" }).ValidationResult;
      var item = Assert.Single(response.ItensError);
      Assert.Equal("Confirmation", Assert.Single(item.MemberNames));
      Assert.Contains("Confirmação", item.Message);
    }

    [Fact]
    public void ClassAnnotationsAndValidatableObjectsAreHonored()
    {
      Assert.Single(new ClassValidation(new ClassModel()).ValidationResult.ItensError);
      Assert.Equal("Name", Assert.Single(new ObjectValidation(new ObjectModel()).ValidationResult.ItensError.Single().MemberNames));
    }

    [Fact]
    public void FluentChainKeepsEachConditionAndMemberName()
    {
      var response = new PersonValidation(new Person { Name = " ", Age = 15 }).ValidationResult;
      Assert.Equal(2, response.ItensError.Count);
      Assert.Contains(response.ItensError, item => item.MemberNames.Contains("Name"));
      Assert.Contains(response.ItensError, item => item.MemberNames.Contains("Age"));
      Assert.Contains("Nome", response.ItensError.First().Message);
    }

    [Fact]
    public void FluentChainValidatesValidValues()
    {
      Assert.True(new PersonValidation(new Person { Name = "Ana", Age = 30 }).ValidationResult.IsValid);
    }

    [Fact]
    public void CustomMessageAppliesToItsCondition()
    {
      var response = new CustomValidation(new Person { Name = "", Age = 5 }).ValidationResult;
      Assert.Equal("Nome obrigatório.", Assert.Single(response.ItensError).Message);
    }

    [Fact]
    public void GuidHasLocalizedDefaultMessage()
    {
      var response = new GuidValidation(new GuidModel()).ValidationResult;
      Assert.Contains("Id", Assert.Single(response.ItensError).Message);
    }

    [Fact]
    public void ModelValidationBridgeDoesNotRecurse()
    {
      var results = new List<ValidationResult>();
      var model = new RequestModel { Name = "Ana", Age = 10 };
      Assert.False(Validator.TryValidateObject(model, new ValidationContext(model), results, true));
      Assert.Equal("Age", Assert.Single(Assert.Single(results).MemberNames));
    }

    [Fact]
    public void NestedAndConvertedMemberExpressionsAreSupported()
    {
      var response = new NestedValidation(new NestedModel { Person = new Person { Age = 10 } }).ValidationResult;
      Assert.Contains(response.ItensError, item => item.MemberNames.Contains("Person.Age"));
      Assert.Contains(response.ItensError, item => item.MemberNames.Contains("Number"));
    }

    [Fact]
    public void InvalidSelectorsAndNullModelsFailClearly()
    {
      Assert.Throws<ArgumentNullException>(() => new PersonValidation(null));
      Assert.Throws<ArgumentException>(() => new InvalidSelectorValidation(new Person()));
    }

    [Fact]
    public void ValueTypesAndCollectionsAreValidated()
    {
      Assert.Equal(5, new ValueValidation(new ValueModel()).ValidationResult.ItensError.Count);
      var valid = new ValueModel { Enabled = true, Bytes = new byte[] { 1 }, Kind = DayOfWeek.Monday, Price = 1.20m, Duration = TimeSpan.FromMinutes(2) };
      Assert.True(new ValueValidation(valid).ValidationResult.IsValid);
    }

    [Fact]
    public void RequiredRejectsEmptyEnumerableAndKeepsTerminalSemantics()
    {
      var missing = new Rule<IEnumerable<int>>("Items", Enumerable.Empty<int>()).Required();
      missing.Validate();
      Assert.Contains("Items", missing.Message);
      var validator = new EnumerableValidation(new EnumerableModel());
      Assert.Equal(2, validator.ValidationResult.ItensError.Count);
    }

    [Fact]
    public void OptionalValuesAndInclusiveBoundariesArePreserved()
    {
      Assert.True(((int?)null).Between(1, 3));
      Assert.True(1.Between(1, 3));
      Assert.True(3.Between(1, 3));
      Assert.False(4.Between(1, 3));
      Assert.False(float.NaN.IsLess(1));
      Assert.True(TimeSpan.Zero.Between(TimeSpan.Zero, TimeSpan.FromHours(1)));
      Assert.True(((DateTimeOffset?)null).Between(DateTimeOffset.MinValue, DateTimeOffset.MaxValue));
      Assert.Throws<ArgumentOutOfRangeException>(() => 1m.HasPrecision(29));
    }

#if NET6_0_OR_GREATER
    [Fact]
    public void ModernDateAndTimeTypesSupportRanges()
    {
      Assert.True(new DateOnly(2026, 10, 15).Between(new DateOnly(2026, 1, 1), new DateOnly(2026, 12, 31)));
      Assert.False(new TimeOnly(23, 0).Between(new TimeOnly(8, 0), new TimeOnly(18, 0)));
    }
#endif

    [Fact]
    public void ResponsesPreserveOrderAndAggregateSeverity()
    {
      var response = new ValidationResponse();
      Assert.True(response.IsValid);
      response.Itens.Add(new ValidationItem("First", EStatus.INFO));
      response.Add(new ValidationResponse { Itens = new List<ValidationItem> { new ValidationItem("Second", EStatus.ERROR) } });
      Assert.Equal(new[] { "First", "Second" }, response.Itens.Select(item => item.Message));
      Assert.Equal(EStatus.ERROR, response.Status);
      Assert.Single(response.ToValidationResults());
      response.Itens = null;
      Assert.Empty(response.Itens);
    }

    [Fact]
    public void ResourcesFollowCurrentCulture()
    {
      var previous = CultureInfo.CurrentUICulture;
      try
      {
        CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");
        Assert.Contains("campo", new GuidValidation(new GuidModel()).ValidationResult.ItensError.Single().Message);
        CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
        Assert.Contains("field", new GuidValidation(new GuidModel()).ValidationResult.ItensError.Single().Message);
      }
      finally
      {
        CultureInfo.CurrentUICulture = previous;
      }
    }

    [Fact]
    public async Task AsyncRulesAwaitAndHonorCancellation()
    {
      var validation = new AsyncValidation();
      await validation.CheckAsync(CancellationToken.None);
      Assert.Single(validation.ValidationResult.ItensError);
      using (var source = new CancellationTokenSource())
      {
        source.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => validation.CheckAsync(source.Token));
      }
    }

    public class Person
    {
      [Display(Name = "Nome")]
      public string Name { get; set; }
      public int? Age { get; set; }
    }

    private class PersonValidation : ValidationBase<Person>
    {
      public PersonValidation(Person model) : base(model, false) { }
      protected override void AddRules()
      {
        RuleFor(p => p.Name).Required().MaxLength(10).Validate();
        RuleFor(p => p.Age).Required().MinValue(18).MaxValue(120).Validate();
      }
    }

    private class CustomValidation : ValidationBase<Person>
    {
      public CustomValidation(Person model) : base(model) { }
      protected override void AddRules() => RuleFor(p => p.Name).Required().WithMessage("Nome obrigatório.").MaxLength(10).Validate();
    }

    public class AnnotationModel
    {
      [Required, Cpf]
      public string Cpf { get; set; }
      public string Password { get; set; }
      [Display(Name = "Confirmação"), Compare("Password")]
      public string Confirmation { get; set; }
    }

    private class AnnotationValidation : ValidationBase<AnnotationModel>
    {
      public AnnotationValidation(AnnotationModel model) : base(model) { }
    }

    [AlwaysInvalid]
    public class ClassModel { }
    private class AlwaysInvalidAttribute : ValidationAttribute
    {
      public override bool IsValid(object value) => false;
    }
    private class ClassValidation : ValidationBase<ClassModel>
    {
      public ClassValidation(ClassModel model) : base(model) { }
    }
    public class ObjectModel : IValidatableObject
    {
      public IEnumerable<ValidationResult> Validate(ValidationContext context) => new[] { new ValidationResult("Invalid", new[] { "Name" }) };
    }
    private class ObjectValidation : ValidationBase<ObjectModel>
    {
      public ObjectValidation(ObjectModel model) : base(model) { }
    }
    public class GuidModel
    {
      public Guid Id { get; set; }
    }
    private class GuidValidation : ValidationBase<GuidModel>
    {
      public GuidValidation(GuidModel model) : base(model) { }
      protected override void AddRules() => RuleFor(p => p.Id).HasValue().Validate();
    }
    public class RequestModel : Person, IValidatableObject
    {
      public IEnumerable<ValidationResult> Validate(ValidationContext context) => new PersonValidation(this).ValidationResult.ToValidationResults();
    }
    public class NestedModel
    {
      public Person Person { get; set; } = new Person();
      public int Number { get; set; }
    }
    private class NestedValidation : ValidationBase<NestedModel>
    {
      public NestedValidation(NestedModel model) : base(model) { }
      protected override void AddRules()
      {
        RuleFor(p => p.Person.Age).MinValue(18).Validate();
        RuleFor(p => (object)p.Number).Must(value => (int)value > 0).Validate();
      }
    }
    private class InvalidSelectorValidation : ValidationBase<Person>
    {
      public InvalidSelectorValidation(Person model) : base(model) { }
      protected override void AddRules() => RuleFor(p => p.Name.Length + 1);
    }
    public class ValueModel
    {
      public bool? Enabled { get; set; } = false;
      public byte[] Bytes { get; set; } = new byte[0];
      public DayOfWeek? Kind { get; set; } = (DayOfWeek)99;
      public decimal Price { get; set; } = 1.234m;
      public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(10);
    }
    private class ValueValidation : ValidationBase<ValueModel>
    {
      public ValueValidation(ValueModel model) : base(model) { }
      protected override void AddRules()
      {
        RuleFor(p => p.Enabled).Required().IsTrue().Validate();
        RuleFor(p => p.Bytes).Required().MaxLength(4).Validate();
        RuleFor(p => p.Kind).Required().IsDefined().Validate();
        RuleFor(p => p.Price).Precision(2).Validate();
        RuleFor(p => p.Duration).Between(TimeSpan.Zero, TimeSpan.FromMinutes(5)).Validate();
      }
    }
    public class EnumerableModel
    {
      public IEnumerable<int> Items { get; set; } = Enumerable.Empty<int>();
      public bool Enabled { get; set; } = true;
    }
    private class EnumerableValidation : ValidationBase<EnumerableModel>
    {
      public EnumerableValidation(EnumerableModel model) : base(model) { }
      protected override void AddRules()
      {
        RuleFor(p => p.Items).Required().Validate();
        RuleFor(p => p.Enabled).IsTrue().ValidateError();
      }
    }
    private class AsyncValidation : ValidationBase
    {
      public Task CheckAsync(CancellationToken token) => AddErrorAsync("Async error", async cancellationToken =>
      {
        await Task.Delay(1, cancellationToken);
        return true;
      }, token);
    }
  }
}
