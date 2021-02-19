using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Mappings
{
    public class AnamnesePerguntaMapping : IEntityTypeConfiguration<AnamnesePergunta> {
        public void Configure(EntityTypeBuilder<AnamnesePergunta> builder) {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Pergunta)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.ToTable("AnamnesePergunta");
        }
    }
}