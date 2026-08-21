namespace CrossCutting.Model.DTOs.Escolar.Nota;

public class NotaAtualizacaoDTO
{
    public int Id { get; set; }
    public decimal PontosFeitos { get; set; }
    public decimal TotalPontos { get; set; }
    public DateTime DataLancamento { get; set; }
}