using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Usuario.API.Migrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnamnesePergunta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Pergunta = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnamnesePergunta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Sigla = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CREF = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataExcluido = table.Column<DateTime>(type: "datetime", nullable: true),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnamneseResposta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Resposta = table.Column<string>(type: "varchar(250)", nullable: false),
                    AnamnesePerguntaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnamneseResposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnamneseResposta_AnamnesePergunta_AnamnesePerguntaId",
                        column: x => x.AnamnesePerguntaId,
                        principalTable: "AnamnesePergunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(40)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false),
                    EstadoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataExcluido = table.Column<DateTime>(type: "datetime", nullable: true),
                    Excluido = table.Column<bool>(type: "bit", nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    EnderecoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Biometria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    BracoDireito = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BracoEsquerdo = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Torax = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Cintura = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Quadril = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CoxaDireita = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CoxaEsquerda = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GemeoDireito = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GemeoEsquerdo = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    AnteBracoDireito = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    AnteBracoEsquerdo = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataExcluido = table.Column<DateTime>(type: "datetime", nullable: true),
                    Excluido = table.Column<bool>(type: "bit", nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biometria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biometria_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ficha",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Objetivo = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    AlunoId = table.Column<Guid>(nullable: false),
                    AnamneseRespostaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ficha_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ficha_AnamneseResposta_AnamneseRespostaId",
                        column: x => x.AnamneseRespostaId,
                        principalTable: "AnamneseResposta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_EnderecoId",
                table: "Aluno",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_ProfessorId",
                table: "Aluno",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnamneseResposta_AnamnesePerguntaId",
                table: "AnamneseResposta",
                column: "AnamnesePerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Biometria_AlunoId",
                table: "Biometria",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_EstadoId",
                table: "Endereco",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_AlunoId",
                table: "Ficha",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_AnamneseRespostaId",
                table: "Ficha",
                column: "AnamneseRespostaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biometria");

            migrationBuilder.DropTable(
                name: "Ficha");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "AnamneseResposta");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "AnamnesePergunta");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
