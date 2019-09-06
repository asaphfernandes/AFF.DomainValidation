using AFF.DomainValidation.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AFF.DomainValidation.AspNet472Example.Models
{
    public class PersonModel
    {
        [Display(Name = "Código"), Required]
        public int? Cod { get; set; }
        [Display(Name = "Nome"), Required]
        public string Name { get; set; }
        [Display(Name = "Idade"), Required]
        public int? Age { get; set; }
        [Display(Name = "CPF"), Required, Cpf]
        public string Cpf { get; set; }
    }
}