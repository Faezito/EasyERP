using System.Text.RegularExpressions;
        using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Biblioteca
{
    public static class Validacoes
    {
        public static (bool valido, string? mensagem) ValidarCPF(string cpf)
        {
            string mensagem = string.Empty;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                mensagem = "CPF inválido!"; 
                return (false, mensagem);
            }

            // Remove tudo que não for número
            cpf = Regex.Replace(cpf, @"\D", "").Trim();

            // CPF deve ter 11 dígitos
            if (cpf.Length != 11)
                return (false, "CPF inválido!");

            // Rejeita CPFs com todos os dígitos iguais
            if (cpf.Distinct().Count() == 1)
                return (false, "CPF inválido!");

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int resto = (soma * 10) % 11;
            if (resto == 10) resto = 0;

            if (resto != (cpf[9] - '0'))
                return (false, "CPF inválido!");

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            resto = (soma * 10) % 11;
            if (resto == 10) resto = 0;

            if (resto != (cpf[10] - '0'))
                return (false, "CPF inválido!");

            return (true, cpf);
       }

        public static (bool valido, string? mensagem) ValidarCNPJ(string cnpj)
        {
            string mensagem = string.Empty;

            if (string.IsNullOrWhiteSpace(cnpj))
            {
                mensagem = "CNPJ inválido!";
                return (false, mensagem);
            }

            // Remove tudo que não for número
            cnpj = Regex.Replace(cnpj, @"\D", "").Trim();

            // CNPJ deve ter 14 dígitos
            if (cnpj.Length != 14)
                return (false, null);

            // Rejeita CNPJs com todos os dígitos iguais
            if (cnpj.Distinct().Count() == 1)
                return (false, null);

            int[] pesosPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesosSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += (cnpj[i] - '0') * pesosPrimeiroDigito[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            if (digito1 != (cnpj[12] - '0'))
                return (false, null);

            // Segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += (cnpj[i] - '0') * pesosSegundoDigito[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            if (digito2 != (cnpj[13] - '0'))
                return (false, null);

            return (true, cnpj);
        }

        public static ModelStateDictionary ValidarModel(object model)
        {
            var modelState = new ModelStateDictionary();

            ValidateObject(model, modelState);

            return modelState;
        }

        private static void ValidateObject(
            object model,
            ModelStateDictionary modelState,
            string prefix = "")
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(
                model,
                context,
                results,
                validateAllProperties: true
            );

            foreach (var result in results)
            {
                foreach (var memberName in result.MemberNames)
                {
                    var key = string.IsNullOrEmpty(prefix)
                        ? memberName
                        : $"{prefix}.{memberName}";

                    modelState.AddModelError(
                        key,
                        result.ErrorMessage ?? "Valor inválido."
                    );
                }
            }

            foreach (var property in model.GetType().GetProperties())
            {
                var value = property.GetValue(model);

                if (value == null)
                    continue;

                if (value is string)
                    continue;

                if (property.PropertyType.IsValueType)
                    continue;

                var propertyPrefix = string.IsNullOrEmpty(prefix)
                    ? property.Name
                    : $"{prefix}.{property.Name}";

                ValidateObject(
                    value,
                    modelState,
                    propertyPrefix
                );
            }
        }
    }
}