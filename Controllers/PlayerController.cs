using System;
using System.Threading.Tasks;
using FinalTest.Data;
using FinalTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
       public IActionResult Edit(int id,bool isSuccess=false)
       {
           var player=_repo.GetPlayerById(id);
           ViewBag.Success=isSuccess;
           return View(player);
       }
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int? id)
       {
           if(id==null)
           {
               return NotFound();
           }
           Console.Write(id);
           var player=_repo.GetPlayerById(id);

           if( await TryUpdateModelAsync<Player>(player,"",
            p=>p.FirstName,p=>p.LastName,p=>p.Kit,p=>p.Position,p=>p.Country))
           {
               try
               {

                  await _repo.SaveChangesAsync();
                   return RedirectToAction("Edit",new {id=player.PlayerID,isSuccess=true});
               }
               catch(DbUpdateException)
               {
                   ModelState.AddModelError("","Ooops");
               }
               return RedirectToAction("Edit",new {id=player.PlayerID,isSuccess=true});
               
           }
           return View(player);
       }
       
    }
}