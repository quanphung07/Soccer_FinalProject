using FinalTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.Controllers
{
    public class TeamController:Controller
    {
        private readonly IDataRepo _repo;
        
        public TeamController(IDataRepo repo)
        {
            _repo=repo;
        }
        public IActionResult Index()
        {
            var teams=_repo.GetAllTeams();
            return View(teams);
        }
        public IActionResult Details(string teamName)
        {
            
            ViewData["Teamname"]=teamName;
            var team=_repo.GetTeamByName(teamName);
            return View(team);
            
        }
    }
}