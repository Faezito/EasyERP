using AutoMapper;
using Escolar.Repositorio;
using Escolar.Repositorio.Entidades;
using Model.DTOs.Escolar.Turma;

namespace Escolar.Servicos;

public interface ITurmaServicos : ICRUDGenerico<Turma>
{
    Task Cadastrar(TurmaDTO dto);
    Task Atualizar(TurmaDTO dto);
}

public class TurmaServicos : CRUDGenerico<Turma>, ITurmaServicos
{
    public TurmaServicos(AppDbContext db, IMapper mapper) : base(db, mapper) {}

    public async Task Atualizar(TurmaDTO dto)
    {
        var turma = _mapper.Map<Turma>(dto);
        await AtualizarAsync(turma);
    }

    public async Task Cadastrar(TurmaDTO dto)
    {
        var turma = _mapper.Map<Turma>(dto);
        await AdicionarAsync(turma);
    }
}