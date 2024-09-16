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
    public class RelatorioMapping : IEntityTypeConfiguration<RelatorioModel>
    {
        public void Configure(EntityTypeBuilder<RelatorioModel> builder)
        {
            builder.HasKey(r => r.IdRelatorio);

            builder.Property(r => r.Melhorias)
                .IsRequired()
                .HasColumnType("varchar(225)");

            builder.Property(r => r.PontosFaltantesMelhorias)
                .IsRequired()
                .HasColumnType("varchar(225)");

            builder.Property(r => r.StatusRelatorio)
                .IsRequired()
                .HasColumnType("varchar(20)");

            /*
            //EF RELATIONAL
            builder.HasOne(r => r.Login)
                .WithMany(l => l.Relatorios)
                .HasForeignKey(r => r.IdLogin);

            builder.HasOne(r => r.Resultado)
                .WithMany(res => res.Relatorios)
                .HasForeignKey(r => r.IdResultado);
            */

            builder.ToTable("TB_IMPACTHUB_RELATORIO");
        }
    }
}
