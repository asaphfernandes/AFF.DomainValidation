using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AFF.ValidadorCore.Entity;
using AFF.ValidadorCore.Interfaces;

namespace AFF.ValidadorCore.Validations;

public abstract class ValidationBase<TEntity> : ValidationBase
{
  protected delegate Result FuncEntity<in Entity, out Result>(Entity entity);
  protected delegate Result FuncEntity<in Message, in Entity, out Result>(Message message, Entity entity);

  private List<Rule> _rules { get; } = new List<Rule>();
  protected TEntity Entity { get; }

  public ValidationBase(TEntity entity) : this(entity, null, true) { }

  public ValidationBase(TEntity entity, string message) : this(entity, message, true) { }

  public ValidationBase(TEntity entity, bool validateAttributes) : this(entity, null, validateAttributes) { }

  public ValidationBase(TEntity entity, string message, bool validateAttributes) : base(message)
  {
    ArgumentNullException.ThrowIfNull(entity, nameof(entity));

    Entity = entity;

    AddRules();

    if (validateAttributes)
      ValidateAttribute();

    ValidadeRule();
  }

  [Obsolete("Use the method: AddItem(string msg, Func<string, TEntity, ValidationItem> func).")]
  protected void AddValidateItem(string msg, FuncEntity<TEntity, ValidationItem> func)
  {
    ValidationResult.Itens.Add(func(Entity));
  }

  protected void AddItem(string msg, FuncEntity<string, TEntity, ValidationItem> func)
  {
    ValidationResult.Itens.Add(func(msg, Entity));
  }

  [Obsolete("Use the method: AddStatus(string msg, Func<TEntity, EStatus> func).")]
  protected void AddValidateStatus(string msg, FuncEntity<TEntity, EStatus> func)
  {
    ValidationResult.Itens.Add(msg, func(Entity));
  }

  protected void AddStatus(string msg, FuncEntity<TEntity, EStatus> func)
  {
    ValidationResult.Itens.Add(msg, func(Entity));
  }

  protected void AddIsValid(string msg, FuncEntity<TEntity, bool> func)
  {
    ValidationResult.Itens.Add(msg, func(Entity));
  }

  protected void AddSuccess(string msg, FuncEntity<TEntity, bool> func)
  {
    var result = func(Entity);
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.SUCCESS);
  }

  protected void AddInfo(string msg, FuncEntity<TEntity, bool> func)
  {
    var result = func(Entity);
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.INFO);
  }

  protected void AddAlert(string msg, FuncEntity<TEntity, bool> func)
  {
    var result = func(Entity);
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.ALERT);
  }

  protected void AddWarning(string msg, FuncEntity<TEntity, bool> func)
  {
    var result = func(Entity);
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.WARNING);
  }

  protected void AddError(string msg, FuncEntity<TEntity, bool> func)
  {
    var result = func(Entity);
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.ERROR);
  }

  protected virtual void AddRules() { }

  protected Rule<TKey> RuleFor<TKey>(Expression<Func<TEntity, TKey>> keySelector)
  {
    if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
    var body = keySelector.Body;
    while (body is UnaryExpression conversion && (conversion.NodeType == ExpressionType.Convert || conversion.NodeType == ExpressionType.ConvertChecked))
      body = conversion.Operand;
    var memberExpression = body as MemberExpression;
    if (memberExpression == null) throw new ArgumentException("Select a model member.", nameof(keySelector));
    var members = new Stack<string>();
    Expression current = memberExpression;
    while (current is MemberExpression member)
    {
      members.Push(member.Member.Name);
      current = member.Expression;
    }
    if (current != keySelector.Parameters[0]) throw new ArgumentException("Select a model member.", nameof(keySelector));
    var memberName = string.Join(".", members);
    var property = memberExpression.Member.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? memberExpression.Member.Name;
    var value = keySelector.Compile().Invoke(Entity);
    var rule = new Rule<TKey>(property, value) { MemberName = memberName };
    _rules.Add(rule);
    return rule;
  }

  private void ValidateAttribute()
  {
    var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
    foreach (var property in Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanRead && p.GetIndexParameters().Length == 0))
    {
      if (!property.GetCustomAttributes<ValidationAttribute>(true).Any()) continue;
      var propertyResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
      Validator.TryValidateProperty(property.GetValue(Entity), new ValidationContext(Entity) { MemberName = property.Name }, propertyResults);
      results.AddRange(propertyResults.Select(r => new System.ComponentModel.DataAnnotations.ValidationResult(r.ErrorMessage, r.MemberNames.Any() ? r.MemberNames : new[] { property.Name })));
    }
    if (results.Count == 0)
    {
      var context = new ValidationContext(Entity);
      foreach (var attribute in Entity.GetType().GetCustomAttributes<ValidationAttribute>(true))
      {
        var result = attribute.GetValidationResult(Entity, context);
        if (result != System.ComponentModel.DataAnnotations.ValidationResult.Success)
          results.Add(result);
      }
      if (results.Count == 0 && Entity is IValidatableObject validatable)
        results.AddRange((validatable.Validate(context) ?? Enumerable.Empty<System.ComponentModel.DataAnnotations.ValidationResult>()).Where(r => r != System.ComponentModel.DataAnnotations.ValidationResult.Success));
    }
    foreach (var result in results)
      ValidationResult.Itens.Add(new ValidationItem(result.ErrorMessage, EStatus.ERROR, result.MemberNames));
  }

  private void ValidadeRule()
  {
    foreach (var rule in _rules)
      ValidationResult.Itens.Add(rule);
  }
}

public abstract class ValidationBase : IValidation
{
  protected delegate Result Func<out Result>();
  protected delegate Result Func<in Message, out Result>(Message message);

  public ValidationResponse ValidationResult { get; private set; }

  public ValidationBase() => ValidationResult = new ValidationResponse();
  public ValidationBase(string message) => ValidationResult = new ValidationResponse { Message = message };

  protected void AddRange(IEnumerable<ValidationItem> items)
  {
    foreach (var item in items.ToArray())
      ValidationResult.Itens.Add(item);
  }

  protected async Task AddStatusAsync(string msg, System.Func<CancellationToken, Task<EStatus?>> func, CancellationToken cancellationToken = default)
  {
    cancellationToken.ThrowIfCancellationRequested();
    var status = await func(cancellationToken).ConfigureAwait(false);
    if (status.HasValue)
      ValidationResult.Itens.Add(msg, status.Value);
  }

  protected async Task AddErrorAsync(string msg, System.Func<CancellationToken, Task<bool>> func, CancellationToken cancellationToken = default)
  {
    cancellationToken.ThrowIfCancellationRequested();
    if (await func(cancellationToken).ConfigureAwait(false))
      ValidationResult.Itens.Add(msg, EStatus.ERROR);
  }

  [Obsolete("Use the method: AddItem(string msg, Func<string, ValidationItem> func).")]
  protected void AddValidateItem(string msg, Func<ValidationItem> func)
  {
    ValidationResult.Itens.Add(func());
  }

  protected void AddItem(string msg, Func<string, ValidationItem> func)
  {
    ValidationResult.Itens.Add(func(msg));
  }

  [Obsolete("Use the method: AddStatus(string msg, Func<EStatus> func).")]
  protected void AddValidateStatus(string msg, Func<EStatus> func)
  {
    ValidationResult.Itens.Add(msg, func());
  }

  protected void AddStatus(string msg, Func<EStatus> func)
  {
    ValidationResult.Itens.Add(msg, func());
  }

  protected void AddIsValid(string msg, Func<bool> func)
  {
    ValidationResult.Itens.Add(msg, func());
  }

  protected void AddSuccess(string msg, Func<bool> func)
  {
    var result = func();
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.SUCCESS);
  }

  protected void AddInfo(string msg, Func<bool> func)
  {
    var result = func();
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.INFO);
  }

  protected void AddAlert(string msg, Func<bool> func)
  {
    var result = func();
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.ALERT);
  }

  protected void AddWarning(string msg, Func<bool> func)
  {
    var result = func();
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.WARNING);
  }

  protected void AddError(string msg, Func<bool> func)
  {
    var result = func();
    if (result)
      ValidationResult.Itens.Add(msg, EStatus.ERROR);
  }
}
