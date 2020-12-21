using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest.Migrations
{
    public partial class InitialVer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamImage",
                table: "team",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryImage",
                table: "player",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamImage",
                table: "team");

            migrationBuilder.DropColumn(
                name: "CountryImage",
                table: "player");
        }
    }
}
