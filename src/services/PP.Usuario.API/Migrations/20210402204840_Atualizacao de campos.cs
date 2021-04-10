using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Usuario.API.Migrations
{
    public partial class Atualizacaodecampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AntebracoEsquerdo",
                table: "Biometria",
                newName: "AnteBracoEsquerdo");

            migrationBuilder.RenameColumn(
                name: "AntebracoDireito",
                table: "Biometria",
                newName: "AnteBracoDireito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnteBracoEsquerdo",
                table: "Biometria",
                newName: "AntebracoEsquerdo");

            migrationBuilder.RenameColumn(
                name: "AnteBracoDireito",
                table: "Biometria",
                newName: "AntebracoDireito");
        }
    }
}
