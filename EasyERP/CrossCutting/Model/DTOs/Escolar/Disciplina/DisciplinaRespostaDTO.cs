namespace Model.DTOs.Escolar.Disciplina;

public class DisciplinaRespostaDTO
{
    public int Id { get; set; }
    public int PessoaJuridicaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Ativa { get; set; }
}