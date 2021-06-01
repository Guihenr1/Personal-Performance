using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Treino.API.Migrations
{
    public partial class Treino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repeticao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repeticao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treino",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExercicioTreino",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExercicioId = table.Column<Guid>(nullable: false),
                    TreinoId = table.Column<Guid>(nullable: false),
                    RepeticaoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioTreino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercicioTreino_Exercicio_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercicioTreino_Repeticao_RepeticaoId",
                        column: x => x.RepeticaoId,
                        principalTable: "Repeticao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercicioTreino_Treino_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "Treino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioTreino_ExercicioId",
                table: "ExercicioTreino",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioTreino_RepeticaoId",
                table: "ExercicioTreino",
                column: "RepeticaoId");

            migrationBuilder.CreateIndex(
                name: "IDX_Treino",
                table: "ExercicioTreino",
                column: "TreinoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercicioTreino");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "Repeticao");

            migrationBuilder.DropTable(
                name: "Treino");
        }
    }
}
