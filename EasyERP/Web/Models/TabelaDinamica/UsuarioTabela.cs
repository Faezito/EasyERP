using Model.DTOs.Usuario;
using System.ComponentModel.DataAnnotations;
using Biblioteca;

namespace Web.Models.TabelaDinamica;

public class UsuarioTabela
{
    [Display(Name = "Id")]
    public Guid Id { get; set; }

    [Display(Name = "Nome")]
    public string NomeCompleto { get; set; }

    [Display(Name = "Usuário")]
    public string NomeUsuario { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Telefone")]
    public string Telefone { get; set; }

    [Display(Name = "Endereço")]
    public string Endereco { get; set; }

    [Display(Name = "Data de Nascimento", Description = "text-center")]
    public string DataNascimento { get; set; }


    public static List<UsuarioTabela> MapearParaTabela(List<UsuarioRespostaDTO> pessoasRespostaDTO)
    {
        var pessoasTabela = new List<UsuarioTabela>();
        foreach (var pessoaDTO in pessoasRespostaDTO)
        {
            var pessoa = new UsuarioTabela
            {
                Id = pessoaDTO.PublicId,
                NomeCompleto = pessoaDTO.PessoaFisica?.NomeCompleto,
                NomeUsuario = pessoaDTO.NomeUsuario,
                Email = pessoaDTO.PessoaFisica?.Email,
                Telefone = pessoaDTO.PessoaFisica?.Telefone?.FormatarTelefone(),
                Endereco = $"{pessoaDTO.PessoaFisica?.Endereco?.Logradouro} {pessoaDTO.PessoaFisica?.Endereco?.Numero}, {pessoaDTO.PessoaFisica?.Endereco?.Bairro} - {pessoaDTO.PessoaFisica?.Endereco?.Cidade}, {pessoaDTO.PessoaFisica?.Endereco?.Estado}",
                DataNascimento = DateTimeExt.DataParaDDMMYY(pessoaDTO.PessoaFisica?.DataNascimento)
            };

            pessoasTabela.Add(pessoa);
        }

        return pessoasTabela ?? new();
    }

}
