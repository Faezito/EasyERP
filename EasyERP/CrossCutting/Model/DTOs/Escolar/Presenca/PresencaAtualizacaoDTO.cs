using static Bibliotecas.Attributes.DataAttributes;

namespace CrossCutting.Model.DTOs.Escolar.Presenca;

public class PresencaAtualizacaoDTO
{
    public int Id { get; set; }
    [ValidarData]
    [DataNaoFutura]
    public DateTime Data { get; set; }
    public bool Presente { get; set; }
}
