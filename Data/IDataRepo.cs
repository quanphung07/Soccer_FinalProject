using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTest.Models;

namespace FinalTest.Data
{
    public interface IDataRepo
    {
        //Team Data
        IEnumerable<Team> GetAllTeams();
        Team GetTeamByName(string name);
        void CreateTeam(Team team);

        //Player Data
        Player GetPlayerById(int? id);
        void AddPlayer(Player player);
        void UpdatePlayer(Player player);
        //Stadium data
        Stadium GetStadiumByName(string name);
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        Task<Player> GetPlayerByIdAsync(int? id);
    }
}