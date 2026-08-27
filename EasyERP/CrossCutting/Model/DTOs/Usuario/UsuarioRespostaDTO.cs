using CrossCutting.Auditoria;
using CrossCutting.Model.Enums;
using Model.DTOs.Endereco;
using Model.DTOs.PessoaFisica;

namespace Model.DTOs.Usuario;

public class UsuarioRespostaDTO : EntidadeAuditavel
{
    public Guid PublicId { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
    public Perfil Perfil { get; set; }
    public EnderecoRespostaDTO? Endereco { get; set; }
    public PessoaFisicaRespostaDTO? Pessoa { get; set; }
    public List<UsuarioModuloDTO> Modulos { get; set; } = [];
}