using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PP.Usuario.API.Models.Configuration
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado> {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasData
            (
                new Estado {Id = Guid.NewGuid(), Nome = "São Paulo", Sigla = "SP"},
                new Estado { Id = Guid.NewGuid(), Nome = "Acre", Sigla = "AC" },
                new Estado { Id = Guid.NewGuid(), Nome = "Alagoas", Sigla = "AL" },
                new Estado { Id = Guid.NewGuid(), Nome = "Amapá", Sigla = "AP" },
                new Estado { Id = Guid.NewGuid(), Nome = "Bahia", Sigla = "BA" },
                new Estado { Id = Guid.NewGuid(), Nome = "Ceará", Sigla = "CE" },
                new Estado { Id = Guid.NewGuid(), Nome = "Distrito Federal", Sigla = "DF" },
                new Estado { Id = Guid.NewGuid(), Nome = "Espírito Santo", Sigla = "ES" },
                new Estado { Id = Guid.NewGuid(), Nome = "Goiás", Sigla = "GO" },
                new Estado { Id = Guid.NewGuid(), Nome = "Maranhão", Sigla = "MA" },
                new Estado { Id = Guid.NewGuid(), Nome = "Minas Gerais", Sigla = "MG" },
                new Estado { Id = Guid.NewGuid(), Nome = "Mato Grosso do Sul", Sigla = "MS" },
                new Estado { Id = Guid.NewGuid(), Nome = "Mato Grosso", Sigla = "MT" },
                new Estado { Id = Guid.NewGuid(), Nome = "Pará", Sigla = "PA" },
                new Estado { Id = Guid.NewGuid(), Nome = "Paraíba", Sigla = "PB" },
                new Estado { Id = Guid.NewGuid(), Nome = "Pernambuco", Sigla = "PE" },
                new Estado { Id = Guid.NewGuid(), Nome = "Piauí", Sigla = "PI" },
                new Estado { Id = Guid.NewGuid(), Nome = "Paraná", Sigla = "PR" },
                new Estado { Id = Guid.NewGuid(), Nome = "Rio de Janeiro", Sigla = "RJ" },
                new Estado { Id = Guid.NewGuid(), Nome = "Rio Grande do Norte", Sigla = "RN" },
                new Estado { Id = Guid.NewGuid(), Nome = "Rondônia", Sigla = "RO" },
                new Estado { Id = Guid.NewGuid(), Nome = "Roraima", Sigla = "RR" },
                new Estado { Id = Guid.NewGuid(), Nome = "Rio Grande do Sul", Sigla = "RS" },
                new Estado { Id = Guid.NewGuid(), Nome = "Santa Catarina", Sigla = "SC" },
                new Estado { Id = Guid.NewGuid(), Nome = "Sergipe", Sigla = "SE" },
                new Estado { Id = Guid.NewGuid(), Nome = "Tocantins", Sigla = "TO" }
            );
        }
    }
}