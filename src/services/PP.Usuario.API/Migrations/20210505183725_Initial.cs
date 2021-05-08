using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Usuario.API.Migrations
{
    public partial class Initial : Migration
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

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[,]
                {
                    { new Guid("33e807cb-419d-4115-9988-b2aa187495fc"), "São Paulo", "SP" },
                    { new Guid("9abe7da8-d0c8-4d27-b434-b3f10b03e1df"), "Santa Catarina", "SC" },
                    { new Guid("da74e75c-b523-46c2-bc69-bc3576cc1830"), "Rio Grande do Sul", "RS" },
                    { new Guid("6734eec6-6ab0-4542-b4c0-a2ae82b3681e"), "Roraima", "RR" },
                    { new Guid("24031933-d6e0-4922-8f3e-0b3c30324593"), "Rondônia", "RO" },
                    { new Guid("351834e9-b5f4-4185-bc1c-ba8b23161ded"), "Rio Grande do Norte", "RN" },
                    { new Guid("99db698a-7f61-4f10-9451-80904aa5cce2"), "Rio de Janeiro", "RJ" },
                    { new Guid("78564eb0-68e2-4e45-86bc-99915c383afc"), "Paraná", "PR" },
                    { new Guid("ccbd97ae-6612-4d4c-9f04-7b96f5fce185"), "Piauí", "PI" },
                    { new Guid("3b74bede-7aa4-4292-9746-4b580440594e"), "Pernambuco", "PE" },
                    { new Guid("78d792d2-3e1f-4cce-849f-5f9bf91f53c6"), "Paraíba", "PB" },
                    { new Guid("e92357f8-6e1c-4ead-807d-e3eebffed9c0"), "Pará", "PA" },
                    { new Guid("cdfd6952-c90d-4f15-886f-611b89b6685a"), "Mato Grosso", "MT" },
                    { new Guid("ef74f3f6-ef3b-4ef2-9453-396d73b0891b"), "Mato Grosso do Sul", "MS" },
                    { new Guid("3a4a0780-4eae-4b1a-b107-685f3aa8a13f"), "Minas Gerais", "MG" },
                    { new Guid("11b40f14-51d5-4da3-a295-7db3d129ac20"), "Maranhão", "MA" },
                    { new Guid("df0b7049-617c-446f-a8a3-a042378784e5"), "Goiás", "GO" },
                    { new Guid("ff6ee140-ece6-455b-8b52-f75ce5824a96"), "Espírito Santo", "ES" },
                    { new Guid("349160b8-b41d-4e6a-80fe-1ab627485f4e"), "Distrito Federal", "DF" },
                    { new Guid("cc9a0907-716a-46b4-8ae8-fa26c03091d9"), "Ceará", "CE" },
                    { new Guid("c2acedc2-a3cf-4695-a8f1-2a7a93d94e1a"), "Bahia", "BA" },
                    { new Guid("640970ce-e1f1-4314-a9df-47c76a2d67fe"), "Amapá", "AP" },
                    { new Guid("274200e1-9a6a-44f4-9388-a2ec36b331bb"), "Alagoas", "AL" },
                    { new Guid("defc1b08-de90-4ab5-ae61-7e519d8fcdf3"), "Acre", "AC" },
                    { new Guid("ff3df197-252c-424a-83ac-7fa5e059f2cc"), "Sergipe", "SE" },
                    { new Guid("e5c4b9bd-812d-480f-b1ff-70fbcb0925ed"), "Tocantins", "TO" }
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
