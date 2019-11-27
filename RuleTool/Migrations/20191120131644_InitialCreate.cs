using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RuleTool.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FieldLeft = table.Column<string>(nullable: true),
                    Operator = table.Column<string>(nullable: true),
                    FieldRight = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rule");
        }
    }
}
