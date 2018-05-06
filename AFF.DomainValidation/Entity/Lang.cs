using System;

namespace AFF.DomainValidation.Entity
{
    static class Lang
    {
        public enum ELang : short
        {
            PT_BR,
            EN_US
        }

        private const string InvalidCastException = "Condition not defined.";

        public static ELang Chosen
        {
            get
            {
                if (_Chosen.HasValue)
                    return _Chosen.Value;
                else
                    return ELang.PT_BR;
            }
            set
            {
                _Chosen = value;
            }
        }
        private static ELang? _Chosen;

        public static string SUCCESS => GetSuccess();
        public static string INFO => GetInfo();
        public static string ALERT => GetAlert();
        public static string WARNING => GetWarning();
        public static string ERROR => GetError();

        private static string GetSuccess()
        {
            switch (Chosen)
            {
                case ELang.PT_BR:
                    return "Ação realizada com sucesso.";
                case ELang.EN_US:
                    return "Action has been success.";
                default:
                    throw new InvalidCastException(InvalidCastException);
            }
        }

        private static string GetInfo()
        {
            switch (Chosen)
            {
                case ELang.PT_BR:
                    return "Informações adicionais.";
                case ELang.EN_US:
                    return "Additional information.";
                default:
                    throw new InvalidCastException(InvalidCastException);
            }
        }

        private static string GetAlert()
        {
            switch (Chosen)
            {
                case ELang.PT_BR:
                    return "Ação necessida de sua confirmação.";
                case ELang.EN_US:
                    return "Action need your confirmation.";
                default:
                    throw new InvalidCastException(InvalidCastException);
            }
        }

        private static string GetWarning()
        {
            switch (Chosen)
            {
                case ELang.PT_BR:
                    return "Ação executada, porém necessita de ajustes futuros.";
                case ELang.EN_US:
                    return "Action performed, but needs future adjustments.";
                default:
                    throw new InvalidCastException(InvalidCastException);
            }
        }

        private static string GetError()
        {
            switch (Chosen)
            {
                case ELang.PT_BR:
                    return "Ops! Ocorreu um erro.";
                case ELang.EN_US:
                    return "Oops! An error has occurred.";
                default:
                    throw new InvalidCastException(InvalidCastException);
            }
        }
    }
}
