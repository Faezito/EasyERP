using AutoMapper;
using CrossCutting.Model.DTOs.PessoaJuridica;
using Model.DTOs.Endereco;
using Model.DTOs.PessoaFisica;
using Model.DTOs.Usuario;
using Auth.Repositorio.Entidades;
using Model.DTOs;

namespace Auth.Servicos.Mapeamento;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioCadastroDTO, PessoaFisica>();
        CreateMap<UsuarioRespostaDTO, PessoaFisica>();

        CreateMap<UsuarioCadastroDTO, Usuario>();
        CreateMap<Usuario, UsuarioCadastroDTO>();

        CreateMap<UsuarioRespostaDTO, Usuario>();
        CreateMap<Usuario, UsuarioRespostaDTO>();

        CreateMap<PessoaFisica, PessoaFisicaRespostaDTO>();
        CreateMap<PessoaFisicaCadastroDTO, PessoaFisica>();
        CreateMap<PessoaFisica, PessoaFisicaCadastroDTO>();
        CreateMap<PessoaFisicaAtualizacaoDTO, PessoaFisica>();
        CreateMap<PessoaFisica, PessoaFisicaAtualizacaoDTO>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<PessoaFisica, UsuarioRespostaDTO>();

        CreateMap<EnderecoCadastroDTO, Endereco>();
        CreateMap<Endereco, EnderecoCadastroDTO>();
        CreateMap<Endereco, EnderecoRespostaDTO>();
        CreateMap<EnderecoRespostaDTO, Endereco>();

        CreateMap<PessoaJuridica, PessoaJuridicaCadastroDTO>();
        CreateMap<PessoaJuridica, PessoaJuridicaAlteracaoDTO>();
        CreateMap<PessoaJuridica, PessoaJuridicaRespostaDTO>();
        CreateMap<PessoaJuridicaCadastroDTO, PessoaJuridica>();
        CreateMap<PessoaJuridicaAlteracaoDTO, PessoaJuridica>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Modulo, ModuloDTO>();
        CreateMap<ModuloDTO, Modulo>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<UsuarioModulo, UsuarioModuloDTO>()
            .ForMember(
                dest => dest.UsuarioId,
                opt => opt.MapFrom(src => src.Usuario.PublicId)
            );

        CreateMap<UsuarioModuloDTO, UsuarioModulo>()
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
