using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PP.Permissao.API.Models.Configuration
{
    public class TipoConfiguration : IEntityTypeConfiguration<Tipo> {
        public void Configure(EntityTypeBuilder<Tipo> builder) {
            builder.HasData
            (
                new Tipo { Id = new Guid("AB4C848B-5E7C-4290-8867-0535ED4F8154"), Descricao = "Menu"},
                new Tipo { Id = new Guid("7FC734E9-266F-4B25-96D2-9371E0F7B2DB"), Descricao = "Sub Menu" }
            );
        }
    }
}