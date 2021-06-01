using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Mappings
{
    public class FichaMapping : IEntityTypeConfiguration<Ficha> {
        public void Configure(EntityTypeBuilder<Ficha> builder) {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Objetivo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime");

            builder.HasOne(c => c.Aluno)
                .WithMany(a => a.Ficha);

            builder.HasOne(c => c.AnamneseResposta)
                .WithMany(a => a.Ficha);

            builder.ToTable("Ficha");
        }
    }
}