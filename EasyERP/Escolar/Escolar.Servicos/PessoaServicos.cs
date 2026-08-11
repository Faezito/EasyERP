using AutoMapper;
using Escolar.Repositorio;
using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Escolar.Pessoa;

namespace Escolar.Servicos;

public interface IPessoaServicos : ICRUDGenerico<Pessoa>
{
    Task Cadastrar(PessoaCadastroDTO dto);
    Task CadastrarBulk(List<PessoaCadastroDTO> dto);
    Task Atualizar(PessoaAtualizacaoDTO dto);
    Task<PessoaRespostaDTO> ObterPorId(int id);
    Task<Pessoa?> ObterPessoaPorPublicId(Guid publicId);
    Task<PessoaRespostaDTO> ObterPorPublicId(Guid publicId);
    Task<List<PessoaRespostaDTO>> Listar();
    Task Deletar(Guid publicId);
}

public class PessoaServicos(AppDbContext db, IMapper mapper) : CRUDGenerico<Pessoa>(db, mapper), IPessoaServicos
{
    public async Task Atualizar(PessoaAtualizacaoDTO dto)
    {
        var pessoa = await _db.Set<Pessoa>().FirstOrDefaultAsync(x => x.PublicId == dto.PublicId)
            ?? throw new Exception("Erro ao atualizar: Usuário não encontrado");

        pessoa.NomeCompleto = string.IsNullOrWhiteSpace(dto.NomeCompleto) ? pessoa.NomeCompleto : dto.NomeCompleto;
        pessoa.Genero = string.IsNullOrWhiteSpace(dto.Genero) ? pessoa.Genero : dto.Genero;
        pessoa.Telefone = string.IsNullOrWhiteSpace(dto.Telefone) ? pessoa.Telefone : dto.Telefone;
        pessoa.Email = string.IsNullOrWhiteSpace(dto.Email) ? pessoa.Email : dto.Email;

        _dbSet.Update(pessoa);
        await SalvarAsync();
    }

    public async Task Cadastrar(PessoaCadastroDTO dto)
    {
        var pessoa = _mapper.Map<Pessoa>(dto);

        if (dto.Endereco != null)
            pessoa.Endereco = _mapper.Map<Endereco>(dto.Endereco);
        Adicionar(pessoa);
        await SalvarAsync();
    }

    public async Task Deletar(Guid publicId)
    {
        var pessoa = await ObterPessoaPorPublicId(publicId);
        if (pessoa == null) throw new Exception("Erro ao excluir: Pessoa não encontrada.");

        _db.Remove(pessoa);
        await SalvarAsync();
    }

    public async Task<List<PessoaRespostaDTO>> Listar()
    {
        var pessoas = await _db.Pessoas
                               .Include(x => x.Endereco)
                               .ToListAsync();
        return _mapper.Map<List<PessoaRespostaDTO>>(pessoas);
    }

    public async Task<PessoaRespostaDTO> ObterPorId(int id)
    {
        var pessoa = await ObterPorIdAsync(id);
        return _mapper.Map<PessoaRespostaDTO>(pessoa);
    }

    public async Task<PessoaRespostaDTO> ObterPorPublicId(Guid publicId)
    {
        var pessoa = await _db.Set<Pessoa>().FirstOrDefaultAsync(x => x.PublicId == publicId);
        return _mapper.Map<PessoaRespostaDTO>(pessoa);
    }

    public async Task<Pessoa?> ObterPessoaPorPublicId(Guid publicId)
    {
        return await _db.Set<Pessoa>().FirstOrDefaultAsync(x => x.PublicId == publicId);
    }

    public async Task CadastrarBulk(List<PessoaCadastroDTO> dto)
    {
        var pessoas = _mapper.Map<List<Pessoa>>(dto);

        foreach (var pessoa in pessoas)
        {
            pessoa.CriadoEm = DateTime.Now;
            Adicionar(pessoa);
        }
        await SalvarAsync();
    }
}
