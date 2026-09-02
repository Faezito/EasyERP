using AutoMapper;
using CrossCutting.Model.DTOs.Escolar.Aluno;
using Escolar.Repositorio;
using Escolar.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Escolar.Servicos;

public interface IAlunoServicos : ICRUDGenerico<Aluno>
{
    Task<AlunoRespostaDTO> ObterPorId(int id);
    Task<AlunoRespostaDTO> ObterPorPessoaId(Guid pessoaId);
    Task<List<AlunoRespostaDTO>> Listar();
    Task Cadastro(AlunoCadastroDTO alunoDto);
    Task Atualizacao(AlunoAtualizacaoDTO alunoDto);
    Task Excluir(Guid publicId);
}

public class AlunoServicos(AppDbContext db, IMapper mapper) : CRUDGenerico<Aluno>(db, mapper), IAlunoServicos
{
    public async Task Atualizacao(AlunoAtualizacaoDTO alunoDto)
    {
        var aluno = await _dbSet
            .Include(x => x.Pessoa)
            .ThenInclude(x => x.Endereco)
            .FirstOrDefaultAsync(x => x.Pessoa.PublicId == alunoDto.Pessoa!.PublicId)
            ?? throw new Exception("Erro ao atualizar: Aluno não encontrado");

        var pessoa = aluno.Pessoa;

        pessoa.NomeCompleto = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.NomeCompleto) ? pessoa.NomeCompleto : alunoDto.Pessoa.NomeCompleto;
        pessoa.Genero = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Genero) ? pessoa.Genero : alunoDto.Pessoa.Genero;
        pessoa.Telefone = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Telefone) ? pessoa.Telefone : alunoDto.Pessoa.Telefone;
        pessoa.Email = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Email) ? pessoa.Email : alunoDto.Pessoa.Email;

        pessoa.Endereco?.Logradouro = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Endereco?.Logradouro) ? pessoa.Endereco.Logradouro : alunoDto.Pessoa.Endereco.Logradouro;
        pessoa.Endereco?.Numero = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Endereco?.Numero) ? pessoa.Endereco.Numero : alunoDto.Pessoa.Endereco.Numero;
        pessoa.Endereco?.Complemento = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Endereco?.Complemento) ? pessoa.Endereco.Complemento : alunoDto.Pessoa.Endereco.Complemento;
        pessoa.Endereco?.Bairro = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Endereco?.Bairro) ? pessoa.Endereco.Bairro : alunoDto.Pessoa.Endereco.Bairro;
        pessoa.Endereco?.Cidade = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Endereco?.Cidade) ? pessoa.Endereco.Cidade : alunoDto.Pessoa.Endereco.Cidade;
        pessoa.Endereco?.Estado = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Endereco?.Estado) ? pessoa.Endereco.Estado : alunoDto.Pessoa.Endereco.Estado;
        pessoa.Endereco?.CEP = string.IsNullOrWhiteSpace(alunoDto.Pessoa?.Endereco?.CEP) ? pessoa.Endereco.CEP : alunoDto.Pessoa.Endereco.CEP;

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
        var aluno = await _db.Alunos.Include(x => x.Pessoa).FirstOrDefaultAsync(x => x.Pessoa.PublicId == publicId)
            ?? throw new Exception("Erro ao excluir: Aluno não encontrado.");

        aluno.Deletar();
        aluno.Pessoa.Deletar();

        await SalvarAsync();
    }

    public async Task<List<AlunoRespostaDTO>> Listar()
    {
        var alunos = await _dbSet
            .Include(x => x.Pessoa)
                .ThenInclude(x => x.Endereco)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<List<AlunoRespostaDTO>>(alunos);
    }

    public async Task<AlunoRespostaDTO> ObterPorPessoaId(Guid pessoaId)
    {
        var aluno = await _db.Alunos
            .Include(x => x.Pessoa)
                .ThenInclude(x => x.Endereco)
            .FirstOrDefaultAsync(x => x.Pessoa.PublicId == pessoaId)
            ?? throw new Exception("Aluno não encontrado");
        return _mapper.Map<AlunoRespostaDTO>(aluno);
    }

    public async Task<AlunoRespostaDTO> ObterPorId(int id)
    {
        var aluno = await _db.Alunos
            .Include(x => x.Pessoa)
                .ThenInclude(x => x.Endereco)
            .FirstOrDefaultAsync(x => x.Id == id);

        return _mapper.Map<AlunoRespostaDTO>(aluno);
    }
}
