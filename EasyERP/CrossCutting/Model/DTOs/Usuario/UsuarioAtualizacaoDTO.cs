using CrossCutting.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace Model.DTOs.Usuario
{
    public class UsuarioAtualizacaoDTO
    {
        [Required(ErrorMessage = "Id é necessário")]
        [Display(Name = "Id")]
        public Guid PublicId { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve conter entre 8 e 100 caracteres")]
        [Display(Name = "Senha")]
        public string? Senha { get; set; }

        [Display(Name = "Perfil")]
        public Perfil? Perfil { get; set; }

        public List<int> Modulos { get; set; } = new List<int>();
    }
}