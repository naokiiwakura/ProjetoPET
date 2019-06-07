using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPET.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adocao_Usuario_UsuarioBusinessId",
                table: "Adocao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "UsuarioBusiness");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "UsuarioBusiness",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuarioId",
                table: "UsuarioBusiness",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "UsuarioBusiness",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioBusiness",
                table: "UsuarioBusiness",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioBusiness_UsuarioId",
                table: "UsuarioBusiness",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioBusiness_TipoUsuarioId",
                table: "UsuarioBusiness",
                column: "TipoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adocao_UsuarioBusiness_UsuarioBusinessId",
                table: "Adocao",
                column: "UsuarioBusinessId",
                principalTable: "UsuarioBusiness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioBusiness_UsuarioBusiness_UsuarioId",
                table: "UsuarioBusiness",
                column: "UsuarioId",
                principalTable: "UsuarioBusiness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioBusiness_UsuarioBusiness_TipoUsuarioId",
                table: "UsuarioBusiness",
                column: "TipoUsuarioId",
                principalTable: "UsuarioBusiness",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adocao_UsuarioBusiness_UsuarioBusinessId",
                table: "Adocao");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioBusiness_UsuarioBusiness_UsuarioId",
                table: "UsuarioBusiness");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioBusiness_UsuarioBusiness_TipoUsuarioId",
                table: "UsuarioBusiness");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioBusiness",
                table: "UsuarioBusiness");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioBusiness_UsuarioId",
                table: "UsuarioBusiness");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioBusiness_TipoUsuarioId",
                table: "UsuarioBusiness");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "UsuarioBusiness");

            migrationBuilder.DropColumn(
                name: "TipoUsuarioId",
                table: "UsuarioBusiness");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UsuarioBusiness");

            migrationBuilder.RenameTable(
                name: "UsuarioBusiness",
                newName: "Usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adocao_Usuario_UsuarioBusinessId",
                table: "Adocao",
                column: "UsuarioBusinessId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
