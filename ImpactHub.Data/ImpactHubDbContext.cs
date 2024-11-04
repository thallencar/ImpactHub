using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace ImpactHub.Data
{
    public class ImpactHubDbContext : DbContext
    {
        public ImpactHubDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CadastroModel> Cadastros { get; set; }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ResultadoESGModel> Resultados { get; set; }
        public DbSet<QuestionarioESGModel> Questionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
