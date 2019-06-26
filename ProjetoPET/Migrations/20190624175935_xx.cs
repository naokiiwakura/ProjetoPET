using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPET.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                table: "Eventos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Eventos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Eventos");
        }
    }
}
