using System.Threading.Tasks;
using FinalTest.Data;
using FinalTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            ViewData["HomeTeam"]=match.HomeName;
            ViewData["AwayTeam"]=match.AwayName;
             ViewData["HomeImage"]=match.HomeImage;
            ViewData["AwayImage"]=match.AwayImage;

            var scores=await _repo.GetScores(matchId);
            return View(scores);
        }
        public IActionResult Create(int matchId)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScoreID,MatchID,PlayerID,TeamID")] Score score)
        {
            if(ModelState.IsValid)
            {
                try
               {
                await _repo.CreateScore(score);
                await _repo.SaveChangesAsync();
                }
                catch(DbUpdateException)
                {
                ModelState.AddModelError("","Opps");
                }

        }
        return RedirectToAction("Index","Match");


        }
    }
}