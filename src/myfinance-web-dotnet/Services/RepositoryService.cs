using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Service
{
    public class RepositoryService<T> : iRepository<T> where T : class
    {

        private readonly MyFinanceDbContext _banco;
        private readonly DbSet<T> _dbSet;

        public RepositoryService(MyFinanceDbContext banco)
        {
            _banco = banco;
            _dbSet = banco.Set<T>();
        }

        public void Excluir(int id)
        {
            var item = RetornarRegistro(id);

            if (item != null)
            {
                _dbSet.Remove(item);
                _banco.SaveChanges();
            }
        }

        public List<T> ListarRegistro()
        {

            if (typeof(T) == typeof(Transacao))
            {
                return _dbSet
                    .Include("PlanoConta")
                    .ToList();
            }

            var item = _dbSet.ToList();
            return item;
        }

        // Implementation for the interface member
        public List<T> ListarRegistros()
        {
            return ListarRegistro();
        }

        public T RetornarRegistro(int id)
        {

            var item = _dbSet.Find(id);
            return item;
        }

        public void Salvar(T registro)
        {

            var entry = _banco.Entry(registro);
            var key = _banco.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.First();

            var id = entry.Property(key.Name).CurrentValue;

            if (id == null)
            {
                _dbSet.Add(registro);

            }
            else
            {
                _dbSet.Attach(registro);
                entry.State = EntityState.Modified;
            }

            _banco.SaveChanges();
        }
    }
}