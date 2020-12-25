using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTest.Dtos;
using FinalTest.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FinalTest.Data {
    public class DataRepo : IDataRepo {
        private readonly LeagueContext _context;
        public DataRepo (LeagueContext context) {
            _context = context;
        }

        public async Task<int> AddPlayer (Player player) {
            NpgsqlConnection conn = null;
            int row;
            var connStr = "Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
            using (conn = new NpgsqlConnection (connStr)) {

                var cmdStr = "Insert into player values" +
                    " (@playerId,@firstname,@lastname,@kit,@position,@country,@teamId,@countryimage);";

                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    cmd.Parameters.Add ("@playerId", NpgsqlTypes.NpgsqlDbType.Integer).Value = player.PlayerID;
                    cmd.Parameters.Add ("@firstname", NpgsqlTypes.NpgsqlDbType.Text).Value = player.FirstName;
                    cmd.Parameters.Add ("@lastname", NpgsqlTypes.NpgsqlDbType.Text).Value = player.LastName;
                    cmd.Parameters.Add ("@kit", NpgsqlTypes.NpgsqlDbType.Integer).Value = player.Kit;
                    cmd.Parameters.Add ("@position", NpgsqlTypes.NpgsqlDbType.Text).Value = player.Position;
                    cmd.Parameters.Add ("@kit", NpgsqlTypes.NpgsqlDbType.Integer).Value = player.Kit;
                    cmd.Parameters.Add ("@country", NpgsqlTypes.NpgsqlDbType.Text).Value = player.Country;
                    cmd.Parameters.Add ("@countryimage", NpgsqlTypes.NpgsqlDbType.Text).Value = player.CountryImage;
                    cmd.Parameters.Add ("@teamId", NpgsqlTypes.NpgsqlDbType.Integer).Value = player.TeamID;
                    row = await cmd.ExecuteNonQueryAsync ();

                }

            }
            return row;
            //    _context.Players.Add(player);
            //     _context.SaveChanges();
        }

        public bool checkExist (int homeId, int awayId) {
            var check = _context.Matches.Any (m => m.HomeResTeamID == homeId && m.AwayResTeamID == awayId);
            return check;
        }

        public async Task<int> CreateMatch (Match match) {
            var connStr = "Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into match values " +
                    "(@matchID,@datetime,@attendance,@homeid,@awayid,@stadiumid);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchID", match.MatchID);
                    cmd.Parameters.AddWithValue ("@datetime", match.Datetime);
                    cmd.Parameters.AddWithValue ("@attendance", match.Attendance);
                    cmd.Parameters.AddWithValue ("@homeid", match.HomeResTeamID);
                    cmd.Parameters.AddWithValue ("@awayid", match.AwayResTeamID);
                    cmd.Parameters.AddWithValue ("@stadiumid", match.StadiumID);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();
                }
            }
            return rows;

            /* _context.Matches.Add(match);
             _context.SaveChanges();*/
        }

        public async Task<int> CreateResult (Result result) {
            var connStr = "Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into result values(@matchid,@homeid,@awayid);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchid", result.MatchID);
                    cmd.Parameters.AddWithValue ("@homeid", result.Homeres);
                    cmd.Parameters.AddWithValue ("@awayid", result.Awayres);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();

                }
            }
            return rows;

            //  _context.Results.Add(result);
            // _context.SaveChanges();
        }

        public async Task<int> CreateScore(Score score)
        {
            var connStr = "Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection(connStr)) {
                var cmdStr = "Insert into score values(@scoreid,@matchid,@playerid,@teamid);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@scoreid", score.ScoreID);
                    cmd.Parameters.AddWithValue ("@matchid", score.MatchID);
                    cmd.Parameters.AddWithValue ("@playerid", score.PlayerID);
                    cmd.Parameters.AddWithValue ("@teamid", score.TeamID);


                    await conn.OpenAsync();
                    rows = await cmd.ExecuteNonQueryAsync();

                }
            }
            return rows;

        }

        public async Task<int> CreateTeam (Team team) {
            var connStr = "Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into team values(@teamid,@teamname,@teamimage,@stadiumid);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@teamid", team.TeamID);
                    cmd.Parameters.AddWithValue ("@teamname", team.TeamName);
                    cmd.Parameters.AddWithValue ("@teamimage", team.TeamImage);
                    cmd.Parameters.AddWithValue ("@stadiumid", team.StadiumID);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();

                }
            }
            return rows;
        }

        public async Task<IEnumerable<MatchInfoDtos>> GetAllMatchAsync () {

            List<MatchInfoDtos> matches = new List<MatchInfoDtos> ();
            var connStr = "Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "select * from match_info_dto4";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                        var match = new MatchInfoDtos () {
                        MatchID = rd.GetInt32 (1),
                        Datetime = rd.GetDateTime (2),
                        Attendance = rd.GetInt32 (3),
                        HomeName = rd.GetString (11),
                        AwayName = rd.GetString (13),
                        StadiumName = rd.GetString (8),
                        HomeRes = rd.GetInt32 (6),
                        AwayRes = rd.GetInt32 (7),
                        HomeImage = rd.GetString (12),
                        AwayImage = rd.GetString (14)

                            };
                            matches.Add (match);
                        }
                    }

                }
            }

            return matches;
        }

        public void GetAllPlayers () {
            NpgsqlConnection conn = null;
            var connStr = "Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
            using (conn = new NpgsqlConnection (connStr)) {
                conn.Open ();
                var cmdStr = "Select * from player";
                NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn);
                using (NpgsqlDataReader rd = cmd.ExecuteReader ()) {
                    while (rd.Read ()) {
                        Console.WriteLine ("{0},{1},{2}", rd[0], rd[1], rd[2]);
                    }
                }

            }
        }

        public async Task<IEnumerable<TeamDtos>> GetAllTeams_ver1 () {
            NpgsqlConnection conn = null;
            List<TeamDtos> list = new List<TeamDtos> ();
            var connStr = "Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
            using (conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Select * from team inner join stadium using(\"StadiumID\");";
                using (NpgsqlCommand command = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync ()) {
                        while (reader.Read ()) {
                        var team = new TeamDtos () {
                        StadiumID = reader.GetInt32 (0),
                        TeamID = reader.GetInt32 (1),
                        TeamName = reader.GetString (2),
                        TeamImage = reader.GetString (3),
                        StadiumName = reader.GetString (4)

                            };
                            list.Add (team);
                        }
                    }
                }

            }
            return list;

        }

        public async Task<MatchInfoDtos> GetMatchById (int matchId) {
            MatchInfoDtos match=new MatchInfoDtos();
            NpgsqlConnection conn=null;
            var connStr = "Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
            using(conn=new NpgsqlConnection(connStr))
            {
                var cmdStr="select * from match_info_dto4 where \"MatchID\"=@matchid;";
                using(NpgsqlCommand cmd=new NpgsqlCommand(cmdStr,conn))
                {
                    cmd.Parameters.AddWithValue("@matchid",matchId);
                    await conn.OpenAsync();
                    using(NpgsqlDataReader rd=await cmd.ExecuteReaderAsync())
                    {
                        
                        while(rd.Read())
                        {
                          
                            
                            match.HomeName=rd.GetString(11);
                           match.AwayName=rd.GetString(13);
                           match.HomeImage=rd.GetString(12);
                           match.AwayImage=rd.GetString(14);
                            
                           
                        };
                    }
                }

            }
            return match;

        }

        public Player GetPlayerById (int? id) {
            return _context.Players
                .Include (t => t.Team).AsNoTracking ()
                .FirstOrDefault (p => p.PlayerID == id);
        }

        public async Task<Player> GetPlayerByIdAsync (int? id) {
            var player = await _context.Players.FirstOrDefaultAsync (p => p.PlayerID == id);
            return player;
        }

        public async Task<IEnumerable<Score>> GetScores (int matchId) {
            var scores = await _context.Scores.Where (m => m.MatchID == matchId)
                .Include (p => p.Player)
                .Include (t => t.Team)
                .AsNoTracking ().ToListAsync ();
            return scores;
        }

        public Stadium GetStadiumByName (string name) {
            var stadium = _context.Stadiums
                .Include (t => t.Team).AsNoTracking ()
                .FirstOrDefault (f => f.StadiumName == name);
            return stadium;
        }

        public async Task<Team> GetTeamAsync (int? id) {
            return await _context.Teams.FirstOrDefaultAsync (t => t.TeamID == id);
        }

        public async Task<Team> GetTeamByNameAsync (string name) {
            var team = await _context.Teams
                .Include (s => s.Players)
                .AsNoTracking ()
                .FirstOrDefaultAsync (s => s.TeamName == name);
            return team;

        }

        public bool SaveChanges () {
            return _context.SaveChanges () > 0;
        }

        public async Task<bool> SaveChangesAsync () {
            return await _context.SaveChangesAsync () > 0;
        }

        public void UpdatePlayer (Player player) {
            _context.Update (player);
            _context.SaveChanges ();
        }
    }
}