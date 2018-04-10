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
            ValidationResult.Itens.Add(fn(_Entity));
        }

        protected void AddValidateStatus(string msg, Func<TEntity, EStatus> fn)
        {
            ValidationResult.Itens.Add(new ValidationItem(msg, fn(_Entity)));
        }

        protected void AddIsValid(string msg, Func<TEntity, bool> fn)
        {
            ValidationResult.Itens.Add(new ValidationItem(msg, fn(_Entity)));
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
