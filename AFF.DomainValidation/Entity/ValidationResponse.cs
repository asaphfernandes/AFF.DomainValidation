using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AFF.DomainValidation.Entity
{
  public class ValidationResponse
  {
    public ValidationResponse()
    {
      Itens = new List<ValidationItem>();
    }

    private string _message;
    public string Message
    {
      get
      {
        if (!string.IsNullOrEmpty(_message))
          return _message;

        switch (Status)
        {
          case EStatus.SUCCESS: return Langs.Resource.ValidationResponse_SUCCESS;
          case EStatus.INFO: return Langs.Resource.ValidationResponse_INFO;
          case EStatus.ALERT: return Langs.Resource.ValidationResponse_ALERT;
          case EStatus.WARNING: return Langs.Resource.ValidationResponse_WARNING;
          case EStatus.ERROR: return Langs.Resource.ValidationResponse_ERROR;
          default: return null;
        }
      }
      set { _message = value; }
    }

    private ICollection<ValidationItem> _itens = new List<ValidationItem>();
    public ICollection<ValidationItem> Itens
    {
      get => _itens;
      set => _itens = value ?? new List<ValidationItem>();
    }

    public IEnumerable<ValidationResult> ToValidationResults()
    {
      return Itens.Where(w => w.Status != EStatus.SUCCESS && w.Status != EStatus.INFO).Select(s => new ValidationResult(s.Message, s.MemberNames));
    }

    public void Add(params ValidationResponse[] responses)
    {
      foreach (var response in responses)
      {
        foreach (var item in response.Itens.ToArray())
          Itens.Add(item);
      }
    }

    public EStatus Status
    {
      get
      {
        if (_status.HasValue)
          return _status.Value;
        else
        {
          var status = Itens.Select(s => s.Status).DefaultIfEmpty(EStatus.SUCCESS).Max();

          return status;
        }
      }
      set
      {
        _status = value;
      }
    }
    private EStatus? _status;

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
          case EStatus.SUCCESS: status = "success"; break;
          case EStatus.INFO: status = "info"; break;
          case EStatus.ALERT: status = "alert"; break;
          case EStatus.WARNING: status = "warning"; break;
          case EStatus.ERROR: status = "error"; break;
          default: status = "error"; break;
        }
        return status;
      }
    }
  }
}
