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
                new Estado { Id = new Guid("33E807CB-419D-4115-9988-B2AA187495FC"), Nome = "São Paulo", Sigla = "SP"},
                new Estado { Id = new Guid("DEFC1B08-DE90-4AB5-AE61-7E519D8FCDF3"), Nome = "Acre", Sigla = "AC" },
                new Estado { Id = new Guid("274200E1-9A6A-44F4-9388-A2EC36B331BB"), Nome = "Alagoas", Sigla = "AL" },
                new Estado { Id = new Guid("640970CE-E1F1-4314-A9DF-47C76A2D67FE"), Nome = "Amapá", Sigla = "AP" },
                new Estado { Id = new Guid("28BAB9E4-ED5F-4325-B9A2-10C3CC242FC2"), Nome = "Amazonas", Sigla = "AM" },
                new Estado { Id = new Guid("C2ACEDC2-A3CF-4695-A8F1-2A7A93D94E1A"), Nome = "Bahia", Sigla = "BA" },
                new Estado { Id = new Guid("CC9A0907-716A-46B4-8AE8-FA26C03091D9"), Nome = "Ceará", Sigla = "CE" },
                new Estado { Id = new Guid("349160B8-B41D-4E6A-80FE-1AB627485F4E"), Nome = "Distrito Federal", Sigla = "DF" },
                new Estado { Id = new Guid("FF6EE140-ECE6-455B-8B52-F75CE5824A96"), Nome = "Espírito Santo", Sigla = "ES" },
                new Estado { Id = new Guid("DF0B7049-617C-446F-A8A3-A042378784E5"), Nome = "Goiás", Sigla = "GO" },
                new Estado { Id = new Guid("11B40F14-51D5-4DA3-A295-7DB3D129AC20"), Nome = "Maranhão", Sigla = "MA" },
                new Estado { Id = new Guid("3A4A0780-4EAE-4B1A-B107-685F3AA8A13F"), Nome = "Minas Gerais", Sigla = "MG" },
                new Estado { Id = new Guid("EF74F3F6-EF3B-4EF2-9453-396D73B0891B"), Nome = "Mato Grosso do Sul", Sigla = "MS" },
                new Estado { Id = new Guid("CDFD6952-C90D-4F15-886F-611B89B6685A"), Nome = "Mato Grosso", Sigla = "MT" },
                new Estado { Id = new Guid("E92357F8-6E1C-4EAD-807D-E3EEBFFED9C0"), Nome = "Pará", Sigla = "PA" },
                new Estado { Id = new Guid("78D792D2-3E1F-4CCE-849F-5F9BF91F53C6"), Nome = "Paraíba", Sigla = "PB" },
                new Estado { Id = new Guid("3B74BEDE-7AA4-4292-9746-4B580440594E"), Nome = "Pernambuco", Sigla = "PE" },
                new Estado { Id = new Guid("CCBD97AE-6612-4D4C-9F04-7B96F5FCE185"), Nome = "Piauí", Sigla = "PI" },
                new Estado { Id = new Guid("78564EB0-68E2-4E45-86BC-99915C383AFC"), Nome = "Paraná", Sigla = "PR" },
                new Estado { Id = new Guid("99DB698A-7F61-4F10-9451-80904AA5CCE2"), Nome = "Rio de Janeiro", Sigla = "RJ" },
                new Estado { Id = new Guid("351834E9-B5F4-4185-BC1C-BA8B23161DED"), Nome = "Rio Grande do Norte", Sigla = "RN" },
                new Estado { Id = new Guid("24031933-D6E0-4922-8F3E-0B3C30324593"), Nome = "Rondônia", Sigla = "RO" },
                new Estado { Id = new Guid("6734EEC6-6AB0-4542-B4C0-A2AE82B3681E"), Nome = "Roraima", Sigla = "RR" },
                new Estado { Id = new Guid("DA74E75C-B523-46C2-BC69-BC3576CC1830"), Nome = "Rio Grande do Sul", Sigla = "RS" },
                new Estado { Id = new Guid("9ABE7DA8-D0C8-4D27-B434-B3F10B03E1DF"), Nome = "Santa Catarina", Sigla = "SC" },
                new Estado { Id = new Guid("FF3DF197-252C-424A-83AC-7FA5E059F2CC"), Nome = "Sergipe", Sigla = "SE" },
                new Estado { Id = new Guid("E5C4B9BD-812D-480F-B1FF-70FBCB0925ED"), Nome = "Tocantins", Sigla = "TO" }
            );
        }
    }
}