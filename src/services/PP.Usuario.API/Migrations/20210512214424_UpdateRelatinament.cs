using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Usuario.API.Migrations
{
    public partial class UpdateRelatinament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Aluno_EnderecoId",
                table: "Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_EnderecoId",
                table: "Aluno",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Aluno_EnderecoId",
                table: "Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_EnderecoId",
                table: "Aluno",
                column: "EnderecoId",
                unique: true);
        }
    }
}
