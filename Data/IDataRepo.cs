using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTest.Models;

namespace FinalTest.Data
{
    public interface IDataRepo
    {
        //Team Data
        IEnumerable<Team> GetAllTeams();
        Task<Team> GetTeamByNameAsync(string name);
        void CreateTeam(Team team);
        Task<Team> GetTeamAsync(int? id);
      
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