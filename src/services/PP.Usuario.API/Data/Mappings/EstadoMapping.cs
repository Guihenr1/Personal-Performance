using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Mappings
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado> {
        public void Configure(EntityTypeBuilder<Estado> builder) {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Sigla)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.ToTable("Estado");
        }
    }
}