using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AFF.DomainValidation.DataAnnotations
{
    public class CpfAttribute : ValidationAttribute
    {
        public CpfAttribute() : base()
        {
            ErrorMessage = Langs.Resource.CpfAttribute;
        }

        public override bool IsValid(object value)
        {
            var cpf = $"{value}";
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            if (cpf == "") return false;
            // Elimina CPFs invalidos conhecidos    
            if (cpf.Length != 11 ||
                cpf == "00000000000" ||
                cpf == "11111111111" ||
                cpf == "22222222222" ||
                cpf == "33333333333" ||
                cpf == "44444444444" ||
                cpf == "55555555555" ||
                cpf == "66666666666" ||
                cpf == "77777777777" ||
                cpf == "88888888888" ||
                cpf == "99999999999")
                return false;

            var numbers = cpf.ToCharArray().Select(s => Convert.ToInt32($"{s}")).ToArray();

            // Valida 1o digito 
            var add = 0;
            for (var i = 0; i < 9; i++)
                add += numbers[i] * (10 - i);
            var rev = 11 - add % 11;
            if (rev == 10 || rev == 11)
                rev = 0;
            if (rev != numbers[9])
                return false;
            // Valida 2o digito 
            add = 0;
            for (var i = 0; i < 10; i++)
                add += numbers[i] * (11 - i);
            rev = 11 - add % 11;
            if (rev == 10 || rev == 11)
                rev = 0;
            if (rev != numbers[10])
                return false;
            return true;
        }
    }
}
