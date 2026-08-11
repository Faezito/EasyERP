using AutoMapper;
using Escolar.Repositorio.Entidades;
using Model.DTOs.Endereco;
using Model.DTOs.Escolar.Pessoa;
using Model.DTOs.Escolar.Turma;

namespace Escolar.Servicos.Mapeamento;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pessoa, PessoaCadastroDTO>();
        CreateMap<PessoaCadastroDTO, Pessoa>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));

        CreateMap<Endereco, EnderecoCadastroDTO>();
        CreateMap<EnderecoCadastroDTO, Endereco>();
        CreateMap<Endereco, EnderecoRespostaDTO>();
        CreateMap<EnderecoRespostaDTO, Endereco>();

        CreateMap<Pessoa, PessoaRespostaDTO>();
        CreateMap<PessoaRespostaDTO, Pessoa>();

        CreateMap<Pessoa, PessoaAtualizacaoDTO>();
        CreateMap<PessoaAtualizacaoDTO, Pessoa>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));

        CreateMap<Turma, TurmaDTO>();
        CreateMap<TurmaDTO, Turma>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));
    }
}
