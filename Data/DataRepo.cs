using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTest.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FinalTest.Data
{
    public class DataRepo : IDataRepo
    {
        private readonly LeagueContext _context;
        public DataRepo(LeagueContext context)
        {
            _context = context;
        }

        public void AddPlayer(Player player)
        {
            
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public bool checkExist(int homeId, int awayId)
        {
           var check=_context.Matches.Any(m=>m.HomeResTeamID==homeId&&m.AwayResTeamID==awayId);
           return check;
        }

        public void  CreateMatch(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public void CreateResult(Result result)
        {
             _context.Results.Add(result);
            _context.SaveChanges();
        }

        public void CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Match>> GetAllMatchAsync()
        {
            var matches=await _context.Matches
                                .Include(h=>h.HomeRes)
                                .Include(a=>a.AwayRes)
                                .Include(r=>r.Result)
                                .Include(s=>s.Stadium)
                                .AsNoTracking().ToListAsync();

                                
            return matches;
        }

        public void GetAllPlayers()
        {
             NpgsqlConnection conn=null;
             var connStr="Server=localhost;Port=5432;User ID=postgres;Password=crquan07;Database=finaltest_db;Pooling=True;";
             using(conn=new NpgsqlConnection(connStr))
             {
                 conn.Open();
                 var cmdStr="Select * from player";
                 NpgsqlCommand cmd=new NpgsqlCommand(cmdStr,conn);
                 using(NpgsqlDataReader rd=cmd.ExecuteReader())
                 {
                     while(rd.Read())
                     {
                         Console.WriteLine("{0},{1},{2}",rd[0],rd[1],rd[2]);
                     }
                 }
            
             }
        }

        public IEnumerable<Team> GetAllTeams()
        {
            var teams=_context.Teams
                        .Include(s=>s.Stadium).AsNoTracking();
            return teams.ToList();
        }

        public async Task<Match> GetMatchById(int matchId)
        {
            var match=await _context.Matches
                        .Include(ht=>ht.HomeRes)
                        .Include(at=>at.AwayRes)
                         .FirstOrDefaultAsync(m=>m.MatchID==matchId);
                Console.WriteLine(match.AwayRes.TeamName);         
            return match;


        }

        public Player GetPlayerById(int? id)
        {
            return _context.Players
                    .Include(t=>t.Team).AsNoTracking()
                    .FirstOrDefault(p=>p.PlayerID==id);
        }

        public async Task<Player> GetPlayerByIdAsync(int? id)
        {
            var player= await _context.Players.FirstOrDefaultAsync(p=>p.PlayerID==id);
            return player;
        }

        public async Task<IEnumerable<Score>> GetScores(int matchId)
        {
            var scores= await _context.Scores.Where(m=>m.MatchID==matchId)
                        .Include(p=>p.Player)
                        .Include(t=>t.Team)
                        .AsNoTracking().ToListAsync();
            return scores;
        }

        public Stadium GetStadiumByName(string name)
        {
            var stadium=_context.Stadiums
                        .Include(t=>t.Team).AsNoTracking()
                        .FirstOrDefault(f=>f.StadiumName==name);
            return stadium;            
        }

        public async Task<Team> GetTeamAsync(int? id)
        {
            return await _context.Teams.FirstOrDefaultAsync(t=>t.TeamID==id);
        }

        public async Task<Team> GetTeamByNameAsync(string name)
        {
            var team= await _context.Teams
                        .Include(s=>s.Players)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(s=>s.TeamName==name);
            return team;            

        }

        public bool SaveChanges()
        {
            return _context.SaveChanges()>0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync()>0;
        }

        public void UpdatePlayer(Player player)
        {
            _context.Update(player);
            _context.SaveChanges();
        }
    }
}