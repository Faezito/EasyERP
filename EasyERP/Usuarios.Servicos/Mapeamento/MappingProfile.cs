using AutoMapper;
using Model.DTOs.Endereco;
using Model.DTOs.PessoaFisica;
using Model.DTOs.PessoaJuridica;
using Model.DTOs.Usuario;
using Usuarios.Repositorio.Entidades;

namespace Usuarios.Model.Mapeamento
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioCadastroDTO, PessoaFisica>();
            CreateMap<UsuarioRespostaDTO, PessoaFisica>();

            CreateMap<PessoaFisica, PessoaFisicaRespostaDTO>();
            CreateMap<PessoaFisicaCadastroDTO, PessoaFisica>();
            CreateMap<PessoaFisica, PessoaFisicaCadastroDTO>();
            CreateMap<PessoaFisicaAtualizacaoDTO, PessoaFisica>();
            CreateMap<PessoaFisica, PessoaFisicaAtualizacaoDTO>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PessoaFisica, UsuarioRespostaDTO>();

            CreateMap<EnderecoCadastroDTO, Endereco>();
            CreateMap<Endereco, EnderecoCadastroDTO>();

            CreateMap<PessoaJuridica, PessoaJuridicaCadastroDTO>();
            CreateMap<PessoaJuridica, PessoaJuridicaAlteracaoDTO>();
            CreateMap<PessoaJuridica, PessoaJuridicaRespostaDTO>();
            CreateMap<PessoaJuridicaCadastroDTO, PessoaJuridica>();
            CreateMap<PessoaJuridicaAlteracaoDTO, PessoaJuridica>();
            CreateMap<PessoaJuridicaAlteracaoDTO, PessoaJuridica>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
