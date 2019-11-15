using System.Collections.Generic;

namespace AFF.ValidadorCore.Entity
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

    internal static class ValidationItemExtension
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

        public static ICollection<ValidationItem> Add(this ICollection<ValidationItem> list, Rule rule)
        {
            if (rule.EStatus.HasValue)
                list.Add(new ValidationItem(rule.Message, rule.EStatus.Value));
            return list;
        }
    }
}
