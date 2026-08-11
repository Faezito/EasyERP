using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Endereco;
using Escolar.Repositorio.Entidades;
using Escolar.Repositorio;

namespace Escolar.Servicos;

public interface IEnderecoServicos : ICRUDGenerico<Endereco>
{
    public Task RemoverEnderecoDaPessoa(int pessoaId);
    public Task RemoverEnderecoDaPessoa(Guid pessoaPublicId);
    Task AtualizarAsync(EnderecoAtualizacaoDTO dto);
    void AtualizarEndereco(Endereco enderecoOriginal, EnderecoAtualizacaoDTO dto);
    Task Inserir(EnderecoCadastroDTO dto);
}
public class EnderecoServicos(AppDbContext db, IMapper mapper) : CRUDGenerico<Endereco>(db, mapper), IEnderecoServicos
{
    public void AtualizarEndereco(Endereco enderecoOriginal, EnderecoAtualizacaoDTO dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.CEP))
            enderecoOriginal.CEP = dto.CEP;

        if (!string.IsNullOrWhiteSpace(dto.Numero))
            enderecoOriginal.Numero = dto.Numero;

        if (!string.IsNullOrWhiteSpace(dto.Logradouro))
            enderecoOriginal.Logradouro = dto.Logradouro;

        if (!string.IsNullOrWhiteSpace(dto.Bairro))
            enderecoOriginal.Bairro = dto.Bairro;

        if (!string.IsNullOrWhiteSpace(dto.Cidade))
            enderecoOriginal.Cidade = dto.Cidade;

        if (!string.IsNullOrWhiteSpace(dto.Estado))
            enderecoOriginal.Estado = dto.Estado;

        if (!string.IsNullOrWhiteSpace(dto.Pais))
            enderecoOriginal.Pais = dto.Pais;

        if (!string.IsNullOrWhiteSpace(dto.Complemento))
            enderecoOriginal.Complemento = dto.Complemento.Trim();
    }

    public async Task AtualizarAsync(EnderecoAtualizacaoDTO dto)
    {
        Atualizar(_mapper.Map<Endereco>(dto));
        await SalvarAsync();
    }

    public async Task Inserir(EnderecoCadastroDTO dto)
    {
        Adicionar(_mapper.Map<Endereco>(dto));
        await SalvarAsync();
    }

    public async Task RemoverEnderecoDaPessoa(int pessoaId)
    {
        var pessoa = await _db.Pessoas
                    .Include(x => x.Endereco)
                    .FirstOrDefaultAsync(x => x.Id == pessoaId);

        if (pessoa == null) throw new Exception("Pessoa não encontrada");
        if (pessoa.Endereco == null) return;

        Remover(pessoa.Endereco);

        pessoa.Endereco = null;

        await SalvarAsync();
    }

    public async Task RemoverEnderecoDaPessoa(Guid pessoaPublicId)
    {
        var pessoa = await _db.Pessoas
                    .Include(x => x.Endereco)
                    .FirstOrDefaultAsync(x => x.PublicId == pessoaPublicId);

        if (pessoa == null) throw new Exception("Pessoa não encontrada");
        if (pessoa.Endereco == null) return;

        Remover(pessoa.Endereco);
        pessoa.Endereco = null;

        await SalvarAsync();
    }
}
