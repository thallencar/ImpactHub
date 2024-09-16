using ImpactHub.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpactHub.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder.HasKey(e => e.IdEndereco);

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(125)");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(e => e.Complemento)
                .IsRequired(false)
                .HasColumnType("varchar(125)");

            builder.Property(e => e.PontoReferencia)
                .IsRequired(false)
                .HasColumnType("varchar(150)");

            /*
            //EF RELATIONAL
            //1..N
            builder.HasOne(e => e.Cadastro)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.IdCadastro);
            */

            builder.ToTable("TB_IMPACTHUB_ENDERECO");
        }
    }
}
