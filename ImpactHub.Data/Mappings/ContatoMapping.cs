using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImpactHub.Data.Mappings
{
    public class ContatoMapping : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {

            builder.HasKey(c => c.IdContato);

            builder.Property(c => c.Ddi)
                .IsRequired()
                .HasColumnType("numeric(3)");

            builder.Property(c => c.Ddd)
               .IsRequired()
               .HasColumnType("numeric(3)");

            builder.Property(c => c.Telefone)
               .IsRequired()
               .HasColumnType("numeric(10)");

            builder.Property(c => c.TipoContato)
               .IsRequired()
               .HasColumnType("varchar(25)");

            builder.Property(c => c.StatusContato)
               .IsRequired()
               .HasColumnType("varchar(25)");

            builder.HasOne(c => c.Cadastro)
                .WithMany(c => c.Contatos)
                .HasForeignKey(c => c.IdCadastro);

            builder.ToTable("TB_IMPACTHUB_CONTATO");
        }
    }
}
