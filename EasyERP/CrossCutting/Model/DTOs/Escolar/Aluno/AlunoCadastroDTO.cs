using Model.DTOs.Escolar.Pessoa;

namespace CrossCutting.Model.DTOs.Escolar.Aluno;

public class AlunoCadastroDTO
{
    public PessoaCadastroDTO? Pessoa { get; set; }
    public Guid? TurmaId { get; set; }
}
