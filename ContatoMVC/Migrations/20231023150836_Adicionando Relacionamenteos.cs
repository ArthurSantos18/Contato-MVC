using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContatoMVC.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoRelacionamenteos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuario_id",
                table: "contatos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_contatos_usuario_id",
                table: "contatos",
                column: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_contatos_usuarios_usuario_id",
                table: "contatos",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contatos_usuarios_usuario_id",
                table: "contatos");

            migrationBuilder.DropIndex(
                name: "IX_contatos_usuario_id",
                table: "contatos");

            migrationBuilder.DropColumn(
                name: "usuario_id",
                table: "contatos");
        }
    }
}
