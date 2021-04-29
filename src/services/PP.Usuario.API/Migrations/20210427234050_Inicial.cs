using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PP.Usuario.API.Migrations
{
    public partial class Inicial : Migration
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
                    { new Guid("d443b958-60e9-481d-b780-ee0a827edbbb"), "São Paulo", "SP" },
                    { new Guid("6c59dab6-6c65-46db-985c-e15ad133584d"), "Alagoas", "AL" },
                    { new Guid("f05df1c4-7fde-4ce4-b6d3-20bbe2d271b2"), "Amapá", "AP" },
                    { new Guid("006dfedb-59bf-480b-a729-df147a6b0140"), "Bahia", "BA" },
                    { new Guid("ac617728-b7b3-4eaa-bdce-a816bbbdfe92"), "Ceará", "CE" },
                    { new Guid("62773405-ec05-44d4-810c-52f5f58b3930"), "Distrito Federal", "DF" },
                    { new Guid("608a5fc2-eb33-4037-8a3d-33d59f3328df"), "Espírito Santo", "ES" },
                    { new Guid("d953f227-b883-404d-91e4-98f6fbc67cba"), "Goiás", "GO" },
                    { new Guid("d5678d4b-990d-4462-b986-3a29e4932148"), "Maranhão", "MA" },
                    { new Guid("d0832955-b958-47c0-b012-d0f4a5adb869"), "Minas Gerais", "MG" },
                    { new Guid("dbb47c1e-134a-40b4-9024-b0fe681a60bb"), "Mato Grosso do Sul", "MS" },
                    { new Guid("9a5a2382-72fd-4ee6-a0ca-e6d36e3adf39"), "Acre", "AC" },
                    { new Guid("bc396fca-d789-4d45-865c-3e5954b133bf"), "Mato Grosso", "MT" },
                    { new Guid("53137975-837c-42be-85fe-760c7e2f7dbf"), "Paraíba", "PB" },
                    { new Guid("b1e11699-ff52-42e8-a42c-99f3cce4248e"), "Pernambuco", "PE" },
                    { new Guid("88323fe1-5911-4dcb-bf6e-d6346e06d3fe"), "Piauí", "PI" },
                    { new Guid("fae35688-406c-4f8a-8adf-cc6c3eeabaf2"), "Paraná", "PR" },
                    { new Guid("2e96c9b9-2833-4af6-b846-a5ba6756b8ef"), "Rio de Janeiro", "RJ" },
                    { new Guid("cd965545-1174-436f-82a7-2988ae0b96c9"), "Rio Grande do Norte", "RN" },
                    { new Guid("d14c3217-6db4-4539-b41a-534eb29d57e6"), "Rondônia", "RO" },
                    { new Guid("4ecbff61-4990-4ff7-b12c-c95fe3ba64f3"), "Roraima", "RR" },
                    { new Guid("4633fbbb-4386-4890-9d83-39af790bc946"), "Rio Grande do Sul", "RS" },
                    { new Guid("f174fba6-bafc-42fe-8e78-02e05cb77c6b"), "Santa Catarina", "SC" },
                    { new Guid("25617d1e-40ad-4987-8845-67b412778392"), "Pará", "PA" },
                    { new Guid("7083a8c4-8061-463b-aa30-6da2e8313432"), "São Paulo", "SP" },
                    { new Guid("7090a315-b596-409c-82c1-63a0b87affab"), "Tocantins", "TO" },
                    { new Guid("4ec738db-7f80-4f8d-a405-b0db57c69741"), "Sergipe", "SE" },
                    { new Guid("accbe65b-6445-458d-b162-778da1a55786"), "Acre", "AC" },
                    { new Guid("d82d2ad3-ca0c-4ee6-b1ad-0092e9c6c9ff"), "Alagoas", "AL" },
                    { new Guid("bb547a09-fb59-4ba0-a55d-d8f1d751b09c"), "Amapá", "AP" },
                    { new Guid("1e4ac20d-d2a9-4493-8f04-80ba6925864f"), "Bahia", "BA" },
                    { new Guid("16ef83a4-d52e-4e22-8c2f-154c985768f1"), "Ceará", "CE" },
                    { new Guid("109411b9-f40d-4ef9-bd80-28b6889fd3a6"), "Distrito Federal", "DF" },
                    { new Guid("7e9ffa89-0fd8-42d1-a354-38edbd7eea69"), "Espírito Santo", "ES" },
                    { new Guid("ddafd76c-597c-4611-a3e3-53d934e10de3"), "Goiás", "GO" },
                    { new Guid("ea415bbe-d08f-48e3-998c-c020f7f6f31b"), "Maranhão", "MA" },
                    { new Guid("5870bbc9-af60-4f22-b208-de4a4e84420d"), "Minas Gerais", "MG" },
                    { new Guid("1dcb317f-cea9-4a8a-abcf-9e08430c4098"), "Mato Grosso do Sul", "MS" },
                    { new Guid("2be005e0-c48e-4521-a882-132dbe053a67"), "Mato Grosso", "MT" },
                    { new Guid("5a92eca9-93c9-4093-baca-8435ebe275f6"), "Pará", "PA" },
                    { new Guid("bdca7a57-9ac9-465a-aaa3-058315e47253"), "Paraíba", "PB" },
                    { new Guid("f75fdf14-5f02-4d06-9856-cc2829356941"), "Pernambuco", "PE" },
                    { new Guid("646fe8a4-1aac-4fca-8e52-0f7bdd7bedc1"), "Piauí", "PI" },
                    { new Guid("6bbcfa2f-bb45-4845-84c3-36a60cef52d0"), "Paraná", "PR" },
                    { new Guid("a745d08f-21af-4280-80cb-5a4b94cbbfdf"), "Rio de Janeiro", "RJ" },
                    { new Guid("ab339440-fcf6-4d55-8a00-b770983315e7"), "Rio Grande do Norte", "RN" },
                    { new Guid("908e9d5b-adb4-4fe1-a1f1-a43fd9edd45a"), "Rondônia", "RO" },
                    { new Guid("4e69a0ee-29dd-4907-b563-274f3a328213"), "Roraima", "RR" },
                    { new Guid("c7ed87dd-5b5a-4a32-8883-65227707102d"), "Rio Grande do Sul", "RS" },
                    { new Guid("be66ac31-bb81-41a3-9156-cfaaa4ac7d1b"), "Santa Catarina", "SC" },
                    { new Guid("969f1114-e73f-45e9-969c-1292fb9fd38c"), "Sergipe", "SE" },
                    { new Guid("a8700145-098d-46d0-913a-403ca65a89cc"), "Tocantins", "TO" }
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
