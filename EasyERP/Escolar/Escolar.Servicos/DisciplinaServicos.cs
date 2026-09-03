using AutoMapper;
using Escolar.Repositorio;
using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Escolar.Disciplina;

namespace Escolar.Servicos;

public interface IDisciplinaServicos : ICRUDGenerico<Disciplina>
{
    Task<List<DisciplinaRespostaDTO>> Listar(int pessoaJuridicaId);
    Task<DisciplinaRespostaDTO> ObterPorId(int id);
    Task Atualizar(DisciplinaAtualizacaoDTO disciplinaDto);
    Task Cadastrar(DisciplinaCadastroDTO disciplinaDto);
    Task Excluir(int id);
}

public class DisciplinaServicos(AppDbContext db, IMapper mapper) : CRUDGenerico<Disciplina>(db, mapper), IDisciplinaServicos
{
    public async Task Atualizar(DisciplinaAtualizacaoDTO disciplinaDto)
    {
        var disciplina = await _dbSet.FirstOrDefaultAsync(x => x.Id == disciplinaDto.Id)
            ?? throw new Exception("Erro ao atualizar: Disciplina não encontrada");
        disciplina.Nome = string.IsNullOrWhiteSpace(disciplinaDto.Nome) ? disciplina.Nome : disciplinaDto.Nome;
        disciplina.Descricao = string.IsNullOrWhiteSpace(disciplinaDto.Descricao) ? disciplina.Descricao : disciplinaDto.Descricao;
        disciplina.Ativa = disciplinaDto.Ativa;

        await SalvarAsync();
    }

    public async Task Cadastrar(DisciplinaCadastroDTO disciplinaDto)
    {
        var disciplina = _mapper.Map<Disciplina>(disciplinaDto);
        await AdicionarAsync(disciplina);
    }

    public async Task Excluir(int id)
    {
        var disciplina = await ObterPorIdAsync(id)
            ?? throw new Exception("Erro ao deletar: disciplina não encontrada.");
        disciplina.Deletar();
        await SalvarAsync();
    }

    public async Task<List<DisciplinaRespostaDTO>> Listar(int pessoaJuridicaId)
    {
        var disciplinas = await _dbSet
                                .AsNoTracking()
                                .Where(x => x.PessoaJuridicaId == pessoaJuridicaId)
                                .ToListAsync();

        return _mapper.Map<List<DisciplinaRespostaDTO>>(disciplinas);
    }

    public async Task<DisciplinaRespostaDTO> ObterPorId(int id)
    {
        var disciplina = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new Exception("Disciplina não encontrada.");
        return _mapper.Map<DisciplinaRespostaDTO>(disciplina);
    }
}
