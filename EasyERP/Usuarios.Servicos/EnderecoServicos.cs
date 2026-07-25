using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Usuarios.Model.DTOs;
using Usuarios.Model.Entidades;
using Usuarios.Repositorio;

namespace Usuarios.Servicos
{
    public interface IEnderecoServicos : ICRUDGenerico<Endereco>
    {
        public Task RemoverEnderecoDaPessoa(int pessoaId);
        Task AtualizarAsync(EnderecoAtualizacaoDTO dto);
        Task Inserir(EnderecoCadastroDTO dto);
    }
    public class EnderecoServicos : CRUDGenerico<Endereco>, IEnderecoServicos
    {
        private readonly IMapper _mapper;
        public EnderecoServicos(AppDbContext db, IMapper mapper) : base(db)
        {
            _mapper = mapper;
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
            var pessoa = await _db.Set<PessoaFisica>()
                        .Include(x => x.Endereco)
                        .FirstOrDefaultAsync(x => x.Id == pessoaId);

            if (pessoa == null) throw new Exception("Pessoa não encontrada");
            if (pessoa.Endereco == null) return;

            Remover(pessoa.Endereco);

            pessoa.Endereco = null;
            pessoa.EnderecoId = null;

            await SalvarAsync();
        }
    }
}
