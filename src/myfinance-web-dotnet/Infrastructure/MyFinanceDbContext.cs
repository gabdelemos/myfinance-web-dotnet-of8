using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Infrastructure
{
    public class MyFinanceDbContext : DbContext
    {

        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<PlanoConta> PlanoConta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=LOCALHOST\SQLEXPRESS;Database=myfinance;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}