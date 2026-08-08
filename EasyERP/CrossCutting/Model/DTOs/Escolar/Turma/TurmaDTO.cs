namespace Model.DTOs.Escolar.Turma;

public class TurmaDTO
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string Sala { get; set; } = string.Empty;
    public string? Predio { get; set; }

    public int? ResponsavelId { get; set; }
    public int? ViceResponsavelId { get; set; }
}