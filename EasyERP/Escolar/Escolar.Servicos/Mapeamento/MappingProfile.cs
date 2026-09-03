using AutoMapper;
using CrossCutting.Model.DTOs.Escolar.Aluno;
using Escolar.Repositorio.Entidades;
using Model.DTOs.Endereco;
using Model.DTOs.Escolar.Disciplina;
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

        CreateMap<Disciplina, DisciplinaCadastroDTO>();
        CreateMap<DisciplinaCadastroDTO, Disciplina>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));

        CreateMap<Disciplina, DisciplinaAtualizacaoDTO>();
        CreateMap<DisciplinaAtualizacaoDTO, Disciplina>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));

        CreateMap<Disciplina, DisciplinaRespostaDTO>();
        CreateMap<DisciplinaRespostaDTO, Disciplina>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));

        CreateMap<Endereco, EnderecoCadastroDTO>();
        CreateMap<EnderecoCadastroDTO, Endereco>();
        CreateMap<Endereco, EnderecoRespostaDTO>();
        CreateMap<EnderecoRespostaDTO, Endereco>();
        CreateMap<Endereco, EnderecoAtualizacaoDTO>();
        CreateMap<EnderecoAtualizacaoDTO, Endereco>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));

        CreateMap<Pessoa, PessoaRespostaDTO>();
        CreateMap<PessoaRespostaDTO, Pessoa>();

        CreateMap<Pessoa, PessoaAtualizacaoDTO>();
        CreateMap<PessoaAtualizacaoDTO, Pessoa>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (srcMember is not string str || !string.IsNullOrWhiteSpace(str))
            ));

        CreateMap<PessoaRespostaDTO, PessoaAtualizacaoDTO>();
        CreateMap<PessoaAtualizacaoDTO, PessoaRespostaDTO>()
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

        CreateMap<Aluno, AlunoRespostaDTO>();
        CreateMap<AlunoCadastroDTO, Aluno>();
        CreateMap<Aluno, AlunoCadastroDTO>();
        CreateMap<AlunoAtualizacaoDTO, Aluno>();
        CreateMap<Aluno, AlunoAtualizacaoDTO>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

    }
}
