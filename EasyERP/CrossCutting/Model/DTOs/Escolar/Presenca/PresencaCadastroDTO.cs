using static Bibliotecas.Attributes.DataAttributes;

namespace CrossCutting.Model.DTOs.Escolar.Presenca;

public class PresencaCadastroDTO
{
    private DateTime _data;

    public int AlunoId { get; set; }
    public int ProfessorId { get; set; }
    public int TurmaId { get; set; }
    public int DisciplinaId { get; set; }

    [ValidarData]
    [DataNaoFutura]
    public DateTime Data { get; set; }
    public bool Presente { get; set; }
}