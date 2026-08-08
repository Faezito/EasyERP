using CrossCutting.Auditoria;

namespace Escolar.Repositorio.Entidades;

public class AlunoResponsavel : EntidadeAuditavel
{
    public int Id { get; set; }

    public int AlunoId { get; set; }
    public int PessoaId { get; set; }

    public string Parentesco { get; set; } = string.Empty;
    public bool ResponsavelFinanceiro { get; set; }
    public bool ResponsavelPedagogico { get; set; }
    public bool ContatoEmergencia { get; set; }
    public bool PodeRetirarAluno { get; set; }
    public bool Ativo { get; set; } = true;

    public Aluno Aluno { get; set; } = null!;
    public Pessoa Responsavel { get; set; } = null!;
}