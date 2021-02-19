﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PP.Usuario.API.Data;

namespace PP.Usuario.API.Migrations
{
    [DbContext(typeof(UsuarioContext))]
    [Migration("20210219004958_Usuarios")]
    partial class Usuarios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PP.Usuario.API.Models.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataExcluido")
                        .HasColumnName("DataExcluido")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Excluido")
                        .HasColumnName("Excluido")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.HasIndex("ProfessorId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("PP.Usuario.API.Models.AnamnesePergunta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Pergunta")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("AnamnesePergunta");
                });

            modelBuilder.Entity("PP.Usuario.API.Models.AnamneseResposta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnamnesePerguntaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("AnamnesePerguntaId");

                    b.ToTable("AnamneseResposta");
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Biometria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(3,2)");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AnteBracoDireito")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("AnteBracoEsquerdo")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BracoDireito")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("BracoEsquerdo")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("Cintura")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("CoxaDireita")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("CoxaEsquerda")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataDesativacao")
                        .HasColumnName("DataExcluido")
                        .HasColumnType("datetime");

                    b.Property<bool>("Desativado")
                        .HasColumnName("Excluido")
                        .HasColumnType("bit");

                    b.Property<decimal>("GemeoDireito")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("GemeoEsquerdo")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<decimal>("Quadril")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("Torax")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Biometria");
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<Guid>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Ficha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnamneseRespostaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Objetivo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("AnamneseRespostaId");

                    b.ToTable("Ficha");
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CREF")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataExcluido")
                        .HasColumnName("DataExcluido")
                        .HasColumnType("datetime");

                    b.Property<bool>("Excluido")
                        .HasColumnName("Excluido")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Aluno", b =>
                {
                    b.HasOne("PP.Usuario.API.Models.Endereco", "Endereco")
                        .WithOne("Aluno")
                        .HasForeignKey("PP.Usuario.API.Models.Aluno", "EnderecoId")
                        .IsRequired();

                    b.HasOne("PP.Usuario.API.Models.Professor", "Professor")
                        .WithMany("Aluno")
                        .HasForeignKey("ProfessorId")
                        .IsRequired();

                    b.OwnsOne("PP.Core.DomainObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("AlunoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(254)");

                            b1.HasKey("AlunoId");

                            b1.ToTable("Aluno");

                            b1.WithOwner()
                                .HasForeignKey("AlunoId");
                        });
                });

            modelBuilder.Entity("PP.Usuario.API.Models.AnamneseResposta", b =>
                {
                    b.HasOne("PP.Usuario.API.Models.AnamnesePergunta", "AnamnesePergunta")
                        .WithMany("AnamneseResposta")
                        .HasForeignKey("AnamnesePerguntaId")
                        .IsRequired();
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Biometria", b =>
                {
                    b.HasOne("PP.Usuario.API.Models.Aluno", "Aluno")
                        .WithMany("Biometria")
                        .HasForeignKey("AlunoId")
                        .IsRequired();
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Endereco", b =>
                {
                    b.HasOne("PP.Usuario.API.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .IsRequired();
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Ficha", b =>
                {
                    b.HasOne("PP.Usuario.API.Models.Aluno", "Aluno")
                        .WithMany("Ficha")
                        .HasForeignKey("AlunoId")
                        .IsRequired();

                    b.HasOne("PP.Usuario.API.Models.AnamneseResposta", "AnamneseResposta")
                        .WithMany("Ficha")
                        .HasForeignKey("AnamneseRespostaId")
                        .IsRequired();
                });

            modelBuilder.Entity("PP.Usuario.API.Models.Professor", b =>
                {
                    b.OwnsOne("PP.Core.DomainObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ProfessorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(254)");

                            b1.HasKey("ProfessorId");

                            b1.ToTable("Professor");

                            b1.WithOwner()
                                .HasForeignKey("ProfessorId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
