using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers;

public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;
    private readonly iPlanoContaService _PlanoContaService;

    public PlanoContaController(ILogger<PlanoContaController> logger, iPlanoContaService PlanoContaService)
    {
        _logger = logger;
        _PlanoContaService = PlanoContaService;
    }

    public IActionResult Index()
    {
        ViewBag.Lista = _PlanoContaService.ListarRegistros();
        return View();
    }

    public IActionResult Cadastro(PlanoContaModel model)
    {
        return View();
    }
}