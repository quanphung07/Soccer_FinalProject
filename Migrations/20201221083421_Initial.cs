using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinalTest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stadium",
                columns: table => new
                {
                    StadiumID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StadiumName = table.Column<string>(maxLength: 30, nullable: false),
                    Capacity = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stadium", x => x.StadiumID);
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamName = table.Column<string>(maxLength: 30, nullable: false),
                    StadiumID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_team_stadium_StadiumID",
                        column: x => x.StadiumID,
                        principalTable: "stadium",
                        principalColumn: "StadiumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "match",
                columns: table => new
                {
                    MatchID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Datetime = table.Column<DateTime>(nullable: false),
                    Attendance = table.Column<int>(nullable: false),
                    HomeResTeamID = table.Column<int>(nullable: true),
                    AwayResTeamID = table.Column<int>(nullable: true),
                    StadiumID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_match", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_match_team_AwayResTeamID",
                        column: x => x.AwayResTeamID,
                        principalTable: "team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_match_team_HomeResTeamID",
                        column: x => x.HomeResTeamID,
                        principalTable: "team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_match_stadium_StadiumID",
                        column: x => x.StadiumID,
                        principalTable: "stadium",
                        principalColumn: "StadiumID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Kit = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    TeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_player_team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "result",
                columns: table => new
                {
                    MatchID = table.Column<int>(nullable: false),
                    HomeRes = table.Column<int>(nullable: false),
                    AwayRes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_result_match_MatchID",
                        column: x => x.MatchID,
                        principalTable: "match",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "score",
                columns: table => new
                {
                    ScoreID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Goals = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    MatchID = table.Column<int>(nullable: true),
                    PlayerID = table.Column<int>(nullable: true),
                    TeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_score", x => x.ScoreID);
                    table.ForeignKey(
                        name: "FK_score_match_MatchID",
                        column: x => x.MatchID,
                        principalTable: "match",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_score_player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "player",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_score_team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_match_AwayResTeamID",
                table: "match",
                column: "AwayResTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_match_HomeResTeamID",
                table: "match",
                column: "HomeResTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_match_StadiumID",
                table: "match",
                column: "StadiumID");

            migrationBuilder.CreateIndex(
                name: "IX_player_TeamID",
                table: "player",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_score_MatchID",
                table: "score",
                column: "MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_score_PlayerID",
                table: "score",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_score_TeamID",
                table: "score",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_team_StadiumID",
                table: "team",
                column: "StadiumID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "result");

            migrationBuilder.DropTable(
                name: "score");

            migrationBuilder.DropTable(
                name: "match");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "stadium");
        }
    }
}
