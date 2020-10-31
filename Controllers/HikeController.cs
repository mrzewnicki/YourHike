using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourHike.Models;
using YourHike.Models.DTO;
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

        [HttpGet]
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

        [HttpPost]
        public IActionResult Edit(HikeVM model)
        {

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(!_db.Hikes.Any(x=>x.Id == model.Id))
            {
                TempData["RecordNotExist"] = "Wyprawa którą próbujesz edytować nie istnieje, możesz ją dodać";
                return RedirectToAction("Create",new {model=model});
            }

            HikeDTO travel = _db.Hikes.Find(model.Id);

                travel.Title = model.Title;
                travel.StartDate = model.StartDate;
                travel.EndDate = model.EndDate;
                travel.StartPlace = model.StartPlace;
                travel.EndPlace = model.EndPlace;
                travel.Distance = model.Distance;

            _db.SaveChanges();

            TempData["EditSuccess"] = "Edycja zakończona sukcesem!";
            return RedirectToAction("Details",new {Id=travel.Id});
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

        [HttpGet]
        public IActionResult Create()
        {
            HikeVM model = new HikeVM();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now.AddDays(1.0);

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(HikeVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(_db.Hikes.Any(x=>x.Title == model.Title)){
                TempData["TitleExist"] = "Wędrówka o takim tytule już istnieje - zmień go";
                return View(model);
            }

            HikeDTO toAdd = new HikeDTO(model);
            _db.Hikes.Add(toAdd);
            _db.SaveChanges();

            return RedirectToAction("Details",new{Id=toAdd.Id});
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