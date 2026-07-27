using Auth.Repositorio;
using Auth.Repositorio.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.PessoaFisica;

namespace Auth.Servicos
{
    public interface IPessoaFisicaServicos : ICRUDGenerico<PessoaFisica>
    {
        Task Cadastrar(PessoaFisicaCadastroDTO dto);
        Task CadastrarBulk(List<PessoaFisicaCadastroDTO> dto);
        Task Atualizar(PessoaFisicaAtualizacaoDTO dto);
        Task<PessoaFisicaRespostaDTO> ObterPorId(int id);
        Task<PessoaFisica?> ObterPessoaPorPublicId(Guid publicId);
        Task<PessoaFisicaRespostaDTO> ObterPorPublicId(Guid publicId);
        Task<List<PessoaFisicaRespostaDTO>> Listar();
        Task Deletar(Guid publicId);
    }

    public class PessoaFisicaServicos : CRUDGenerico<PessoaFisica>, IPessoaFisicaServicos
    {
        private readonly IMapper _mapper;
        public PessoaFisicaServicos(AppDbContext db, IMapper mapper) : base(db)
        {
            _mapper = mapper;
        }

        public async Task Atualizar(PessoaFisicaAtualizacaoDTO dto)
        {
            var pessoa = await _db.Set<PessoaFisica>().FirstOrDefaultAsync(x => x.PublicId == dto.PublicId)
                ?? throw new Exception("Erro ao atualizar: Usuário não encontrado");

            pessoa.NomeCompleto = string.IsNullOrWhiteSpace(dto.NomeCompleto) ? pessoa.NomeCompleto : dto.NomeCompleto;
            pessoa.Genero = string.IsNullOrWhiteSpace(dto.Genero) ? pessoa.Genero : dto.Genero;
            pessoa.Telefone = string.IsNullOrWhiteSpace(dto.Telefone) ? pessoa.Telefone : dto.Telefone;
            pessoa.Email = string.IsNullOrWhiteSpace(dto.Email) ? pessoa.Email : dto.Email;
            pessoa.AtualizadoEm = DateTime.Now;

            _dbSet.Update(pessoa);
            await SalvarAsync();
        }

        public async Task Cadastrar(PessoaFisicaCadastroDTO dto)
        {
            var pessoa = _mapper.Map<PessoaFisica>(dto);
            pessoa.CriadoEm = DateTime.Now;
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

        public async Task<List<PessoaFisicaRespostaDTO>> Listar()
        {
            var pessoas = await _db.PessoasFisicas
                                   .Include(x => x.Endereco)
                                   .ToListAsync();
            return _mapper.Map<List<PessoaFisicaRespostaDTO>>(pessoas);
        }

        public async Task<PessoaFisicaRespostaDTO> ObterPorId(int id)
        {
            var pessoa = await ObterPorIdAsync(id);
            return _mapper.Map<PessoaFisicaRespostaDTO>(pessoa);
        }

        public async Task<PessoaFisicaRespostaDTO> ObterPorPublicId(Guid publicId)
        {
            var pessoa = await _db.Set<PessoaFisica>().FirstOrDefaultAsync(x => x.PublicId == publicId);
            return _mapper.Map<PessoaFisicaRespostaDTO>(pessoa);
        }

        public async Task<PessoaFisica?> ObterPessoaPorPublicId(Guid publicId)
        {
            return await _db.Set<PessoaFisica>().FirstOrDefaultAsync(x => x.PublicId == publicId);
        }

        public async Task CadastrarBulk(List<PessoaFisicaCadastroDTO> dto)
        {
            var pessoas = _mapper.Map<List<PessoaFisica>>(dto);

            foreach (var pessoa in pessoas)
            {
                pessoa.CriadoEm = DateTime.Now;
                Adicionar(pessoa);
            }
            await SalvarAsync();
        }
    }
}
