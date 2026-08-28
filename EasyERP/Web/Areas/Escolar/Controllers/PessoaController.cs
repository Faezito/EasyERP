using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        var pessoas = await _pessoaServices.Listar();
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
        ModelStateHelper.ValidarModelState(ModelState);

        await _pessoaServices.Cadastrar(dto);
        return Json(new { success = true });
    }

    [HttpGet]
    public async Task<IActionResult> Edicao(Guid id)
    {
        var pessoa = await _pessoaServices.Obter(id);
        var pessoaEdicao = _mapper.Map<PessoaAtualizacaoDTO>(pessoa);
        return View(pessoaEdicao);
    }

    [HttpPost]
    public async Task<IActionResult> Edicao(PessoaAtualizacaoDTO dto)
    {
        ModelStateHelper.ValidarModelState(ModelState);
        await _pessoaServices.Atualizar(dto);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(Guid id)
    {
        await _pessoaServices.Deletar(id);
        return Json(new { success = true, reloadPage = false });
    }
}