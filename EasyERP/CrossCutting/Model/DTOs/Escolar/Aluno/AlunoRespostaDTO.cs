using Model.DTOs.Escolar.Pessoa;

namespace CrossCutting.Model.DTOs.Escolar.Aluno;

public class AlunoRespostaDTO
{
    public int Id { get; set; }
    public int TurmaId { get; set; }
    public int PessoaId { get; set; }

    public PessoaRespostaDTO? Pessoa { get; set; }
    //TODO: Adicionar presenças e Responsáveis, talvez
}
