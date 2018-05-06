using System.Collections.Generic;

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

    public static class ValidationItemExtension
    {
        public static ICollection<ValidationItem> Add(this ICollection<ValidationItem> list, string msg, EStatus status)
        {
            list.Add(new ValidationItem(msg, status));
            return list;
        }

        public static ICollection<ValidationItem> Add(this ICollection<ValidationItem> list, string msg, bool isValid)
        {
            list.Add(new ValidationItem(msg, isValid));
            return list;
        }
    }
}
