using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Usuarios.Model.DTOs;
using Usuarios.Model.Entidades;
using Usuarios.Repositorio;
using bC = BCrypt.Net.BCrypt;

namespace Usuarios.Servicos
{
    public interface IPessoaFisicaServicos : ICRUDGenerico<PessoaFisica>
    {
        Task Cadastro(UsuarioCadastroDTO dto);
        Task Atualizacao(UsuarioAtualizacaoDTO dto);
        Task Deletar(int id);
        Task<PessoaFisica?> ObterPessoaPorId(int pessoaId);
        Task<UsuarioRespostaDTO?> ObterUsuarioPorId(int pessoaId);
        Task<List<UsuarioRespostaDTO>> ListarUsuarios();
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

        public async Task<PessoaFisica?> ObterPessoaPorId(int pessoaId)
        {
            return await _dbSet
                        .Include(x => x.Endereco)
                        .FirstOrDefaultAsync(x => x.Id == pessoaId);
        }

        public async Task<UsuarioRespostaDTO?> ObterUsuarioPorId(int pessoaId)
        {
            var pessoa = await ObterPessoaPorId(pessoaId);
            return _mapper.Map<UsuarioRespostaDTO>(pessoa);
        }

        public async Task<List<UsuarioRespostaDTO>> ListarUsuarios()
        {
            var pessoas = await _dbSet
                        .Include(x => x.Endereco)
                        .ToListAsync();
            return _mapper.Map<List<UsuarioRespostaDTO>>(pessoas);
        }

        public async Task Cadastro(UsuarioCadastroDTO dto)
        {
            var pessoa = _mapper.Map<PessoaFisica>(dto);
            pessoa.SenhaHash = bC.HashPassword(dto.Senha);
            pessoa.CriadoEm = DateTime.Now;

            pessoa.Endereco = _mapper.Map<Endereco>(dto.Endereco);
            Adicionar(pessoa);
            await SalvarAsync();
        }

        public async Task Atualizacao(UsuarioAtualizacaoDTO dto)
        {
            var pessoa = await ObterPorIdAsync(dto.Id) ?? throw new Exception("Usuário não encontrado");
            pessoa.CriadoEm = DateTime.Now;
            pessoa.SenhaHash = string.IsNullOrWhiteSpace(dto.Senha) ? pessoa.SenhaHash : bC.HashPassword(dto.Senha);
            pessoa.Perfil = dto.Perfil ?? pessoa.Perfil;

            await SalvarAsync();
        }

        public async Task Deletar(int id)
        {
            var pessoa = await ObterPorIdAsync(id);
            if (pessoa == null) throw new Exception("Erro ao excluir usuário: Pessoa não encontrada.");

            Remover(pessoa);

            if (pessoa.EnderecoId.HasValue)
                _servicoEndereco.Remover(new Endereco { Id = pessoa.EnderecoId.Value });

            await SalvarAsync();
        }
    }
}
