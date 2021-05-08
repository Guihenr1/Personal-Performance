using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Usuario.API.Migrations
{
    public partial class configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[] { new Guid("28bab9e4-ed5f-4325-b9a2-10c3cc242fc2"), "Amazonas", "AM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: new Guid("28bab9e4-ed5f-4325-b9a2-10c3cc242fc2"));
        }
    }
}
