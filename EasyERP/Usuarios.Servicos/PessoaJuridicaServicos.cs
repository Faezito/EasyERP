using AutoMapper;
using CrossCutting.Model.DTOs.PessoaJuridica;
using CrossCutting.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Usuarios.Repositorio;
using Usuarios.Repositorio.Entidades;

namespace Usuarios.Servicos
{
    public interface IPessoaJuridicaServicos : ICRUDGenerico<PessoaJuridica>
    {
        Task Cadastro(PessoaJuridicaCadastroDTO dto);
        Task Atualizacao(PessoaJuridicaAlteracaoDTO dto);
        Task Deletar(Guid publicId);
        Task<PessoaJuridicaRespostaDTO> ObterPorId(Guid publicId);
        Task<PessoaJuridica?> ObterPJPorId(Guid publicId);
        Task<List<PessoaJuridicaRespostaDTO>> ListarEmpresas();
        Task CadastrarBulk(List<PessoaJuridicaCadastroDTO> dto);
    }
    public class PessoaJuridicaServicos : CRUDGenerico<PessoaJuridica>, IPessoaJuridicaServicos
    {
        private readonly IMapper _mapper;
        private readonly IPessoaFisicaServicos _pessoaFisicaServicos;

        public PessoaJuridicaServicos(AppDbContext db, IMapper mapper, IPessoaFisicaServicos pessoaFisicaServicos) : base(db)
        {
            _mapper = mapper;
            _pessoaFisicaServicos = pessoaFisicaServicos;
        }
        public async Task Cadastro(PessoaJuridicaCadastroDTO dto)
        {
            var pj = _mapper.Map<PessoaJuridica>(dto);
            pj.Endereco = _mapper.Map<Endereco>(dto.Endereco);

            var responsavel = await _pessoaFisicaServicos.ObterPessoaPorPublicId(dto.ResponsavelPublicId!.Value)
                ?? throw new Exception("Erro ao cadastrar empresa: Responsável não encontrado");

            pj.ResponsavelId = responsavel.Id;
            pj.Responsavel = responsavel;
            pj.CriadoEm = DateTime.Now;

            Adicionar(pj);
            await SalvarAsync();
        }

        public async Task Atualizacao(PessoaJuridicaAlteracaoDTO dto)
        {
            var pj = await ObterPJPorId(dto.PublicId) ?? throw new Exception("Empresa não encontrada");

            pj.NomeFantasia = string.IsNullOrWhiteSpace(dto.NomeFantasia) ? pj.NomeFantasia : dto.NomeFantasia;
            pj.RazaoSocial = string.IsNullOrWhiteSpace(dto.RazaoSocial) ? pj.RazaoSocial : dto.RazaoSocial;
            pj.Telefone = string.IsNullOrWhiteSpace(dto.Telefone) ? pj.Telefone : dto.Telefone;
            pj.Situacao = dto.Situacao != pj.Situacao ? dto.Situacao : pj.Situacao;
            pj.AtualizadoEm = DateTime.Now;

            if (pj.Responsavel.PublicId != dto.ResponsavelPublicId)
            {
                var responsavel = await _pessoaFisicaServicos.ObterPessoaPorPublicId(dto.ResponsavelPublicId!.Value);
                pj.ResponsavelId = responsavel!.Id;
            }
            await SalvarAsync();
        }

        public async Task<PessoaJuridica?> ObterPJPorId(Guid publicId)
        {
            return await _dbSet
                        .Include(x => x.Endereco)
                        .Include(x => x.Responsavel)
                        .FirstOrDefaultAsync(x => x.PublicId == publicId);
        }

        public async Task<PessoaJuridicaRespostaDTO> ObterPorId(Guid publicId)
        {
            var pj = await _dbSet
                        .Include(x => x.Endereco)
                        .Include(x => x.Responsavel)
                        .FirstOrDefaultAsync(x => x.PublicId == publicId);
            return _mapper.Map<PessoaJuridicaRespostaDTO>(pj);
        }

        public async Task<List<PessoaJuridicaRespostaDTO>> ListarEmpresas()
        {
            var pessoas = await _dbSet
                        .Include(x => x.Endereco)
                        .Include(x => x.Responsavel)
                        .ToListAsync();

            return _mapper.Map<List<PessoaJuridicaRespostaDTO>>(pessoas);
        }

        public async Task CadastrarBulk(List<PessoaJuridicaCadastroDTO> dto)
        {
            int distintos = dto
                    .DistinctBy(x => x.ResponsavelPublicId)
                    .Count();

            PessoaFisica responsavelDistinto = new();
            if (distintos == 1)
            {
                responsavelDistinto = await _pessoaFisicaServicos.ObterPessoaPorPublicId(dto[0].ResponsavelPublicId!.Value)
                        ?? throw new Exception("Erro ao cadastrar empresa: Responsável não encontrado");
            }

            foreach (var pessoa in dto)
            {
                var pj = _mapper.Map<PessoaJuridica>(pessoa);
                pj.Endereco = _mapper.Map<Endereco>(pessoa.Endereco);

                if (distintos > 1)
                {
                    var responsavel = await _pessoaFisicaServicos.ObterPessoaPorPublicId(pessoa.ResponsavelPublicId!.Value)
                        ?? throw new Exception("Erro ao cadastrar empresa: Responsável não encontrado");

                    pj.ResponsavelId = responsavel.Id;
                    pj.Responsavel = responsavel;
                }
                else
                {
                    pj.ResponsavelId = responsavelDistinto.Id;
                    pj.Responsavel = responsavelDistinto;
                }

                pj.CriadoEm = DateTime.Now;

                Adicionar(pj);
            }
            await SalvarAsync();
        }

        public async Task Deletar(Guid publicId)
        {
            var pessoa = await ObterPJPorId(publicId);
            if (pessoa == null) throw new Exception("Erro ao excluir: Pessoa não encontrada.");

            _db.Remove(pessoa);
            await SalvarAsync();
        }
    }
}