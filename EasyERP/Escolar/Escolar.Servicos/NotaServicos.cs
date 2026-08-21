using AutoMapper;
using CrossCutting.Model.DTOs.Escolar.Nota;
using Escolar.Repositorio;
using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Escolar.Servicos;

public interface INotaServicos : ICRUDGenerico<Nota>
{
    Task Atualizar(NotaAtualizacaoDTO notaDto);
    Task Cadastrar(NotaCadastroDTO notaDto);
    Task Excluir(int id);
    Task<List<Nota>> ListarPorAlunoId(int alunoId);
    Task<List<Nota>> ListarPorPessoaId(Guid pessoaId);
}

public class NotaServicos(AppDbContext db, IMapper mapper) : CRUDGenerico<Nota>(db, mapper), INotaServicos
{
    public async Task Atualizar(NotaAtualizacaoDTO notaDto)
    {
        var nota = await _dbSet.FirstOrDefaultAsync(x => x.Id == notaDto.Id)
            ?? throw new Exception("Erro ao atualizar: Nota não encontrada");

        nota.PontosFeitos = notaDto.PontosFeitos;
        nota.TotalPontos = notaDto.TotalPontos;
        nota.DataLancamento = notaDto.DataLancamento;

        await SalvarAsync();
    }

    public async Task Cadastrar(NotaCadastroDTO notaDto)
    {
        var nota = _mapper.Map<Nota>(notaDto);
        await AdicionarAsync(nota);
    }

    public async Task Excluir(int id)
    {
        var nota = await ObterPorIdAsync(id) 
            ?? throw new Exception("Erro ao deletar: nota não encontrada.");
        nota.Deletar();
        await SalvarAsync();
    }

    public async Task<List<Nota>> ListarPorAlunoId(int alunoId) => 
        await _dbSet.Where(x=>x.AlunoId == alunoId).ToListAsync();

    public async Task<List<Nota>> ListarPorPessoaId(Guid pessoaId) =>
        await _dbSet.Include(x=>x.Aluno).ThenInclude(x=>x.Pessoa).Where(x=>x.Aluno.Pessoa.PublicId == pessoaId).ToListAsync();
}
