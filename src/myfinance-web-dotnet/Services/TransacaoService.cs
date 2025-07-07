using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;

namespace myfinance_web_dotnet.Services
{
    public class TransacaoService : iTransacaoService
    {
        private readonly MyFinanceDbContext _banco;
        public TransacaoService(MyFinanceDbContext banco)
        {
            _banco = banco;
        }

        public List<PlanoConta> RetornarTransacaoMaisCaraDoAno(int Ano)
        {
            throw new NotImplementedException();
        }
    }   
}