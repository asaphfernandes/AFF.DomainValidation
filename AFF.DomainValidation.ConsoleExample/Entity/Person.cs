using System.ComponentModel.DataAnnotations;
using AFF.DomainValidation.DataAnnotations;

namespace AFF.DomainValidation.ConsoleExample.Entity
{
    class Person
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
