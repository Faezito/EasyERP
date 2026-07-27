using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Model.DTOs.Acesso
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Insira seu usuário ou e-mail")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Insira sua senha")]
        public string Senha { get; set; } = string.Empty;
    }
}