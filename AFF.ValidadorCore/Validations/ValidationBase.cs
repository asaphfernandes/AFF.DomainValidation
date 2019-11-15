using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AFF.ValidadorCore.Entity;

namespace AFF.ValidadorCore.Validations
{
    public abstract class ValidationBase<TEntity> : ValidationBase
    {
        protected delegate Result FuncEntity<in Entity, out Result>(Entity entity);
        protected delegate Result FuncEntity<in Message, in Entity, out Result>(Message message, Entity entity);

        private List<Rule> _rules { get; } = new List<Rule>();
        protected TEntity _Entity { get; }

        public ValidationBase(TEntity entity) : base()
        {
            _Entity = entity;
            AddRules();
            ValidateAttribute();
            ValidadeRule();
        }

        public ValidationBase(TEntity entity, string message) : base(message)
        {
            _Entity = entity;
            AddRules();
            ValidateAttribute();
            ValidadeRule();
        }

        [Obsolete("Use the method: AddItem(string msg, Func<string, TEntity, ValidationItem> func).")]
        protected void AddValidateItem(string msg, FuncEntity<TEntity, ValidationItem> func)
        {
            ValidationResult.Itens.Add(func(_Entity));
        }

        protected void AddItem(string msg, FuncEntity<string, TEntity, ValidationItem> func)
        {
            ValidationResult.Itens.Add(func(msg, _Entity));
        }

        [Obsolete("Use the method: AddStatus(string msg, Func<TEntity, EStatus> func).")]
        protected void AddValidateStatus(string msg, FuncEntity<TEntity, EStatus> func)
        {
            ValidationResult.Itens.Add(msg, func(_Entity));
        }

        protected void AddStatus(string msg, FuncEntity<TEntity, EStatus> func)
        {
            ValidationResult.Itens.Add(msg, func(_Entity));
        }

        protected void AddIsValid(string msg, FuncEntity<TEntity, bool> func)
        {
            ValidationResult.Itens.Add(msg, func(_Entity));
        }

        protected void AddSuccess(string msg, FuncEntity<TEntity, bool> func)
        {
            var result = func(_Entity);
            if (result)
                ValidationResult.Itens.Add(msg, EStatus.SUCCESS);
        }

        protected void AddInfo(string msg, FuncEntity<TEntity, bool> func)
        {
            var result = func(_Entity);
            if (result)
                ValidationResult.Itens.Add(msg, EStatus.INFO);
        }

        protected void AddAlert(string msg, FuncEntity<TEntity, bool> func)
        {
            var result = func(_Entity);
            if (result)
                ValidationResult.Itens.Add(msg, EStatus.ALERT);
        }

        protected void AddWarning(string msg, FuncEntity<TEntity, bool> func)
        {
            var result = func(_Entity);
            if (result)
                ValidationResult.Itens.Add(msg, EStatus.WARNING);
        }

        protected void AddError(string msg, FuncEntity<TEntity, bool> func)
        {
            var result = func(_Entity);
            if (result)
                ValidationResult.Itens.Add(msg, EStatus.ERROR);
        }

        protected virtual void AddRules() { }

        protected Rule<TKey> RuleFor<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            var memberExpression = keySelector.Body as MemberExpression;
            var property = memberExpression.Member.Name;
            var value = keySelector.Compile().Invoke(_Entity);

            var displayAttribute = _Entity.GetType().GetProperty(property).GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>();
            if (displayAttribute != null)
                property = displayAttribute.Name;

            var rule = new Rule<TKey>(property, value);
            _rules.Add(rule);
            return rule;
        }

        private void ValidateAttribute()
        {
            var properties = _Entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                var customAttributes = property.GetCustomAttributes<System.ComponentModel.DataAnnotations.ValidationAttribute>();
                if (customAttributes.Any())
                {
                    var context = new System.ComponentModel.DataAnnotations.ValidationContext(property);

                    var displayAttribute = property.GetCustomAttributes<System.ComponentModel.DataAnnotations.DisplayAttribute>().SingleOrDefault();

                    if (displayAttribute != null)
                        context.DisplayName = displayAttribute.Name;
                    else
                        context.DisplayName = property.Name;

                    foreach (var customAttribute in customAttributes)
                    {
                        var value = property.GetValue(_Entity);
                        if (!customAttribute.IsValid(value))
                        {
                            var result = customAttribute.GetValidationResult(value, context);
                            ValidationResult.Itens.Add(result.ErrorMessage, false);
                        }
                    }
                }
            }
        }

        private void ValidadeRule()
        {
            foreach (var rule in _rules)
                ValidationResult.Itens.Add(rule);
        }
    }

    public abstract class ValidationBase
    {
        protected delegate Result Func<out Result>();
        protected delegate Result Func<in Message, out Result>(Message message);

        public ValidationResponse ValidationResult { get; private set; }

        public ValidationBase() => ValidationResult = new ValidationResponse();
        public ValidationBase(string message) => ValidationResult = new ValidationResponse { Message = message };

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
}
