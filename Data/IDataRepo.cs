using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTest.Dtos;
using FinalTest.Models;

namespace FinalTest.Data
{
    public interface IDataRepo
    {
        //Team Data
        Task<Team> GetTeamByNameAsync(string name);
        Task<int> CreateTeam(Team team);
        Task<Team> GetTeamAsync(int? id);
        Task<IEnumerable<TeamDtos>> GetAllTeams_ver1();
        
      
                //Player Data
        Player GetPlayerById(int? id);
        Task <int> AddPlayer(Player player);
        void UpdatePlayer(Player player);
        //Stadium data
        Stadium GetStadiumByName(string name);
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        Task<Player> GetPlayerByIdAsync(int? id);
        void GetAllPlayers();
        //match data
        Task<IEnumerable<MatchInfoDtos>> GetAllMatchAsync();
        Task<int> CreateMatch(Match match);
        bool checkExist(int homeId,int awayId);
        Task<MatchInfoDtos> GetMatchById(int matchId);

        //result data
        Task<int> CreateResult(Result result);
        //score data
        Task<IEnumerable<Score>> GetScores(int matchId);
        Task<int> CreateScore(Score score);

    }
}