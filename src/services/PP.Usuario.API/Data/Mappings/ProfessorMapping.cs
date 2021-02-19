using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Core.DomainObjects;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Mappings
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor> {
        public void Configure(EntityTypeBuilder<Professor> builder) {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.CREF)
                .IsRequired()
                .HasColumnType("int");

            builder.OwnsOne(c => c.Email, tf => {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime");

            builder.Property(c => c.DataExcluido)
                .HasColumnName("DataExcluido")
                .HasColumnType("datetime");

            builder.Property(c => c.Excluido)
                .IsRequired()
                .HasColumnName("Excluido")
                .HasColumnType("bit");

            builder.ToTable("Professor");
        }
    }
}