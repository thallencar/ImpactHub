using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace ImpactHub.Data.Contexts
{
    public class ImpactHubDbContext : DbContext
    {
        public ImpactHubDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CadastroModel> Cadastros { get; set; }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<LoginModel> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImpactHubDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
