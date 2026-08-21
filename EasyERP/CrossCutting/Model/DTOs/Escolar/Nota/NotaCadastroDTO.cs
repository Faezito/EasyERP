namespace CrossCutting.Model.DTOs.Escolar.Nota;

public class NotaCadastroDTO
{
    public int AlunoId { get; set; }
    public int ProfessorId { get; set; }
    public int DisciplinaId { get; set; }
    public int TurmaId { get; set; }
    public decimal PontosFeitos { get; set; }
    public decimal TotalPontos { get; set; }
    public DateTime DataLancamento { get; set; }
}
