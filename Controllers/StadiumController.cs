using FinalTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.Controllers
{
    public class StadiumController:Controller
    {
        private readonly IDataRepo _repo;
        public StadiumController(IDataRepo repo)
        {
            _repo=repo;
        }
        public IActionResult Details(string stadiumName)
        {
            var stadium=_repo.GetStadiumByName(stadiumName);
            return View(stadium);
        }
    }
}