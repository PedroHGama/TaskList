using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskList.Migrations
{
    /// <inheritdoc />
    public partial class BDIndustria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    IdSetor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSetor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SetorIdSetor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.IdSetor);
                    table.ForeignKey(
                        name: "FK_Setor_Setor_SetorIdSetor",
                        column: x => x.SetorIdSetor,
                        principalTable: "Setor",
                        principalColumn: "IdSetor");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    IdTarefa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prioridade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdSetor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.IdTarefa);
                    table.ForeignKey(
                        name: "FK_Tarefa_Setor_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setor",
                        principalColumn: "IdSetor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefa_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Setor_SetorIdSetor",
                table: "Setor",
                column: "SetorIdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_IdSetor",
                table: "Tarefa",
                column: "IdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_IdUsuario",
                table: "Tarefa",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioIdUsuario",
                table: "Usuario",
                column: "UsuarioIdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
