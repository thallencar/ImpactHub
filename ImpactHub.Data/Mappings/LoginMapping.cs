using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImpactHub.Data.Mappings
{
    public class LoginMapping : IEntityTypeConfiguration<LoginModel>
    {
        public void Configure(EntityTypeBuilder<LoginModel> builder)
        {
            builder.HasKey(l => l.IdLogin);

            builder.Property(l => l.NomeUsuario)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.Property(l => l.Senha)
                .IsRequired()
                .HasColumnType("varchar(16)");

            builder.Property(l => l.StatusLogin)
                .IsRequired()
                .HasColumnType("varchar(20)");

            /*
            //EF RELATIONAL
            //1..N
            builder.HasMany(l => l.Monitoramentos)
                .WithOne(m => m.Login)
                .HasForeignKey(m => m.IdLogin);

            //1..N
            builder.HasMany(l => l.Relatorios)
                .WithOne(r => r.Login)
                .HasForeignKey(r => r.IdLogin);
            */

            builder.ToTable("TB_IMPACTHUB_LOGIN");
        }
    }
}
