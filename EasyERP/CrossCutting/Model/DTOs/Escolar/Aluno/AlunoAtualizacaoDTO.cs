using Model.DTOs.Endereco;
using Model.DTOs.Escolar.Pessoa;

namespace CrossCutting.Model.DTOs.Escolar.Aluno;

public class AlunoAtualizacaoDTO
{
    public Guid PessoaId { get; set; }
    public string? NomeCompleto { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? Genero { get; set; }
    public EnderecoAtualizacaoDTO? Endereco { get; set; }
    public int? TurmaId { get; set; }
}
