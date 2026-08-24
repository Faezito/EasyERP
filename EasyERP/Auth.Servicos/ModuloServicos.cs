using Auth.Repositorio;
using Auth.Repositorio.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Servicos;

public interface IModuloServicos : ICRUDGenerico<Modulo>
{
    Task<Modulo> ObterPorId(int id);
    Task<List<Modulo>> Listar();
    Task Cadastrar(Modulo modulo);
    Task Atualizar(Modulo modulo);
    Task Deletar(int id);
}

public class ModuloServicos : CRUDGenerico<Modulo>, IModuloServicos
{
    private readonly IMapper _mapper;

    public ModuloServicos(AppDbContext db, IMapper mapper) : base(db)
    {
        _mapper = mapper;
    }

    public async Task<Modulo> ObterPorId(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Modulo>> Listar()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task Cadastrar(Modulo modulo)
    {
        Adicionar(modulo);
        await SalvarAsync();
    }

    public async Task Atualizar(Modulo modulo)
    {
        var existente = await _dbSet.FirstOrDefaultAsync(x => x.Id == modulo.Id);
        if (existente == null)
            throw new Exception("Módulo não encontrado.");

        existente.Nome = modulo.Nome;
        existente.Descricao = modulo.Descricao;
        existente.Ativo = modulo.Ativo;
        existente.BaseUrl = modulo.BaseUrl;
        existente.HealthCheckPath = modulo.HealthCheckPath;
        existente.VersaoApi = modulo.VersaoApi;

        await SalvarAsync();
    }

    public async Task Deletar(int id)
    {
        var modulo = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (modulo == null)
            throw new Exception("Módulo não encontrado.");

        _dbSet.Remove(modulo);
        await SalvarAsync();
    }
}
