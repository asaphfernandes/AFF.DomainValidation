namespace AFF.DomainValidation.Entity
{
    public class ValidationItem
    {
        public ValidationItem(string message, EStatus status = EStatus.ERROR)
        {
            Message = message;
            Status = status;
        }

        public string Message { get; private set; }
        public EStatus Status { get; private set; }
    }
}
