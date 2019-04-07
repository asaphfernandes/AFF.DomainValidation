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

        public string Property { get; set; }
        public bool IsValid { get; internal set; }
        public EStatus? EStatus { get; internal set; }
        public string Message { get; internal set; }

        public void Validate()
        {
            EStatus = IsValid ? Entity.EStatus.SUCCESS : Entity.EStatus.ERROR;
        }
        public void Validate(string message)
        {
            Validate();
            Message = message;
        }

        public void Validate(EStatus status)
        {
            if (IsValid)
                EStatus = status;
        }
        public void Validate(EStatus status, string message)
        {
            Validate(status);
            Message = message;
        }

        public void ValidateSuccess()
        {
            if (IsValid)
                EStatus = Entity.EStatus.SUCCESS;
        }
        public void ValidateSuccess(string message)
        {
            ValidateSuccess();
            Message = message;
        }

        public void ValidateInfo()
        {
            if (IsValid)
                EStatus = Entity.EStatus.INFO;
        }
        public void ValidateInfo(string message)
        {
            ValidateInfo();
            Message = message;
        }

        public void ValidateAlert()
        {
            if (IsValid)
                EStatus = Entity.EStatus.ALERT;
        }
        public void ValidateAlert(string message)
        {
            ValidateAlert();
            Message = message;
        }

        public void ValidateWarning()
        {
            if (IsValid)
                EStatus = Entity.EStatus.WARNING;
        }
        public void ValidateWarning(string message)
        {
            ValidateWarning();
            Message = message;
        }

        public void ValidateError()
        {
            if (IsValid)
                EStatus = Entity.EStatus.ERROR;
        }
        public void ValidateError(string message)
        {
            ValidateError();
            Message = Message;
        }
    }
}
