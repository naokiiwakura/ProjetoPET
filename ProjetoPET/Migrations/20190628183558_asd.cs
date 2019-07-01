using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPET.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Eventos",
                newName: "DataHoraInicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraFim",
                table: "Eventos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraFim",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "DataHoraInicio",
                table: "Eventos",
                newName: "DataHora");
        }
    }
}
