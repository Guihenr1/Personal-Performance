using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Treino.API.Migrations
{
    public partial class NomeTreino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Treino",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Treino");
        }
    }
}
