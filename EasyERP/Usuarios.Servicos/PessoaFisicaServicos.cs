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
        Task Atualizar(PessoaFisicaAtualizacaoDTO dto);
        Task<PessoaFisicaRespostaDTO> ObterPorId(int id);
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

        public Task Atualizar(PessoaFisicaAtualizacaoDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task Cadastrar(PessoaFisicaCadastroDTO dto)
        {
            var pessoa = _mapper.Map<PessoaFisica>(dto);
            pessoa.CriadoEm = DateTime.Now;
            Adicionar(pessoa);
            await SalvarAsync();
        }

        public Task Deletar(Guid publicId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PessoaFisicaRespostaDTO>> Listar()
        {
            var pessoas = await ObterTodosAsync();
            return _mapper.Map<List<PessoaFisicaRespostaDTO>>(pessoas);
        }

        public Task<PessoaFisicaRespostaDTO> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PessoaFisicaRespostaDTO> ObterPorPublicId(Guid publicId)
        {
            throw new NotImplementedException();
        }
    }
}
