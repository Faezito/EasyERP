using AutoMapper;
using Model.DTOs.Escolar.Pessoa;

namespace Web.Libraries.Mapeamento;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PessoaRespostaDTO, PessoaAtualizacaoDTO>();
        CreateMap<PessoaAtualizacaoDTO, PessoaRespostaDTO>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
