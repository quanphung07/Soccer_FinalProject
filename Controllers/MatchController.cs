using System;
using System.Threading.Tasks;
using FinalTest.Data;
using FinalTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalTest.Controllers
{
    public class MatchController:Controller
    {
        private readonly IDataRepo _repo;
        public MatchController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> Index()
        {
            var matches= await _repo.GetAllMatchAsync();
            
            return View(matches);
        }
        public IActionResult Create(bool checkExist=false)
        {
            ViewBag.CheckExist=checkExist;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchID,Datetime,Attendance,HomeResTeamID,AwayResTeamID,StadiumID")] Match match)
        {
            int rows;
            if(_repo.checkExist(match.HomeResTeamID,match.AwayResTeamID))
            {
                return RedirectToAction("Create",new{checkExist=true});
            }
            if(ModelState.IsValid)
            {
                try
                {
                    rows=await _repo.CreateMatch(match);
                    await _repo.SaveChangesAsync();
                    
                }
                catch(DbUpdateException)
                {
                    ModelState.AddModelError("","oops");
                }
            }
            return RedirectToAction("Create","Result",new {id=match.MatchID});;
        }
    }
}