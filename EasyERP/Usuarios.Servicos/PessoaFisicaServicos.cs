using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.PessoaFisica;
using Model.DTOs.Usuario;
using Usuarios.Repositorio.Entidades;
using Usuarios.Repositorio;
using bC = BCrypt.Net.BCrypt;

namespace Usuarios.Servicos
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
        private readonly IEnderecoServicos _servicoEndereco;
        public PessoaFisicaServicos(AppDbContext db, IMapper mapper, IEnderecoServicos servicoEndereco) : base(db)
        {
            _mapper = mapper;
            _servicoEndereco = servicoEndereco;
        }

        public async Task Atualizar(PessoaFisicaAtualizacaoDTO dto)
        {
            var pessoa = _mapper.Map<PessoaFisica>(dto);
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
            var pessoas = await ObterTodosAsync();
            return _mapper.Map<List<PessoaFisicaRespostaDTO>>(pessoas);
        }

        public async Task<PessoaFisicaRespostaDTO> ObterPorId(int id)
        {
            var pessoa = await ObterPorIdAsync(id);
            return _mapper.Map<PessoaFisicaRespostaDTO>(pessoa);
        }

        public async Task<PessoaFisicaRespostaDTO> ObterPorPublicId(Guid publicId)
        {
            var pessoa = await _db.Set<PessoaFisica>().FirstOrDefaultAsync(x=>x.PublicId == publicId);
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
