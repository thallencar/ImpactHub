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

            builder.ToTable("TB_IMPACTHUB_LOGIN");
        }
    }
}
