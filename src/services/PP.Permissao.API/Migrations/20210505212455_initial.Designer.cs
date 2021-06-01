﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PP.Permissao.API.Data;

namespace PP.Permissao.API.Migrations
{
    [DbContext(typeof(PermissaoContext))]
    [Migration("20210505212455_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PP.Permissao.API.Models.Permissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("TipoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoId")
                        .HasName("IDX_Tipo");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("PP.Permissao.API.Models.Tipo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tipo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ab4c848b-5e7c-4290-8867-0535ed4f8154"),
                            Descricao = "Menu"
                        },
                        new
                        {
                            Id = new Guid("7fc734e9-266f-4b25-96d2-9371e0f7b2db"),
                            Descricao = "Sub Menu"
                        });
                });

            modelBuilder.Entity("PP.Permissao.API.Models.Permissao", b =>
                {
                    b.HasOne("PP.Permissao.API.Models.Tipo", "Tipo")
                        .WithMany("Permissao")
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
