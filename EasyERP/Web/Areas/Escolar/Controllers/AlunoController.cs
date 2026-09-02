using AutoMapper;
using CrossCutting.Model.DTOs.Escolar.Aluno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.DTOs.Escolar.Pessoa;
using Web.Areas.Escolar.Services;
using Web.Libraries.Filtros;
using Web.Libraries.Http;
using Web.Libraries.Validacoes;
using Web.Models.TabelaDinamica;
using Web.Views.Shared.Components.TabelaDinamica;

namespace Web.Areas.Escolar.Controllers;

[Area("Escolar")]
[Authorize]
[ValidateHttpRefererAttributes]
public class AlunoController(IAlunoServices alunoServices, ITurmaServices turmaServices, IMapper mapper) : Controller
{
    private readonly IAlunoServices _alunoServices = alunoServices;
    private readonly ITurmaServices _turmaServices = turmaServices;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Listar()
    {
        var token = await HttpContext.GetJwtAsync();

        var alunos = await _alunoServices.Listar(token);
        return ViewComponent(typeof(TabelaDinamica), new TabelaDinamicaModel(alunos, Url.Action(nameof(Edicao)), Url.Action(nameof(Deletar)), true));
    }

    [HttpGet]
    public async Task<IActionResult> Cadastro()
    {
        var turmas = await _turmaServices.Listar();
        var dropdown = new List<SelectListItem>();

        foreach(var turma in turmas)
        {
            dropdown.Add(new SelectListItem
            {
                Text = turma.Descricao,
                Value = turma.Id.ToString()
            });   
        };

        ViewBag.Turmas = dropdown;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(AlunoCadastroDTO dto)
    {
        ModelStateHelper.ValidarModelState(ModelState);

        var token = await HttpContext.GetJwtAsync();

        await _alunoServices.Cadastrar(dto, token);
        return Json(new { success = true });
    }

    [HttpGet]
    public async Task<IActionResult> Edicao(Guid id)
    {
        var token = await HttpContext.GetJwtAsync();

        var aluno = await _alunoServices.Obter(id, token);
        var alunoEdicao = _mapper.Map<AlunoAtualizacaoDTO>(aluno);

        var turmas = await _turmaServices.Listar();
        var dropdown = new List<SelectListItem>();

        foreach (var turma in turmas)
        {
            dropdown.Add(new SelectListItem
            {
                Text = turma.Descricao,
                Value = turma.Id.ToString()
            });
        };

        ViewBag.Turmas = dropdown;
        return View(alunoEdicao);
    }

    [HttpPost]
    public async Task<IActionResult> Edicao(AlunoAtualizacaoDTO dto)
    {
        ModelStateHelper.ValidarModelState(ModelState);

        var token = await HttpContext.GetJwtAsync();
        await _alunoServices.Atualizar(dto, token);

        return Json( new { success = true, pergunta = true, redirectUrl = Url.Action(nameof(Index)) } );
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(Guid id)
    {
        var token = await HttpContext.GetJwtAsync();

        await _alunoServices.Deletar(id, token);
        return Json(new { success = true, reloadPage = false });
    }
}