using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers;

[Route("[controller]")]
public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;
    private readonly iRepository<PlanoConta> _PlanoContaRepository;

    public PlanoContaController(
        ILogger<PlanoContaController> logger,
        iRepository<PlanoConta> PlanoContaService)
    {
        _logger = logger;
        _PlanoContaRepository = PlanoContaService;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        ViewBag.Lista = _PlanoContaRepository.ListarRegistros();
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
            var registro = _PlanoContaRepository.RetornarRegistro((int)id);

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

            _PlanoContaRepository.Salvar(planoConta);

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
        _PlanoContaRepository.Excluir(id);
        return RedirectToAction("Index");
    }
}