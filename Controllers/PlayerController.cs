using FinalTest.Data;
using FinalTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.Controllers
{
    public class PlayerController:Controller
    {
        private readonly IDataRepo _repo;
        public PlayerController(IDataRepo repo)
        {
            _repo=repo;
        }
       public IActionResult Details(int id)
       {
           var player=_repo.GetPlayerById(id);
           return View(player);
       }
       
    }
}