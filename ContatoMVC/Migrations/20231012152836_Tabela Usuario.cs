using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContatoMVC.Migrations
{
    /// <inheritdoc />
    public partial class TabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    login = table.Column<string>(type: "varchar(30)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    perfil = table.Column<int>(type: "int", nullable: false),
                    senha = table.Column<string>(type: "varchar(16)", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
