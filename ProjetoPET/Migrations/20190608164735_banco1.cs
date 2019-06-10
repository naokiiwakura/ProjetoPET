using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPET.Migrations
{
    public partial class banco1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeladeLojas");

            migrationBuilder.CreateTable(
                name: "Lojas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    NomeLoja = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    CNPj = table.Column<int>(nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lojas");

            migrationBuilder.CreateTable(
                name: "TeladeLojas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    CNPj = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    ImagePatch = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeladeLojas", x => x.Id);
                });
        }
    }
}
