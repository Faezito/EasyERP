using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class LocalTabela
{
    public int Id { get; set; }
    [Display(Name = "Nome")]
    public string Name { get; set; }
    [Display(Name = "Endereço")]
    public string Endereco { get; set; }
}
