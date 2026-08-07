using System.ComponentModel.DataAnnotations;

namespace Model.DTOs.Login;

public class LoginRequestDTO
{
    [Required(ErrorMessage = "O login não pode ficar vazio")]
    [Display(Name = "Nome de Usuario ou E-mail")]
    public string? Login { get; set; }

    [Required(ErrorMessage = "Credenciais inválidas")]
    [Display(Name = "Senha")]
    public string? Senha { get; set; }
}