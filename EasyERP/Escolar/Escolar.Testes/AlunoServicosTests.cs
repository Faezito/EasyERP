using AutoMapper;
using Biblioteca;
using Bogus;
using CrossCutting.Model.DTOs.Escolar.Aluno;
using Escolar.Repositorio;
using Escolar.Repositorio.Entidades;
using Escolar.Servicos;
using Escolar.Servicos.Mapeamento;
using Escolar.Tests.Builders;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Endereco;
using Model.DTOs.Escolar.Pessoa;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web.WebPages;
using Xunit.Abstractions;

namespace Escolar.Testes;

public class AlunoServicosTests
{
    private readonly ITestOutputHelper outputHelper;
    public AlunoServicosTests(ITestOutputHelper outputHelper)
    {
        this.outputHelper = outputHelper;
    }

    [Fact]
    public async Task Teste_Cadastro_DeveAdicionarAluno()
    {
        var db = CriarContexto();
        var mapper = CriarMapper();

        var servico = new AlunoServicos(db, mapper);

        var aluno = new AlunoCadastroDTOBuilder()
            .Build();

        Teste_validar_model(aluno);

        await servico.Cadastro(aluno);

        var alunoCadastrado = await db.Alunos
            .Include(x => x.Pessoa)
            .ToListAsync();

        Assert.NotNull(alunoCadastrado);

        var json = JsonSerializer.Serialize(alunoCadastrado, new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });

        outputHelper.WriteLine(json);
    }

    [Fact]
    public async Task Teste_Cadastro_AlunoInvalido()
    {
        var db = CriarContexto();
        var mapper = CriarMapper();

        var servico = new AlunoServicos(db, mapper);

        var aluno = new AlunoCadastroDTOBuilder()
            .ComNome(string.Empty)
            .ComEmail(string.Empty)
            .ComGenero("")
            .Build();

        Teste_validar_model(aluno);

        await servico.Cadastro(aluno);

        var alunoCadastrado = await db.Alunos
            .Include(x => x.Pessoa)
            .ToListAsync();

        Assert.NotNull(alunoCadastrado);

        var json = JsonSerializer.Serialize(alunoCadastrado, new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });

        outputHelper.WriteLine(json);
    }

    [Fact]
    public async Task Teste_Exclusao()
    {
        var db = CriarContexto();
        var mapper = CriarMapper();

        var servico = new AlunoServicos(db, mapper);

        var alunosDto = CriarAlunos_Cadastro();
        foreach (var dto in alunosDto)
        {
            var aluno = mapper.Map<Aluno>(dto);
            db.Alunos.Add(aluno);
            await db.SaveChangesAsync();
        }

        var alunos = await db.Alunos
            .Include(x => x.Pessoa)
            .ToListAsync();

        foreach (var a in alunos)
            await servico.Excluir(a.Pessoa.PublicId);

        Assert.NotNull(alunos);

        var json = JsonSerializer.Serialize(alunos, new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });

        outputHelper.WriteLine(json);
    }

    [Fact]
    public async Task Teste_Atualizacao()
    {
        var db = CriarContexto();
        var mapper = CriarMapper();

        var servico = new AlunoServicos(db, mapper);

        var alunosDto = CriarAlunos_Cadastro();
        foreach (var dto in alunosDto)
        {
            var novoAluno = mapper.Map<Aluno>(dto);
            db.Alunos.Add(novoAluno);
            await db.SaveChangesAsync();
        }

        var aluno = await db.Alunos
            .Include(x => x.Pessoa)
            .FirstOrDefaultAsync();

        var updtDto = new AlunoAtualizacaoDTO
        {
            PessoaId = aluno!.Pessoa.PublicId,
            NomeCompleto = "Carlos da Silva"
        };

        await servico.Atualizacao(updtDto);

        var alunoAtualizado = await db.Alunos.Include(x => x.Pessoa).FirstOrDefaultAsync();
        Assert.Equal("Carlos da Silva", alunoAtualizado!.Pessoa.NomeCompleto);

        var json = JsonSerializer.Serialize(alunoAtualizado, new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });

        outputHelper.WriteLine(json);
    }


    private void Teste_validar_model(object objeto)
    {
        var modelState = Validacoes.ValidarModel(objeto);
        if (!modelState.IsValid)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors).Select(m => m.ErrorMessage).ToList();
            foreach (var e in erros)
                outputHelper.WriteLine(e);
        }

        Assert.True(modelState.IsValid);
    }
    private List<AlunoCadastroDTO> CriarAlunos_Cadastro(int quantidade = 1)
    {
        var alunos = Enumerable
            .Range(1, quantidade)
            .Select(_ => new AlunoCadastroDTOBuilder().Build())
            .ToList();

        return alunos;
    }

    private IMapper CriarMapper()
    {
        var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                },
                new Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory()
            );

        return config.CreateMapper();
    }

    private AppDbContext CriarContexto()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var httpContextAccessor = new HttpContextAccessor();

        return new AppDbContext(options, httpContextAccessor);
    }
}
