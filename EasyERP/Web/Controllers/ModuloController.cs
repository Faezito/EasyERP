using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.DTOs.Usuario;
using Web.Libraries.Filtros;
using Web.Libraries.Validacoes;
using Web.Models.TabelaDinamica;
using Web.Services;
using Web.Views.Shared.Components.TabelaDinamica;

namespace Web.Controllers;

[Authorize(Roles = "AdministradorDoSistema")]
[ValidateHttpRefererAttributes]
public class ModuloController(IModuloServices moduloServices) : Controller
{
    private readonly IModuloServices _moduloServices = moduloServices;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Listar()
    {
        var ret = await _moduloServices.Listar();
        var modulos = ModuloTabela.MapearParaTabela(ret);

        return ViewComponent(
            typeof(TabelaDinamica),
            new TabelaDinamicaModel(modulos, Url.Action(nameof(Edicao)),
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
    public async Task<IActionResult> Cadastrar(ModuloCadastroDTO dto)
    {
        ModelStateHelper.ValidarModelState(ModelState);

        await _moduloServices.Cadastrar(dto);
        return Json(new { success = true, redirectUrl = Url.Action(nameof(Index)) });
    }

    [HttpGet]
    public async Task<IActionResult> Edicao(int id)
    {
        var modulo = await _moduloServices.Obter(id);
        return View(modulo);
    }

    [HttpPost]
    public async Task<IActionResult> Edicao(ModuloDTO dto)
    {
        ModelStateHelper.ValidarModelState(ModelState);

        await _moduloServices.Atualizar(dto);
        return Json(new { success = true, pergunta = true, redirectUrl = Url.Action(nameof(Index)) });
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(int id)
    {
        await _moduloServices.Deletar(id);
        return Json(new { success = true, reloadPage = false });
    }
}
