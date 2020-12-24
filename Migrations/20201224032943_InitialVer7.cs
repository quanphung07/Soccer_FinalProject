using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalTest.Migrations
{
    public partial class InitialVer7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_score_match_MatchID",
                table: "score");

            migrationBuilder.DropForeignKey(
                name: "FK_score_player_PlayerID",
                table: "score");

            migrationBuilder.DropForeignKey(
                name: "FK_score_team_TeamID",
                table: "score");

            migrationBuilder.DropColumn(
                name: "Assists",
                table: "score");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "score");

            migrationBuilder.RenameColumn(
                name: "HomeRes",
                table: "result",
                newName: "Homeres");

            migrationBuilder.RenameColumn(
                name: "AwayRes",
                table: "result",
                newName: "Awayres");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "score",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "score",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MatchID",
                table: "score",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_score_match_MatchID",
                table: "score",
                column: "MatchID",
                principalTable: "match",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_score_player_PlayerID",
                table: "score",
                column: "PlayerID",
                principalTable: "player",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_score_team_TeamID",
                table: "score",
                column: "TeamID",
                principalTable: "team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_score_match_MatchID",
                table: "score");

            migrationBuilder.DropForeignKey(
                name: "FK_score_player_PlayerID",
                table: "score");

            migrationBuilder.DropForeignKey(
                name: "FK_score_team_TeamID",
                table: "score");

            migrationBuilder.RenameColumn(
                name: "Homeres",
                table: "result",
                newName: "HomeRes");

            migrationBuilder.RenameColumn(
                name: "Awayres",
                table: "result",
                newName: "AwayRes");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "score",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "score",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MatchID",
                table: "score",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Assists",
                table: "score",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "score",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_score_match_MatchID",
                table: "score",
                column: "MatchID",
                principalTable: "match",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_score_player_PlayerID",
                table: "score",
                column: "PlayerID",
                principalTable: "player",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_score_team_TeamID",
                table: "score",
                column: "TeamID",
                principalTable: "team",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
