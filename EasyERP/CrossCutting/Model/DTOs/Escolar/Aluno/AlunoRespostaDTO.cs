namespace CrossCutting.Model.DTOs.Escolar.Aluno;

public class AlunoRespostaDTO
{
    public Guid PublicId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public DateTime DataNascimento { get; set; }
    public Guid TurmaId { get; set; }
    public Guid PessoaId { get; set; }
}
