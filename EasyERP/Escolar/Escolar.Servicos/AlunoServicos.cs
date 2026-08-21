using AutoMapper;
using CrossCutting.Model.DTOs.Escolar.Aluno;
using Escolar.Repositorio;
using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Escolar.Servicos;

public interface IAlunoServicos : ICRUDGenerico<Aluno>
{
    Task<List<AlunoRespostaDTO>> Listar();
    Task Cadastro(AlunoCadastroDTO alunoDto);
    Task Atualizacao(AlunoAtualizacaoDTO alunoDto);
    Task Excluir(Guid publicId);
}

public class AlunoServicos(AppDbContext db, IMapper mapper) : CRUDGenerico<Aluno>(db, mapper), IAlunoServicos
{
    public async Task Atualizacao(AlunoAtualizacaoDTO alunoDto)
    {
        var aluno = await _dbSet.Include(x=>x.Pessoa).FirstOrDefaultAsync(x=>x.Pessoa.PublicId == alunoDto.PessoaId)
            ?? throw new Exception("Erro ao atualizar: Aluno não encontrado");
        var pessoa = aluno.Pessoa;

        pessoa.NomeCompleto = string.IsNullOrWhiteSpace(alunoDto.NomeCompleto) ? pessoa.NomeCompleto : alunoDto.NomeCompleto;
        pessoa.Genero = string.IsNullOrWhiteSpace(alunoDto.Genero) ? pessoa.Genero : alunoDto.Genero;
        pessoa.Telefone = string.IsNullOrWhiteSpace(alunoDto.Telefone) ? pessoa.Telefone : alunoDto.Telefone;
        pessoa.Email = string.IsNullOrWhiteSpace(alunoDto.Email) ? pessoa.Email : alunoDto.Email;

        aluno.TurmaId = alunoDto.TurmaId ?? aluno.TurmaId;

        await SalvarAsync();
    }

    public async Task Cadastro(AlunoCadastroDTO alunoDto)
    {
        var aluno = _mapper.Map<Aluno>(alunoDto);
        await AdicionarAsync(aluno);
    }

    public async Task Excluir(Guid publicId)
    {
        var aluno = await ObterPorIdAsync(publicId) 
            ?? throw new Exception("Erro ao deletar: aluno não encontrado.");
        aluno.Deletar();
        await SalvarAsync();
    }

    public async Task<List<AlunoRespostaDTO>> Listar()
    {
        var alunos = await _dbSet.AsNoTracking().ToListAsync();
        return _mapper.Map<List<AlunoRespostaDTO>>(alunos);
    }
}
