using CrossCutting.Auditoria;
using CrossCutting.Model.Enums;

namespace Escolar.Repositorio.Entidades;

public class Pessoa : EntidadeAuditavel
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Genero { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; } = DateTime.MinValue;

    public TipoDePessoa Tipo { get; set; }
    public Endereco Endereco { get; set; } = null!;
}