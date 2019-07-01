using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPET.Migrations
{
    public partial class usuario_loja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Lojas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lojas_UsuarioId",
                table: "Lojas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lojas_Usuario_UsuarioId",
                table: "Lojas",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lojas_Usuario_UsuarioId",
                table: "Lojas");

            migrationBuilder.DropIndex(
                name: "IX_Lojas_UsuarioId",
                table: "Lojas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Lojas");
        }
    }
}
