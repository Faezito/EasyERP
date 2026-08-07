using Model.DTOs.Usuario;

namespace CrossCutting.Model.DTOs.Login;

public class LoginResponseDTO
{
    public string Token { get; set; }
    public UsuarioRespostaDTO Usuario { get; set; }
    public DateTime ExpirationDate => DateTime.Now.AddHours(3);
}