using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Mappings
{
    public class BiometriaMapping : IEntityTypeConfiguration<Biometria> {
        public void Configure(EntityTypeBuilder<Biometria> builder) {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Peso)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.Altura)
                .IsRequired()
                .HasColumnType("decimal(3,2)");

            builder.Property(c => c.BracoDireito)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.BracoEsquerdo)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.Torax)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.Cintura)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.Quadril)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.CoxaDireita)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.CoxaEsquerda)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.GemeoDireito)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.GemeoEsquerdo)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.AnteBracoDireito)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.AnteBracoEsquerdo)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime");

            builder.Property(c => c.DataDesativacao)
                .HasColumnName("DataExcluido")
                .HasColumnType("datetime");

            builder.Property(c => c.Desativado)
                .IsRequired()
                .HasColumnName("Excluido")
                .HasColumnType("bit");

            builder.HasOne(c => c.Aluno)
                .WithMany(a => a.Biometria);

            builder.ToTable("Biometria");
        }
    }
}