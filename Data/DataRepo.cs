using System.Collections.Generic;
using System.Linq;
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

        public void CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public IEnumerable<Team> GetAllTeams()
        {
            var teams=_context.Teams
                        .Include(s=>s.Stadium).AsNoTracking();
            return teams.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players
                    .Include(t=>t.Team).AsNoTracking()
                    .FirstOrDefault(p=>p.PlayerID==id);
        }

        public Stadium GetStadiumByName(string name)
        {
            var stadium=_context.Stadiums
                        .Include(t=>t.Team).AsNoTracking()
                        .FirstOrDefault(f=>f.StadiumName==name);
            return stadium;            
        }

        public Team GetTeamByName(string name)
        {
            var team= _context.Teams
                        .Include(s=>s.Players)
                        .AsNoTracking()
                        .FirstOrDefault(s=>s.TeamName==name);
            return team;            

        }

        public bool SaveChanges()
        {
            return _context.SaveChanges()>0;
        }

        
    }
}