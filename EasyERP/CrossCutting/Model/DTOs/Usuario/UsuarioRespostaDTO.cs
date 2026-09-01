using CrossCutting.Auditoria;
using CrossCutting.Model.Enums;
using Model.DTOs.PessoaFisica;

namespace Model.DTOs.Usuario;

public class UsuarioRespostaDTO : EntidadeAuditavel
{
    public Guid PublicId { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
    public Perfil Perfil { get; set; }
    public PessoaFisicaRespostaDTO? PessoaFisica { get; set; }
    public List<UsuarioModuloDTO> Modulos { get; set; } = [];
}