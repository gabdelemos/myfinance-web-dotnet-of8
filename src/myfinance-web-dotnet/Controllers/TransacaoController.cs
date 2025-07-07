using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers;

[Route("[controller]")]
public class TransacaoController : Controller
{
    private readonly ILogger<TransacaoController> _logger;
    private readonly iRepository<PlanoConta> _PlanoContaRepository;
    private readonly iRepository<Transacao> _TransacaoRepository;

    public TransacaoController(
        ILogger<TransacaoController> logger,
        iRepository<PlanoConta> PlanoContaRepository,
        iRepository<Transacao> TransacaoRepository)
    {
        _logger = logger;
        _PlanoContaRepository = PlanoContaRepository;
        _TransacaoRepository = TransacaoRepository;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        ViewBag.Lista = _TransacaoRepository.ListarRegistros();
        return View();
    }

    [HttpGet("Cadastro")]
    public IActionResult Cadastro()
    {
        var transacaoModel = new TransacaoModel(_PlanoContaRepository);
        return View(transacaoModel);        
    }

    [HttpGet("Cadastro/{id}")]
    public IActionResult Cadastro(int id)
    {
        var registro = _TransacaoRepository.RetornarRegistro(id);

        var transacaoModel = new TransacaoModel(_PlanoContaRepository)
        {
            Id = registro.Id,
            Historico = registro.Historico,
            Tipo = registro.PlanoConta.Tipo,
            Data = registro.Data,
            Valor = registro.Valor,
            PlanoContaId = registro.PlanoContaId,
        };

        return View(transacaoModel);
    }


    [HttpPost("Cadastro")]
    [HttpPost("Cadastro/{id}")]
    public IActionResult Cadastro(TransacaoModel? model, int? id)
    {
        if (ModelState.IsValid)
        {
            var transacao = new Transacao
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId
            };

            _TransacaoRepository.Salvar(transacao);
        }
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _TransacaoRepository.Excluir(id);
        return RedirectToAction("Index");
    }
}