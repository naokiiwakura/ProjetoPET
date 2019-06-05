using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPET.Migrations
{
    public partial class oloco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TeladeLojas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "TeladeLojas",
                newName: "RazaoSocial");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TeladeLojas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "TeladeLojas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TeladeLojas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TeladeLojas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "TeladeLojas");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TeladeLojas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TeladeLojas",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RazaoSocial",
                table: "TeladeLojas",
                newName: "Nome");
        }
    }
}
