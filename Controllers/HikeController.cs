using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourHike.Models;
using YourHike.Models.ViewModel;

namespace YourHike.Controllers
{
    public class HikeController : Controller
    {
        private readonly DataContext _db;

        public HikeController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<HikeVM> travels = _db.Hikes.Select(x => new HikeVM(x)).ToList();

            return View(travels);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            HikeVM travel = _db.Hikes.Where(x=>x.Id == id).Select(x => new HikeVM(x)).First();

            return View(travel);
        }

        public IActionResult Edit(int id)
        {
            HikeVM travel = _db.Hikes.Where(x=>x.Id == id).Select(x => new HikeVM(x)).First();

            if(travel == null)
            {
                TempData["EditResult"] = "Nie istnieje taka wędrówka";
                return RedirectToAction("Index");
            }

            return View(travel);
        }

        public IActionResult Delete(int id)
        {
            var toDelete = _db.Hikes.Find(id);

            if(toDelete == null)
            {
                TempData["DeleteResult"] = "Nie istnieje taka wędrówka";
                return RedirectToAction("Index");
            }

            _db.Hikes.Remove(toDelete);
            _db.SaveChanges();

            TempData["DeleteResult"] = "Wędrówka usunięta - teraz można ruszać na następną..";
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /*
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
}