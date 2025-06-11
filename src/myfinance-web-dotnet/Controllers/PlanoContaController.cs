using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers;

[Route("[controller]")]
public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;
    private readonly iPlanoContaService _PlanoContaService;

    public PlanoContaController(ILogger<PlanoContaController> logger, iPlanoContaService PlanoContaService)
    {
        _logger = logger;
        _PlanoContaService = PlanoContaService;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        ViewBag.Lista = _PlanoContaService.ListarRegistros();
        return View();
    }

    [HttpPost]
    [HttpGet]

    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(PlanoContaModel? model, int? id)
    {
        if (id != null && !ModelState.IsValid) //Carregar o registro em tela
        {
            var registro = _PlanoContaService.RetornarRegistro((int)id);

            var planoContaModel = new PlanoContaModel()
            {
                Id = registro.Id,
                Nome = registro.Nome,
                Tipo = registro.Tipo
            };

            return View(planoContaModel);
        }
        else if (model != null && ModelState.IsValid)
        {
            var planoConta = new PlanoConta
            {
                Id = model.Id,
                Nome = model.Nome,
                Tipo = model.Tipo
            };

            _PlanoContaService.Salvar(planoConta);

            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _PlanoContaService.Excluir(id);
        return RedirectToAction("Index");
    }
}