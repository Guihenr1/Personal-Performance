using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Treino.API.Migrations
{
    public partial class ExercicioCarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExercicioCarga",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Carga = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    ExercicioTreinoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioCarga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercicioCarga_ExercicioTreino_ExercicioTreinoId",
                        column: x => x.ExercicioTreinoId,
                        principalTable: "ExercicioTreino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioCarga_ExercicioTreinoId",
                table: "ExercicioCarga",
                column: "ExercicioTreinoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercicioCarga");
        }
    }
}
