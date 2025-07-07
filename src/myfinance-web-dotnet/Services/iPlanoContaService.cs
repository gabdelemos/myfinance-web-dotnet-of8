using System.Collections;
using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Services
{
    public interface iPlanoContaService
    {
        List<PlanoConta> RetornarTotalValoresDePlanosContaMaisUtilizados();
    }
}