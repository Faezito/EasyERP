using AutoMapper;
using CrossCutting.Model.DTOs.Escolar.Presenca;
using Escolar.Repositorio;
using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Escolar.Servicos;

public interface IPresencaServicos : ICRUDGenerico<Presenca>
{
    Task Atualizar(PresencaAtualizacaoDTO presencaDto);
    Task Cadastrar(PresencaCadastroDTO presencaDto);
    Task Excluir(int id);
}

public class PresencaServicos(AppDbContext db, IMapper mapper) : CRUDGenerico<Presenca>(db, mapper), IPresencaServicos
{
    public async Task Atualizar(PresencaAtualizacaoDTO presencaDto)
    {
        var presenca = await _dbSet.FirstOrDefaultAsync(x => x.Id == presencaDto.Id)
            ?? throw new Exception("Erro ao atualizar: Presença não encontrada");

        presenca.Data = presencaDto.Data;
        presenca.Presente = presencaDto.Presente;

        await SalvarAsync();
    }

    public async Task Cadastrar(PresencaCadastroDTO presencaDto)
    {
        var presenca = _mapper.Map<Presenca>(presencaDto);
        await AdicionarAsync(presenca);
    }

    public async Task Excluir(int id)
    {
        var presenca = await ObterPorIdAsync(id)
            ?? throw new Exception("Erro ao deletar: presença não encontrada.");
        presenca.Deletar();
        await SalvarAsync();
    }
}