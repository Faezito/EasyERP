using Model.DTOs.Escolar.Pessoa;

namespace CrossCutting.Model.DTOs.Escolar.Aluno;

public class AlunoAtualizacaoDTO
{
    public int Id { get; set; }
    public int PessoaId { get; set; }
    public int? TurmaId { get; set; }
    public PessoaAtualizacaoDTO? Pessoa { get; set; }
}