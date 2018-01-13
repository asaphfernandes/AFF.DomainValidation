namespace AFF.DomainValidation.Entity
{
    public class ValidationItem
    {
        public ValidationItem(string message, EStatus status = EStatus.ERROR)
        {
            Message = message;
            Status = status;
        }

        public ValidationItem(string message, bool isValid)
        {
            Message = message;
            Status = isValid ? EStatus.SUCCESS : EStatus.ERROR;
        }

        public string Message { get; private set; }
        public EStatus Status { get; private set; }
    }
}
