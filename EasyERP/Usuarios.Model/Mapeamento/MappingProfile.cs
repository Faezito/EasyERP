using AutoMapper;
using Usuarios.Model.DTOs;
using Usuarios.Model.Entidades;

namespace Usuarios.Model.Mapeamento
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioCadastroDTO, PessoaFisica>();
            CreateMap<UsuarioAtualizacaoDTO, PessoaFisica>();
            CreateMap<UsuarioAtualizacaoDTO, PessoaFisica>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UsuarioRespostaDTO, PessoaFisica>();
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
