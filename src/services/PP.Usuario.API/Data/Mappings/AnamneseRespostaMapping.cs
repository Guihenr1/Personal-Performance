using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PP.Usuario.API.Models;

namespace PP.Usuario.API.Data.Mappings
{
    public class AnamneseRespostaMapping : IEntityTypeConfiguration<AnamneseResposta> {
        public void Configure(EntityTypeBuilder<AnamneseResposta> builder) {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Resposta)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasOne(ar => ar.AnamnesePergunta)
                .WithMany(ap => ap.AnamneseResposta);

            builder.ToTable("AnamneseResposta");
        }
    }
}