namespace Admin.Repositorio.Entidades;

public class ApiExterna
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}