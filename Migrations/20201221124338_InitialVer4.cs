using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest.Migrations
{
    public partial class InitialVer4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "stadium",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "stadium",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
