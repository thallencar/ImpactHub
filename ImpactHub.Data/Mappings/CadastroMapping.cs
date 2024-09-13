using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImpactHub.Data.Mappings
{
    public class CadastroMapping : IEntityTypeConfiguration<CadastroModel>
    {
        public void Configure(EntityTypeBuilder<CadastroModel> builder)
        {
            builder.HasKey(c => c.IdCadastro);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(c => c.InscricaoEstadual)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasColumnType("varchar(180)");

            builder.Property(c => c.Porte)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(c => c.InscricaoEstadual)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(c => c.DataAbertura)
                .IsRequired();

            builder.HasMany(c => c.Enderecos)
                .WithOne(e => e.Cadastro)
                .HasForeignKey(e => e.IdCadastro);

            builder.HasMany(c => c.Contatos)
                .WithOne(c => c.Cadastro)
                .HasForeignKey(c => c.IdCadastro);

            builder.HasOne(c => c.Login)
                .WithOne(l => l.Cadastro)
                .HasForeignKey<LoginModel>(l => l.IdCadastro);


            builder.ToTable("TB_IMPACTHUB_CADASTRO");


        }
    }
}
