using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Services
{
    public interface iTransacaoService
    {
        List<PlanoConta> RetornarTransacaoMaisCaraDoAno(int Ano);
        
    }
}