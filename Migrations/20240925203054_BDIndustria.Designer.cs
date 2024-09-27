﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskList.Data;

#nullable disable

namespace TaskList.Migrations
{
    [DbContext(typeof(TaskListContext))]
    [Migration("20240925203054_BDIndustria")]
    partial class BDIndustria
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskList.Models.Setor", b =>
                {
                    b.Property<int>("IdSetor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSetor"));

                    b.Property<string>("NomeSetor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SetorIdSetor")
                        .HasColumnType("int");

                    b.HasKey("IdSetor");

                    b.HasIndex("SetorIdSetor");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("TaskList.Models.Tarefa", b =>
                {
                    b.Property<int>("IdTarefa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTarefa"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSetor")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Prioridade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTarefa");

                    b.HasIndex("IdSetor");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("TaskList.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TaskList.Models.Setor", b =>
                {
                    b.HasOne("TaskList.Models.Setor", null)
                        .WithMany("Setores")
                        .HasForeignKey("SetorIdSetor");
                });

            modelBuilder.Entity("TaskList.Models.Tarefa", b =>
                {
                    b.HasOne("TaskList.Models.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("IdSetor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskList.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Setor");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TaskList.Models.Usuario", b =>
                {
                    b.HasOne("TaskList.Models.Usuario", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("UsuarioIdUsuario");
                });

            modelBuilder.Entity("TaskList.Models.Setor", b =>
                {
                    b.Navigation("Setores");
                });

            modelBuilder.Entity("TaskList.Models.Usuario", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
