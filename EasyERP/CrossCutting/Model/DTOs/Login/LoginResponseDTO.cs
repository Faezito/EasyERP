using Model.DTOs.Usuario;

namespace Model.DTOs.Login;

public class LoginResponseDTO
{
    public UsuarioRespostaDTO Usuario { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationDate => DateTime.Now.AddHours(3);
}