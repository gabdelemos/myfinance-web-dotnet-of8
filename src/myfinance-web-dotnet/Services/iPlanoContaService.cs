using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Services
{
    public interface iPlanoContaService
    {
        List<PlanoConta> ListarRegistros();
        void Salvar(PlanoConta registro);
        void Excluir(int id);
        PlanoConta RetornarRegistro(int id);
        
    }
}