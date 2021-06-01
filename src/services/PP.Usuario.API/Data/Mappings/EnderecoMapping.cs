using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco> {
        public void Configure(EntityTypeBuilder<Endereco> builder) {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Complemento)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Endereco");
        }
    }
}