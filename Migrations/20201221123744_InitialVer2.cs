using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest.Migrations
{
    public partial class InitialVer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "stadium",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "stadium",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "stadium");

            migrationBuilder.AlterColumn<string>(
                name: "Capacity",
                table: "stadium",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 30);
        }
    }
}
