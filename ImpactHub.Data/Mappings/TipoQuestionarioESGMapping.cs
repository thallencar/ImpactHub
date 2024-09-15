using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImpactHub.Data.Mappings
{
    internal class TipoQuestionarioESGMapping : IEntityTypeConfiguration<TipoQuestionarioESGModel>
    {
        public void Configure(EntityTypeBuilder<TipoQuestionarioESGModel> builder)
        {
            builder.HasKey(t => t.IdTipoQuestionario);

            builder.Property(t => t.TipoQuestionario)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasColumnType("varchar(80)");

            //EF RELATIONAL
            //1..N
            builder.HasMany(t => t.Questionarios)
                .WithOne(q => q.TipoQuestionario)
                .HasForeignKey(t => t.IdTipoQuestionario);

            builder.ToTable("TB_IMPACTHUB_TIPO_QUESTIONARIO)");

        }
    }
}
