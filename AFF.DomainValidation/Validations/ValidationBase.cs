using System;
using AFF.DomainValidation.Entity;
using AFF.DomainValidation.Interfaces;

namespace AFF.DomainValidation.Validations
{
    public abstract class ValidationBase<TEntity> : ValidationBase
    {
        protected TEntity _Entity;

        public ValidationBase(TEntity entity) : base() { _Entity = entity; }

        public ValidationBase(TEntity entity, string message) : base(message)
        {
            _Entity = entity;
        }

        protected void AddValidateItem(string msg, Func<TEntity, ValidationItem> fn)
        {
            var result = fn(_Entity);
            if (AddOnlyErrors)
            {
                if (result.Status == EStatus.ERROR)
                    ValidationResult.Itens.Add(result);
            }
            else
            {
                ValidationResult.Itens.Add(result);
            }
        }

        protected void AddValidateStatus(string msg, Func<TEntity, EStatus> fn)
        {
            var result = fn(_Entity);
            if (AddOnlyErrors)
            {
                if (result == EStatus.ERROR)
                    ValidationResult.Itens.Add(new ValidationItem(msg, result));
            }
            else
            {
                ValidationResult.Itens.Add(new ValidationItem(msg, result));
            }
        }

        protected void AddIsValid(string msg, Func<TEntity, bool> fn)
        {
            var result = fn(_Entity);
            if (AddOnlyErrors)
            {
                if (!result)
                    ValidationResult.Itens.Add(new ValidationItem(msg, result));
            }
            else
            {
                ValidationResult.Itens.Add(new ValidationItem(msg, result));
            }
        }
    }

    public abstract class ValidationBase
    {
        public ValidationResult ValidationResult { get; protected set; }

        public ValidationBase()
        {
            ValidationResult = new ValidationResult();
        }

        public ValidationBase(string message)
        {
            ValidationResult = new ValidationResult
            {
                Message = message
            };
        }

        /// <summary>
        /// Default false.
        /// </summary>
        public static bool AddOnlyErrors
        {
            get
            {
                if (_AddOnlyErrors.HasValue)
                    return _AddOnlyErrors.Value;
                return false;
            }
            protected set { _AddOnlyErrors = value; }
        }
        public static bool? _AddOnlyErrors;

        protected void AddValidateItem(string msg, Func<ValidationItem> fn)
        {
            ValidationResult.Itens.Add(fn());
        }

        protected void AddValidateStatus(string msg, Func<EStatus> fn)
        {
            ValidationResult.Itens.Add(new ValidationItem(msg, fn()));
        }

        protected void AddIsValid(string msg, Func<bool> fn)
        {
            ValidationResult.Itens.Add(new ValidationItem(msg, fn()));
        }
    }
}
