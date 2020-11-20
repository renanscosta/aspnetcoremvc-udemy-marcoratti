﻿// <auto-generated />
using System;
using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LanchesMac.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LanchesMac.Models.CarrinhoCompraItem", b =>
                {
                    b.Property<int>("CarrinhoCompraItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("CarrinhoCompraId")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<int?>("LancheId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("CarrinhoCompraItemId");

                    b.HasIndex("LancheId");

                    b.ToTable("CarrinhoCompraItens");
                });

            modelBuilder.Entity("LanchesMac.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("CategoriaNome")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("LanchesMac.Models.Lanche", b =>
                {
                    b.Property<int>("LancheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("integer");

                    b.Property<string>("DescricaoCurta")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("DescricaoDetalhada")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("EmEstoque")
                        .HasColumnType("boolean");

                    b.Property<string>("ImagemThumbnailUrl")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("IsLanchePreferido")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.HasKey("LancheId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Lanches");
                });

            modelBuilder.Entity("LanchesMac.Models.CarrinhoCompraItem", b =>
                {
                    b.HasOne("LanchesMac.Models.Lanche", "Lanche")
                        .WithMany()
                        .HasForeignKey("LancheId");
                });

            modelBuilder.Entity("LanchesMac.Models.Lanche", b =>
                {
                    b.HasOne("LanchesMac.Models.Categoria", "Categoria")
                        .WithMany("Lanches")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
