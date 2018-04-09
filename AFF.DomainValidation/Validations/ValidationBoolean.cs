using AFF.DomainValidation.Entity;

namespace AFF.DomainValidation.Validations
{
    public static class ValidationBoolean
    {
        public static EStatus SuccessOrError(this bool result) => result ? EStatus.SUCCESS : EStatus.ERROR;
        public static EStatus SuccessOrError(this bool result, bool equal) => result == equal ? EStatus.SUCCESS : EStatus.ERROR;

        public static EStatus SuccessOr(this bool result, EStatus status) => result ? EStatus.SUCCESS : status;
        public static EStatus SuccessOr(this bool result, EStatus status, bool equal) => result == equal ? EStatus.SUCCESS : status;
    }
}
