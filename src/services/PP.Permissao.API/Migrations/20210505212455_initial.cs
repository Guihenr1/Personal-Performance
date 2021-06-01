using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Permissao.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    TipoId = table.Column<Guid>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissao_Tipo_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tipo",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("ab4c848b-5e7c-4290-8867-0535ed4f8154"), "Menu" });

            migrationBuilder.InsertData(
                table: "Tipo",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("7fc734e9-266f-4b25-96d2-9371e0f7b2db"), "Sub Menu" });

            migrationBuilder.CreateIndex(
                name: "IDX_Tipo",
                table: "Permissao",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Tipo");
        }
    }
}
