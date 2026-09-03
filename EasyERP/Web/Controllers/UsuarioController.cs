using CrossCutting.Model.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.DTOs.Usuario;
using Web.Extensions;
using Web.Libraries.Filtros;
using Web.Libraries.Validacoes;
using Web.Models.TabelaDinamica;
using Web.Services;
using Web.Views.Shared.Components.TabelaDinamica;

namespace Web.Controllers;

[Authorize(Roles = "AdministradorDoSistema")]
[ValidateHttpRefererAttributes]
public class UsuarioController(IUsuarioServices usuarioServices, IModuloServices moduloServices) : Controller
{
    private readonly IUsuarioServices _usuarioServices = usuarioServices;
    private readonly IModuloServices _moduloServices = moduloServices;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Listar()
    {
        var usuarios = await _usuarioServices.Listar();
        var tabela = UsuarioTabela.MapearParaTabela(usuarios);

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
    public async Task<IActionResult> Cadastrar(UsuarioCadastroDTO dto)
    {
        ModelStateHelper.ValidarModelState(ModelState);

        await _usuarioServices.Cadastrar(dto);
        return Json(new { success = true, pergunta = true, redirectUrl = Url.Action(nameof(Index)) });
    }

    [HttpGet]
    public async Task<IActionResult> Edicao(Guid id)
    {
        var usuario = await _usuarioServices.Obter(id);
        var modulos = new List<ModuloDTO>();
        if (this.User.GetUserTipo() == "AdministradorDoSistema")
            modulos = await _moduloServices.Listar();
        else
            modulos = this.User.ObterModulosDoUsuario();

        var modulosDoUsuario = usuario.Modulos.Select(m => m.ModuloId).ToList();

        ViewBag.Modulos = modulos;
        return View(new UsuarioAtualizacaoDTO
        {
            Modulos = modulosDoUsuario,
            PublicId = usuario.PublicId,
            Perfil = usuario.Perfil
        });
    }

    [HttpPost]
    public async Task<IActionResult> Editar(UsuarioAtualizacaoDTO dto)
    {
        ModelStateHelper.ValidarModelState(ModelState);

        await _usuarioServices.Atualizar(dto);
        return Json(new { success = true, pergunta = true, redirectUrl = Url.Action(nameof(Index)) });
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(Guid id)
    {
        await _usuarioServices.Deletar(id);
        return Json(new { success = true, reloadPage = false });
    }

}
