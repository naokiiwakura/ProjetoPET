using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPET.Migrations
{
    public partial class Inici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "TeladeLojas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CEP",
                table: "TeladeLojas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "TeladeLojas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "TeladeLojas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TeladeLojas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeEmpresa",
                table: "TeladeLojas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "TeladeLojas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Telefone",
                table: "TeladeLojas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "TeladeLojas");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "TeladeLojas");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "TeladeLojas");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "TeladeLojas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TeladeLojas");

            migrationBuilder.DropColumn(
                name: "NomeEmpresa",
                table: "TeladeLojas");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "TeladeLojas");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "TeladeLojas");
        }
    }
}
