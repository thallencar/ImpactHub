using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpactHub.Data.Mappings
{
    public class QuestionarioMapping : IEntityTypeConfiguration<QuestionarioModel>
    {
        public void Configure(EntityTypeBuilder<QuestionarioModel> builder)
        {
            builder.HasKey(q => q.IdQuestionario);

            builder.Property(q => q.DescricaoPergunta)
                .IsRequired()
                .HasColumnType("varchar(225)"); 
            
            builder.Property(q => q.DescricaoResposta)
                .IsRequired()
                .HasColumnType("varchar(225)");

            //EF RELATIONAL
            //1..N
            builder.HasOne(q => q.TipoQuestionario)
                .WithMany(tq => tq.Questionarios)
                .HasForeignKey(q => q.IdTipoQuestionario);

            //1..N
            builder.HasMany(q => q.Resultados)
                .WithOne(r => r.Questionario)
                .HasForeignKey(r => r.IdQuestionario);

            builder.ToTable("TB_IMPACTHUB_QUESTIONARIO");
        }
    }
}
