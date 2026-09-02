using AutoMapper;
using CrossCutting.Model.DTOs.Escolar.Aluno;
using Model.DTOs.Endereco;
using Model.DTOs.Escolar.Pessoa;
using Web.Libraries.Sessao;

namespace Web.Libraries.Mapeamento;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PessoaRespostaDTO, PessoaAtualizacaoDTO>();
        CreateMap<PessoaAtualizacaoDTO, PessoaRespostaDTO>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<PessoaRespostaDTO, PessoaAtualizacaoDTO>();
        CreateMap<PessoaAtualizacaoDTO, PessoaRespostaDTO>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));

        CreateMap<EnderecoRespostaDTO, EnderecoCadastroDTO>();
        CreateMap<EnderecoCadastroDTO, EnderecoRespostaDTO>();
        CreateMap<EnderecoRespostaDTO, EnderecoAtualizacaoDTO>();
        CreateMap<EnderecoAtualizacaoDTO, EnderecoRespostaDTO>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));


        CreateMap<AlunoRespostaDTO, AlunoAtualizacaoDTO>();
        CreateMap<AlunoAtualizacaoDTO, AlunoRespostaDTO>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
