using AutoMapper;
using Escolar.Repositorio.Entidades;
using Model.DTOs.Escolar.Pessoa;

namespace Escolar.Servicos.Mapeamento;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pessoa, PessoaCadastroDTO>();
        CreateMap<PessoaCadastroDTO, Pessoa>();

        CreateMap<PessoaAtualizacaoDTO, Pessoa>();
        CreateMap<Pessoa, PessoaAtualizacaoDTO>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
