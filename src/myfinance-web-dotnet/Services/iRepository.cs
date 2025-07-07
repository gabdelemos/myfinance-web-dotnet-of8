namespace myfinance_web_dotnet.Services
{
    public interface iRepository<T> where T: class
    {
        List<T> ListarRegistros();
        void Salvar(T registro);
        void Excluir(int id);
        T RetornarRegistro(int id);        
    }
}