namespace myfinance_web_dotnet.Domain;

public class PlanoContaModel
{
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; } // "Receita" ou "Despesa"
}