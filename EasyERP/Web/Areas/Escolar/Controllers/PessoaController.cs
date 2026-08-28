using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Escolar.Pessoa;
using Web.Areas.Escolar.Services;
using Web.Libraries.Filtros;
using Web.Models.TabelaDinamica;
using Web.Views.Shared.Components.TabelaDinamica;

namespace Web.Areas.Escolar.Controllers;

[Area("Escolar")]
[Authorize]
[ValidateHttpRefererAttributes]
public class PessoaController(IPessoaServices pessoaServices, IMapper mapper) : Controller
{
    private readonly IPessoaServices _pessoaServices = pessoaServices;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Listar()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var token = result?.Properties?.GetTokenValue("access_token");
        
        var pessoas = await _pessoaServices.Listar(token);
        return ViewComponent(typeof(TabelaDinamica), new TabelaDinamicaModel(pessoas, Url.Action(nameof(Edicao)), Url.Action(nameof(Deletar)), true));
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(PessoaCadastroDTO dto)
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var token = result?.Properties?.GetTokenValue("access_token");

        await _pessoaServices.Cadastrar(dto, token);
        return Json(new { success = true });
    }

    [HttpGet]
    public async Task<IActionResult> Edicao(Guid id)
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var token = result?.Properties?.GetTokenValue("access_token");

        var pessoa = await _pessoaServices.Obter(id, token);
        var pessoaEdicao = _mapper.Map<PessoaAtualizacaoDTO>(pessoa);
        return View(pessoaEdicao);
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(Guid id)
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var token = result?.Properties?.GetTokenValue("access_token");

        await _pessoaServices.Deletar(id, token);
        return Json(new { success = true, reloadPage = false });
    }
}