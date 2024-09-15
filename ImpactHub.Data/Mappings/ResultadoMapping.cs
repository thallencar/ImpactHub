using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImpactHub.Data.Mappings
{
    public class ResultadoMapping : IEntityTypeConfiguration<ResultadoModel>
    {
        public void Configure(EntityTypeBuilder<ResultadoModel> builder)
        {


            builder.HasKey(r => r.IdResultado);

            builder.Property(r => r.PorcentagemCertificado)
                .IsRequired()
                .HasColumnType("varchar(5)");

            builder.Property(r => r.StatusResultado)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(r => r.DataValidade)
                .IsRequired();

            //EF RELATIONAL
            //1..N
            builder.HasOne(r => r.Questionario)
                .WithMany(q => q.Resultados)
                .HasForeignKey(r => r.IdQuestionario);

            //1..N
            builder.HasMany(r => r.Monitoramentos)
                .WithOne(m => m.Resultado)
                .HasForeignKey(m => m.IdResultado);

            //1..N
            builder.HasMany(r => r.Relatorios)
                .WithOne(rel => rel.Resultado)
                .HasForeignKey(r => r.IdResultado);

            //1..N
            builder.HasMany(r => r.Rankings)
                .WithOne(ra => ra.Resultado)
                .HasForeignKey(ra => ra.IdResultado);

            builder.ToTable("TB_IMPACTHUB_RESULTADOS");

        }

    }
}
