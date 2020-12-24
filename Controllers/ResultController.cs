using System;
using System.Threading.Tasks;
using FinalTest.Data;
using FinalTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalTest.Controllers
{
    public class ResultController:Controller
    {
        private readonly IDataRepo _repo;
        public ResultController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> Index()
        {
            var matches= await _repo.GetAllMatchAsync();
            
            return View(matches);
        }
        public IActionResult Create(int matchId)
        {
            ViewBag.id=matchId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchID,Homeres,Awayres")] Result result)
        {
            
            if(ModelState.IsValid)
            {
                try
                {
                    _repo.CreateResult(result);
                    await _repo.SaveChangesAsync();
                    return RedirectToAction("Index","Match");
                }
                catch(DbUpdateException)
                {
                    ModelState.AddModelError("","oops");
                }
            }
            return View(result);
        }
    }
}