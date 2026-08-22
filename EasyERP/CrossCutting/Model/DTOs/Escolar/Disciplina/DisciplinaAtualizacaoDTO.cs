namespace Model.DTOs.Escolar.Disciplina;

public class DisciplinaAtualizacaoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Ativa { get; set; }
}