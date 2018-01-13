using System;
using System.Collections.Generic;
using System.Linq;

namespace AFF.DomainValidation.Entity
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            Itens = new HashSet<ValidationItem>();
        }

        private string _Message = null;
        public string Message
        {
            get
            {
                if (!string.IsNullOrEmpty(_Message))
                    return _Message;

                switch (Status)
                {
                    case EStatus.SUCCESS:
                        return "Ação realizada com sucesso.";
                    case EStatus.INFO:
                        return "Informações adicionais.";
                    case EStatus.ALERT:
                        return "Ação necessida de sua confirmação.";
                    case EStatus.WARNING:
                        return "Ação executado, porém necessida de ajustes futuros.";
                    case EStatus.ERROR:
                        return "Ops! Ocorreu um erro.";
                    default:
                        throw new ApplicationException("Condição o estado inespereado.");
                }
            }
            set { _Message = value; }
        }

        public ICollection<ValidationItem> Itens { get; set; }

        public EStatus Status
        {
            get
            {
                if (Itens.Count == Itens.Count(c => c.Status == EStatus.SUCCESS))
                    return EStatus.SUCCESS;
                else
                    return EStatus.ERROR;
            }
        }

        public bool IsValid { get { return Status == EStatus.SUCCESS; } }

        public ICollection<ValidationItem> ItensSuccess { get { return Itens.Where(w => w.Status == EStatus.SUCCESS).ToList(); } }
        public ICollection<ValidationItem> ItensInfo { get { return Itens.Where(w => w.Status == EStatus.INFO).ToList(); } }
        public ICollection<ValidationItem> ItensAlert { get { return Itens.Where(w => w.Status == EStatus.ALERT).ToList(); } }
        public ICollection<ValidationItem> ItensWarning { get { return Itens.Where(w => w.Status == EStatus.WARNING).ToList(); } }
        public ICollection<ValidationItem> ItensError { get { return Itens.Where(w => w.Status == EStatus.ERROR).ToList(); } }

        public string StatusText
        {
            get
            {
                string status = string.Empty;

                switch (Status)
                {
                    case EStatus.SUCCESS:
                        status = "success";
                        break;
                    case EStatus.INFO:
                        status = "info";
                        break;
                    case EStatus.ALERT:
                        status = "alert";
                        break;
                    case EStatus.WARNING:
                        status = "warning";
                        break;
                    case EStatus.ERROR:
                        status = "error";
                        break;
                    default:
                        status = "error";
                        break;
                }
                return status;
            }
        }
    }
}
