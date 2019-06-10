using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPET.Migrations
{
    public partial class teste003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePatch",
                table: "TeladeLojas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePatch",
                table: "TeladeLojas");
        }
    }
}
