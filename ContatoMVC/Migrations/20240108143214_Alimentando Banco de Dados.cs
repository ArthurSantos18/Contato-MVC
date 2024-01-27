using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContatoMVC.Migrations
{
    /// <inheritdoc />
    public partial class AlimentandoBancodeDados : Migration
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
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(60)", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.id);
                    table.ForeignKey(
                        name: "FK_contatos_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "data_atualizacao", "data_cadastro", "email", "login", "nome", "perfil", "senha" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 1, 8, 11, 32, 13, 878, DateTimeKind.Local).AddTicks(7542), "nieeg18@gmail.com", "adm", "Administrador", 0, "40bd001563085fc35165329ea1ff5c5ecbdbbeef" },
                    { 2, null, new DateTime(2024, 1, 8, 11, 32, 13, 878, DateTimeKind.Local).AddTicks(7571), "battler@gmail.com", "BATTLER", "Battler", 1, "40bd001563085fc35165329ea1ff5c5ecbdbbeef" },
                    { 3, null, new DateTime(2024, 1, 8, 11, 32, 13, 878, DateTimeKind.Local).AddTicks(7607), "beatrice@gmail.com", "BEATRICE", "Beatrice", 1, "40bd001563085fc35165329ea1ff5c5ecbdbbeef" }
                });

            migrationBuilder.InsertData(
                table: "contatos",
                columns: new[] { "id", "email", "nome", "telefone", "usuario_id" },
                values: new object[,]
                {
                    { 1, "rudolf@gmail.com", "Rudolf", "00 0000-0000", 2 },
                    { 2, "kyrie@gmail.com", "Kyrie", "00 0000-0110", 2 },
                    { 3, "maria@gmail.com", "Maria", "00 1010-1110", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contatos_usuario_id",
                table: "contatos",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
