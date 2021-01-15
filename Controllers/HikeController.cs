
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using YourHike.Models;
using YourHike.Models.DTO;
using YourHike.Models.ViewModel;

namespace YourHike.Controllers
{
    public class HikeController : Controller
    {
        private readonly DataContext _db;
        private IHostingEnvironment _environment;

        public HikeController(DataContext db, IHostingEnvironment environment)
        {
            _db = db;
            _environment = environment;
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
            HikeVM travel = _db.Hikes.Where(x=>x.Id == id)
                                        .Include(c=>c.Files)
                                        .Select(x => new HikeVM(x))
                                        .First();

            if (_db.HikesHistory.Any(x=>x.HikeId == travel.Id))
            {
                IList<HistoryHikeDTO> travelHistoryDto = _db.HikesHistory.Where(x => x.HikeId == travel.Id)
                    .Include(x => x.Hike)
                    .OrderBy(x=>x.ModifyTime)
                    .ToList();

                if (travel.History is null)
                {
                    travel.History = new List<HistoryHikeVM>();
                }

                foreach (HistoryHikeDTO hikeHistDto in travelHistoryDto)
                {
                    travel.History.Add(new HistoryHikeVM(hikeHistDto));
                }
            }

            return View(travel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HikeVM travel = _db.Hikes.Where(x => x.Id == id)
                .Include(c => c.Files)
                .Select(x => new HikeVM(x))
                .First();

            if (travel == null)
            {
                TempData["EditResult"] = "Nie istnieje taka wędrówka";
                return RedirectToAction("Index");
            }

            return View(travel);
        }

        [HttpPost]
        public IActionResult Edit(HikeVM model, IEnumerable<IFormFile> files)
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

            History hist = new History(_db);
            hist.Update(model);

            #region Upload Image

            //create structure of directories
            var rootDir = _environment.ContentRootPath;
            var imagesDir = rootDir + "\\wwwroot\\Hikes\\Files\\";
            var hikeDir = imagesDir + "\\Hike_" + model.Id;

            if (!Directory.Exists(imagesDir))
            {
                Directory.CreateDirectory(imagesDir);
            }

            if (!Directory.Exists(hikeDir))
            {
                Directory.CreateDirectory(hikeDir);
            }

            if (files != null && files.Any())
            {
                foreach (IFormFile file in files)
                {
                    //check file extension
                    string ext = file.ContentType.ToLower();
                    if (ext != "image/jpg" &&
                        ext != "image/jpeg" &&
                        ext != "image/pjpeg" &&
                        ext != "image/gif" &&
                        ext != "image/png" &&
                        ext != "image/x-png")
                    {
                        ModelState.AddModelError("", "Obraz nie został przesłany - nieprawidłowe rozszerzenie obrazu.");
                        return View(model);
                    }

                    using (var fileStream = new FileStream(Path.Combine(hikeDir, file.FileName), FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fileStream);
                    }

                    string displayName = file.FileName;
                    if (file.FileName.Contains("."))
                    {
                        int index = displayName.IndexOf(".");
                        displayName = displayName.Remove(0, index);
                    }


                    //save image name to db
                    FileDTO fileDto = new FileDTO()
                    {
                        FileName = file.FileName,
                        DisplayName = displayName,
                        FileType = ext,
                        HikeId = model.Id,
                        UploadTime = DateTime.Now
                    };

                    _db.Files.Add(fileDto);
                    _db.SaveChanges();
                }
            }
            #endregion

            TempData["EditSuccess"] = "Edycja zakończona sukcesem!";
            return RedirectToAction("Details",new {Id=model.Id});
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
        public IActionResult Create(HikeVM model, IEnumerable<IFormFile> files)
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

            #region Upload Image

            //create structure of directories
            var rootDir = _environment.ContentRootPath;
            var imagesDir = rootDir + "\\wwwroot\\Hikes\\Files\\";
            var hikeDir = imagesDir + "\\Hike_" + toAdd.Id;

            if (!Directory.Exists(imagesDir))
            {
                Directory.CreateDirectory(imagesDir);
            }

            if (!Directory.Exists(hikeDir))
            {
                Directory.CreateDirectory(hikeDir);
            }

            if (files != null && files.Any())
            {
                foreach (IFormFile file in files)
                {
                    //check file extension
                    string ext = file.ContentType.ToLower();
                    if (ext != "image/jpg" &&
                        ext != "image/jpeg" &&
                        ext != "image/pjpeg" &&
                        ext != "image/gif" &&
                        ext != "image/png" &&
                        ext != "image/x-png")
                    {
                        ModelState.AddModelError("", "Obraz nie został przesłany - nieprawidłowe rozszerzenie obrazu.");
                        return View(model);
                    }

                    using (var fileStream = new FileStream(Path.Combine(hikeDir, file.FileName), FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fileStream);
                    }

                    string displayName = file.FileName;
                    if (file.FileName.Contains("."))
                    {
                        int index = displayName.IndexOf(".");
                        displayName = displayName.Remove(0, index);
                    }


                    //save image name to db
                    FileDTO fileDto = new FileDTO()
                    {
                        FileName = file.FileName,
                        DisplayName = displayName,
                        FileType = ext,
                        HikeId = toAdd.Id,
                        UploadTime = DateTime.Now
                    };

                    _db.Files.Add(fileDto);
                    _db.SaveChanges();
                }
            }
            #endregion

            return RedirectToAction("Details",new{Id=toAdd.Id});
        }

    }
}