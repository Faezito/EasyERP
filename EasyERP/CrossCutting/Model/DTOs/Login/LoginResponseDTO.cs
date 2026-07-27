using Model.DTOs.Usuario;

namespace CrossCutting.Model.DTOs.Login
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiracao { get; set; }
        public UsuarioRespostaDTO Usuario { get; set; }
    }
}
