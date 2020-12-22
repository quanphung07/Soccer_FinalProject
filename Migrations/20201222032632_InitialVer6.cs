using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest.Migrations
{
    public partial class InitialVer6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_match_team_AwayResTeamID",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_team_HomeResTeamID",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_stadium_StadiumID",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_player_team_TeamID",
                table: "player");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "player",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StadiumID",
                table: "match",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HomeResTeamID",
                table: "match",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AwayResTeamID",
                table: "match",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_AwayResTeamID",
                table: "match",
                column: "AwayResTeamID",
                principalTable: "team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_HomeResTeamID",
                table: "match",
                column: "HomeResTeamID",
                principalTable: "team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_match_stadium_StadiumID",
                table: "match",
                column: "StadiumID",
                principalTable: "stadium",
                principalColumn: "StadiumID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_player_team_TeamID",
                table: "player",
                column: "TeamID",
                principalTable: "team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_match_team_AwayResTeamID",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_team_HomeResTeamID",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_match_stadium_StadiumID",
                table: "match");

            migrationBuilder.DropForeignKey(
                name: "FK_player_team_TeamID",
                table: "player");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "player",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StadiumID",
                table: "match",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "HomeResTeamID",
                table: "match",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AwayResTeamID",
                table: "match",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_AwayResTeamID",
                table: "match",
                column: "AwayResTeamID",
                principalTable: "team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_match_team_HomeResTeamID",
                table: "match",
                column: "HomeResTeamID",
                principalTable: "team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_match_stadium_StadiumID",
                table: "match",
                column: "StadiumID",
                principalTable: "stadium",
                principalColumn: "StadiumID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_player_team_TeamID",
                table: "player",
                column: "TeamID",
                principalTable: "team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
