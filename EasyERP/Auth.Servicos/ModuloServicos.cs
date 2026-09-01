using Auth.Repositorio;
using Auth.Repositorio.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;

namespace Auth.Servicos;

public interface IModuloServicos : ICRUDGenerico<Modulo>
{
    Task<ModuloDTO> ObterPorId(int id);
    Task<List<ModuloDTO>> ListarTodos();
    Task Cadastrar(ModuloCadastroDTO modulo);
    Task Atualizar(ModuloDTO modulo);
    Task Deletar(int id);
}

public class ModuloServicos(AppDbContext db, IMapper mapper) : CRUDGenerico<Modulo>(db), IModuloServicos
{
    private readonly IMapper _mapper = mapper;

    public async Task Cadastrar(ModuloCadastroDTO modulo)
    {
        var novoModulo = _mapper.Map<Modulo>(modulo);
        Adicionar(novoModulo);
        await SalvarAsync();
    }

    public async Task Atualizar(ModuloDTO modulo)
    {
        var existente = await _dbSet.FirstOrDefaultAsync(x => x.Id == modulo.Id);
        if (existente == null)
            throw new Exception("Módulo não encontrado");

        existente.Nome = modulo.Nome ?? existente.Nome;
        existente.Descricao = modulo.Descricao ?? existente.Descricao;
        existente.Ativo = modulo.Ativo;
        existente.BaseUrl = modulo.BaseUrl ?? existente.BaseUrl;
        existente.Imagem = modulo.Imagem ?? existente.Imagem;
        existente.ModuloPaiId = modulo.ModuloPaiId ?? existente.ModuloPaiId;

        await SalvarAsync();
    }

    public async Task Deletar(int id)
    {
        var modulo = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (modulo == null)
            throw new Exception("Módulo não encontrado");

        _dbSet.Remove(modulo);
        await SalvarAsync();
    }

    public async Task<List<ModuloDTO>> ListarTodos()
    {
        var modulos = await _dbSet.ToListAsync();
        return _mapper.Map<List<ModuloDTO>>(modulos);
    }

    public async Task<ModuloDTO> ObterPorId(int id)
    {
        var modulo = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<ModuloDTO>(modulo);
    }
}
