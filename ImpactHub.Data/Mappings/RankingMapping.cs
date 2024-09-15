using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImpactHub.Data.Mappings
{
    public class RankingMapping : IEntityTypeConfiguration<RankingModel>
    {
        public void Configure(EntityTypeBuilder<RankingModel> builder)
        {
            builder.HasKey(r => r.IdResultado);

            builder.Property(r => r.Posicao)
                .IsRequired();

            //EF RELATIONAL
            //1..N
            builder.HasOne(r => r.Resultado)
                .WithMany(res => res.Rankings)
                .HasForeignKey(r => r.IdRanking);

            builder.ToTable("TB_IMPACTHUB_RANKINGS");
        }
    }
}
