using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Domain;

public class TransacaoModel
{
    public TransacaoModel(iRepository<PlanoConta> _PlanoContaRepository)
    {
        var listaPlanoConta = _PlanoContaRepository.ListarRegistros();
        PlanoConta = new SelectList(listaPlanoConta, "Id", "Nome");

        Data = DateTime.Now;
    }
    public int? Id { get; set; }
    public string? Historico { get; set; }
    public string? Tipo { get; set; }
    public DateTime Data { get; set; }
    public int PlanoContaId { get; set; }
    public IEnumerable<SelectListItem>? PlanoConta { get; set; }
    public decimal Valor { get; set; }
}