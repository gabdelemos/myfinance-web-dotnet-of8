using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;

namespace myfinance_web_dotnet.Services
{
    public class PlanoContaService : iPlanoContaService
    {
        private readonly MyFinanceDbContext _banco;
        public PlanoContaService(MyFinanceDbContext banco)
        {
            _banco = banco;
        }

        public List<PlanoConta> RetornarTotalValoresDePlanosContaMaisUtilizados()
        {
            throw new NotImplementedException();
        }
    }   
}