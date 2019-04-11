namespace AFF.DomainValidation.Entity
{
    public class Rule<TKey> : Rule
    {
        public Rule(string property, object value) : base(property)
        {
            Value = (TKey)value;
        }

        public TKey Value { get; private set; }
    }

    public class Rule
    {
        public Rule(string property)
        {
            Property = property;
        }

        internal string Property { get; set; }
        internal bool? IsValid { get; set; }
        internal EStatus? EStatus { get; set; }
        internal object[] Values { get; set; }

        private string _message { get; set; }
        public string Message
        {
            get
            {
                return string.Format(_message, Values);
            }
            internal set
            {
                _message = value;
            }
        }

        public void Validate()
        {
            Validate(Entity.EStatus.SUCCESS, Entity.EStatus.ERROR);
        }
        public void Validate(string message)
        {
            Validate(message, Entity.EStatus.SUCCESS, Entity.EStatus.ERROR);
        }

        public void Validate(EStatus isValidStatus)
        {
            Validate(isValidStatus, Entity.EStatus.ERROR);
        }
        public void Validate(EStatus isValidStatus, EStatus? isNotValidStatus)
        {
            if (IsValid.HasValue)
                EStatus = IsValid.Value ? isValidStatus : isNotValidStatus;
        }

        public void Validate(string message, EStatus isValidStatus)
        {
            Validate(message, isValidStatus, Entity.EStatus.ERROR);
        }
        public void Validate(string message, EStatus isValidStatus, EStatus? isNotValidStatus)
        {
            Validate(isValidStatus, isNotValidStatus);
            Message = message;
        }

        public void ValidateSuccess()
        {
            Validate(Entity.EStatus.SUCCESS, null);
        }
        public void ValidateSuccess(string message)
        {
            Validate(message, Entity.EStatus.SUCCESS, null);
        }

        public void ValidateInfo()
        {
            Validate(Entity.EStatus.INFO, null);
        }
        public void ValidateInfo(string message)
        {
            Validate(message, Entity.EStatus.INFO, null);
        }

        public void ValidateAlert()
        {
            Validate(Entity.EStatus.ALERT, null);
        }
        public void ValidateAlert(string message)
        {
            Validate(message, Entity.EStatus.ALERT, null);
        }

        public void ValidateWarning()
        {
            Validate(Entity.EStatus.WARNING, null);
        }
        public void ValidateWarning(string message)
        {
            Validate(message, Entity.EStatus.WARNING, null);
        }

        public void ValidateError()
        {
            Validate(Entity.EStatus.ERROR, null);
        }
        public void ValidateError(string message)
        {
            Validate(message, Entity.EStatus.ERROR, null);
        }
    }
}
