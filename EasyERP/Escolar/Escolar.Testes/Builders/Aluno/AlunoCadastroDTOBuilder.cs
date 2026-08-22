using Bogus;
using CrossCutting.Model.DTOs.Escolar.Aluno;
using Model.DTOs.Escolar.Pessoa;

namespace Escolar.Tests.Builders;

public class AlunoCadastroDTOBuilder
{
    private readonly Faker _faker = new();

    private string _nome = "";
    private string _genero = "";
    private string _email = "";
    private string _cpf = "";
    private string _telefone = "";
    private DateTime _dataNascimento;

    public AlunoCadastroDTOBuilder()
    {
        _nome = _faker.Person.FullName;
        _genero = _faker.PickRandom("M", "F", "O", "N");
        _email = _faker.Internet.Email();
        _cpf = _faker.Random.ReplaceNumbers("###########");
        _telefone = _faker.Random.ReplaceNumbers("###########");
        _dataNascimento = _faker.Date.Past(30);
    }

    public AlunoCadastroDTOBuilder ComNome(string nome)
    {
        _nome = nome;
        return this;
    }

    public AlunoCadastroDTOBuilder ComEmail(string email)
    {
        _email = email;
        return this;
    }

    public AlunoCadastroDTOBuilder ComGenero(string genero)
    {
        _genero = genero;
        return this;
    }

    public AlunoCadastroDTO Build()
    {
        return new AlunoCadastroDTO
        {
            TurmaId = 1,
            Pessoa = new PessoaCadastroDTO
            {
                NomeCompleto = _nome,
                Genero = _genero,
                Email = _email,
                CPF = _cpf,
                Telefone = _telefone,
                DataNascimento = _dataNascimento
            }
        };
    }
}