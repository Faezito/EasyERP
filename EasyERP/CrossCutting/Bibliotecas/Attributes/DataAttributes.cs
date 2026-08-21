using System.ComponentModel.DataAnnotations;

namespace Bibliotecas.Attributes;

public class DataAttributes
{
    public class DataNaoFuturaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value is DateTime data && data > DateTime.Now.AddMinutes(1))
                return new ValidationResult("A data não pode ser futura.");

            return ValidationResult.Success;
        }
    }

    public class ValidarDataAttribute : ValidationAttribute
    {
        private readonly DateTime _dataMinima;
        private readonly DateTime _dataMaxima;

        public ValidarDataAttribute(string dataMinima = "01/01/1900", string dataMaxima = "31/12/2999")
        {
            _dataMinima = DateTime.Parse(dataMinima);
            _dataMaxima = DateTime.Parse(dataMaxima);
        }

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value is not DateTime data)
                return ValidationResult.Success;

            if (data < _dataMinima || data > _dataMaxima)
            {
                return new ValidationResult(
                    $"Data inválida. A data precisa estar entre " +
                    $"{_dataMinima:dd/MM/yyyy} e {_dataMaxima:dd/MM/yyyy}");
            }

            return ValidationResult.Success;
        }
    }
}