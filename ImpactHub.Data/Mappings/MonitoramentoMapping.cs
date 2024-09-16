using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImpactHub.Data.Mappings
{
    public class MonitoramentoMapping : IEntityTypeConfiguration<MonitoramentoModel>
    {
        public void Configure(EntityTypeBuilder<MonitoramentoModel> builder)
        {
            builder.HasKey(m => m.IdMonitoramento);

            builder.Property(m => m.DataValidade)
                .IsRequired();

            builder.Property(m => m.StatusMonitoramento)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(m => m.DescricaoMonitoramento)
                .IsRequired()
                .HasColumnType("varchar(20)");

            /*
            //EF RELATIONAL
            //1..N
            builder.HasOne(m => m.Login)
                .WithMany(l => l.Monitoramentos)
                .HasForeignKey(m => m.IdLogin);

            //1..N
            builder.HasOne(m => m.Resultado)
                .WithMany(l => l.Monitoramentos)
                .HasForeignKey(m => m.IdResultado);
            */

            builder.ToTable("TB_IMPACTHUB_MONITORAMENTO");
        }
    }
}
