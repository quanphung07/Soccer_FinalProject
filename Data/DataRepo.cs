using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTest.Models;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Team> GetAllTeams()
        {
            var teams=_context.Teams
                        .Include(s=>s.Stadium).AsNoTracking();
            return teams.ToList();
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