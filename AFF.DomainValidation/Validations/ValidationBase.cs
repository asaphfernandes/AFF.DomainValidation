using System;
using AFF.DomainValidation.Entity;
using AFF.DomainValidation.Interfaces;

namespace AFF.DomainValidation.Validations
{
    public abstract class ValidationBase<T> : ValidationBase
    {
        public delegate ValidationItem IsValidate(T entity);
        public delegate ValidationItem IsValidates(T entity, params IValidation[] validation);

        public delegate EStatus IsSatisfiedBys(T entity, params IValidation[] validation);
        public delegate EStatus IsSatisfiedBy(T entity);

        protected T _OBJ;

        public ValidationBase(T obj) : base() { _OBJ = obj; }

        public ValidationBase(T obj, string message) : base(message)
        {
            _OBJ = obj;
        }

        protected void AddValidateItem(string msg, Func<T, ValidationItem> fn)
        {
            _ValidationResult.Itens.Add(fn(_OBJ));
        }

        protected void AddValidateStatus(string msg, Func<T, EStatus> fn)
        {
            _ValidationResult.Itens.Add(new ValidationItem(msg, fn(_OBJ)));
        }

        protected void AddIsValid(string msg, Func<T, bool> fn)
        {
            _ValidationResult.Itens.Add(new ValidationItem(msg, fn(_OBJ)));
        }
    }

    public abstract class ValidationBase
    {
        public ValidationResult _ValidationResult { get; protected set; }

        public ValidationBase()
        {
            _ValidationResult = new ValidationResult();
        }

        public ValidationBase(string message)
        {
            _ValidationResult = new ValidationResult
            {
                Message = message
            };
        }

        public abstract ValidationResult Validate();
    }
}
