using System.Threading.Tasks;
using FinalTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.Controllers
{
    public class ScoreController:Controller
    {
         private readonly IDataRepo _repo;
        public ScoreController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> Details(int matchId)
        {
            var match= await _repo.GetMatchById(matchId);
            ViewData["HomeTeam"]=match.HomeRes.TeamName;
            ViewData["AwayTeam"]=match.AwayRes.TeamName;

            var scores=await _repo.GetScores(matchId);
            return View(scores);
        }
    }
}