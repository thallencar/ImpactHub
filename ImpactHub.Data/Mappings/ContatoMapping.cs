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
                .HasMaxLength(3);

            builder.Property(c => c.Ddd)
               .IsRequired()
               .HasMaxLength(3);

            builder.Property(c => c.Telefone)
               .IsRequired()
               .HasMaxLength(10);

            builder.Property(c => c.TipoContato)
                .IsRequired()
                .HasColumnType("varchar(25)");

            builder.Property(c => c.StatusContato)
                .IsRequired()
                .HasColumnType("varchar(25)");

            /*
            //EF RELATIONAL
            //1..N
            builder.HasOne(c => c.Cadastro)
                .WithMany(c => c.Contatos)
                .HasForeignKey(c => c.IdCadastro);
            */

            builder.ToTable("TB_IMPACTHUB_CONTATO");
        }
    }
}
