using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyFinanceDbContext _banco;

    public HomeController(ILogger<HomeController> logger, MyFinanceDbContext banco)
    {
        _logger = logger;
        _banco = banco;
    }

    public IActionResult Index()
    {
        var nomePrimeiroItemPlanoConta = _banco.PlanoConta.FirstOrDefault().Nome;
        ViewBag.Teste = nomePrimeiroItemPlanoConta;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
