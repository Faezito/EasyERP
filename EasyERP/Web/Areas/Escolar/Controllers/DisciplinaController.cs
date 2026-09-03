using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Escolar.Disciplina;
using Web.Areas.Escolar.Models.TabelaDinamica;
using Web.Areas.Escolar.Services;
using Web.Extensions;
using Web.Libraries.Filtros;
using Web.Libraries.Validacoes;
using Web.Models.TabelaDinamica;
using Web.Views.Shared.Components.TabelaDinamica;

namespace Web.Areas.Escolar.Controllers;

[Area("Escolar")]
[Authorize]
[ValidateHttpRefererAttributes]
public class DisciplinaController(IDisciplinaServices disciplinaServices) : Controller
{
    private readonly IDisciplinaServices _disciplinaServices = disciplinaServices;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Listar()
    {
        var disciplinas = await _disciplinaServices.Listar(this.User.GetUserEmpresaId());
        var tabela = DisciplinaTabela.MapearParaTabela(disciplinas);

        return ViewComponent(
            typeof(TabelaDinamica),
            new TabelaDinamicaModel(tabela, Url.Action(nameof(Edicao)),
            Url.Action(nameof(Deletar)),
            true)
        );
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(DisciplinaCadastroDTO dto)
    {
        ModelStateHelper.ValidarModelState(ModelState);

        dto.PessoaJuridicaId = this.User.GetUserEmpresaId();
        await _disciplinaServices.Cadastrar(dto);
        return Json(new { success = true, redirectUrl = Url.Action(nameof(Index)) });
    }

    [HttpGet]
    public async Task<IActionResult> Edicao(int id)
    {
        var empresaId = this.User.GetUserEmpresaId();
        var disciplina = await _disciplinaServices.Obter(id);
        if (disciplina.PessoaJuridicaId != empresaId)
            return NotFound();

        return View(disciplina);
    }

    [HttpPost]
    public async Task<IActionResult> Edicao(DisciplinaAtualizacaoDTO dto)
    {
        ModelStateHelper.ValidarModelState(ModelState);

        await _disciplinaServices.Atualizar(dto);
        return Json(new { success = true, pergunta = true, redirectUrl = Url.Action(nameof(Index)) });
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(int id)
    {
        await _disciplinaServices.Deletar(id);
        return Json(new { success = true, reloadPage = false });
    }
}
