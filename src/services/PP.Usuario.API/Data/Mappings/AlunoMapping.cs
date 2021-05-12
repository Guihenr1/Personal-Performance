using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Core.DomainObjects;

namespace PP.Usuario.API.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Models.Aluno> {
        public void Configure(EntityTypeBuilder<Models.Aluno> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.OwnsOne(c => c.Email, tf => {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime");

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

            builder.HasOne(c => c.Professor)
                .WithMany(a => a.Aluno);

            builder.ToTable("Aluno");
        }
    }
}