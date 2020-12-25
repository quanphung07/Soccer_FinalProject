using System;
using System.Threading.Tasks;
using FinalTest.Data;
using FinalTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalTest.Controllers
{
    public class TeamController:Controller
    {
        private readonly IDataRepo _repo;
        
        public TeamController(IDataRepo repo)
        {
            _repo=repo;
        }
       
        public async Task<IActionResult> Index()
        {
           // var teams=_repo.GetAllTeams();
           var teams= await _repo.GetAllTeams_ver1();
            return View(teams);
        }
        public async Task<IActionResult> Details(string teamName)
        {
            
            ViewData["Teamname"]=teamName;
            var team=await _repo.GetTeamByNameAsync(teamName);
            return View(team);
            
        }
        public async Task<IActionResult> Create(int teamId)
        {
            var team=await _repo.GetTeamAsync(teamId);
            ViewBag.Team=team;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int teamId,[Bind("PlayerID,FirstName,LastName,Kit,Position,Country,TeamID,CountryImage")] Player player)
        {
            var team=await _repo.GetTeamAsync(teamId);
            try
            {
                if(ModelState.IsValid)
                {
                    var rows=await _repo.AddPlayer(player);
                    await _repo.SaveChangesAsync();
                    Console.WriteLine(rows);
                    return RedirectToAction("Details",new {teamName=team.TeamName});

                }
            }catch(DbUpdateException)
            {
                ModelState.AddModelError("","Opps");
            }
            return View(player);
        
        }
    }
}