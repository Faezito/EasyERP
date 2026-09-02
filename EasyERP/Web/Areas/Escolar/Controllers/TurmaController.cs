using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Escolar.Turma;
using Web.Areas.Escolar.Models.TabelaDinamica;
using Web.Areas.Escolar.Services;
using Web.Libraries.Filtros;
using Web.Models.TabelaDinamica;
using Web.Views.Shared.Components.TabelaDinamica;

namespace Web.Areas.Escolar.Controllers;

[Area("Escolar")]
[Authorize]
[ValidateHttpRefererAttributes]
public class TurmaController(ITurmaServices turmaServices) : Controller
{
    private readonly ITurmaServices _turmaServices = turmaServices;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Listar()
    {
        var turmas = await _turmaServices.Listar();
        var turmasView = TurmaTabela.MapearParaTabela(turmas);

        return ViewComponent(typeof(TabelaDinamica),
                new TabelaDinamicaModel(turmasView,
                    Url.Action(nameof(Edicao)),
                    Url.Action(nameof(Deletar)),
                    true
                )
            );
    }

    [HttpGet]
    public async Task<IActionResult> Obter(int id)
    {
        var turma = await _turmaServices.Obter(id);
        return Ok(turma);
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(TurmaDTO dto)
    {
        await _turmaServices.Cadastrar(dto);
        return Json(new { success = true, pergunta = true, redirectUrl = Url.Action(nameof(Index)) });
    }

    [HttpGet]
    public async Task<IActionResult> Edicao(int id)
    {
        var turma = await _turmaServices.Obter(id);
        return View(turma);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(TurmaDTO dto)
    {
        await _turmaServices.Atualizar(dto);
        return Json(new { success = true, pergunta = true, redirectUrl = Url.Action(nameof(Index)) });
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(int id)
    {
        await _turmaServices.Deletar(id);
        return Json(new { success = true, reloadPage = false });
    }
}
