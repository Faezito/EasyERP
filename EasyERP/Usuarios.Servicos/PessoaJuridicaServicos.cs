using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.PessoaJuridica;
using Usuarios.Repositorio;
using Usuarios.Repositorio.Entidades;
using bC = BCrypt.Net.BCrypt;

namespace Usuarios.Servicos
{
    public interface IPessoaJuridicaServicos : ICRUDGenerico<PessoaJuridica>
    {
        Task Cadastro(PessoaJuridicaCadastroDTO dto);
        Task Atualizacao(PessoaJuridicaAlteracaoDTO dto);
        Task Deletar(int id);
        Task<PessoaJuridica?> ObterPorId(int id);
        Task<PessoaJuridicaRespostaDTO?> ObterEmpresaPorId(int id);
        Task<List<PessoaJuridicaRespostaDTO>> ListarEmpresas();
    }
    public class PessoaJuridicaServicos : CRUDGenerico<PessoaJuridica>, IPessoaJuridicaServicos
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoServicos _enderecoServicos;

        public PessoaJuridicaServicos(AppDbContext db, IMapper mapper, IEnderecoServicos enderecoServicos) : base(db)
        {
            _mapper = mapper;
            _enderecoServicos = enderecoServicos;
        }
        public async Task Cadastro(PessoaJuridicaCadastroDTO dto)
        {
            var pj = _mapper.Map<PessoaJuridica>(dto);
            pj.CriadoEm = DateTime.Now;

            pj.Endereco = _mapper.Map<Endereco>(dto.Endereco);
            Adicionar(pj);
            await SalvarAsync();
        }

        public async Task Atualizacao(PessoaJuridicaAlteracaoDTO dto)
        {
            var pj = await ObterPorIdAsync(dto.Id) ?? throw new Exception("Usuário não encontrado");
            pj.CriadoEm = DateTime.Now;

            await SalvarAsync();
        }

        public async Task Deletar(int id)
        {
            var pessoa = await ObterPorIdAsync(id);
            if (pessoa == null) throw new Exception("Erro ao excluir usuário: Pessoa não encontrada.");

            Remover(pessoa);
            //_enderecoServicos.Remover(new Endereco { Id = pessoa.EnderecoId });
            await SalvarAsync();
        }

        public async Task<PessoaJuridica?> ObterPorId(int id)
        {
            return await _dbSet
                        .Include(x => x.Endereco)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PessoaJuridicaRespostaDTO?> ObterEmpresaPorId(int id)
        {
            var pessoa = await ObterPorId(id);
            return _mapper.Map<PessoaJuridicaRespostaDTO>(pessoa);
        }

        public async Task<List<PessoaJuridicaRespostaDTO>> ListarEmpresas()
        {
            var pessoas = await _dbSet
                        .Include(x => x.Endereco)
                        .ToListAsync();

            return _mapper.Map<List<PessoaJuridicaRespostaDTO>>(pessoas);
        }
    }
}