using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourHike.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using YourHike.Models.DTO;


namespace YourHike.Controllers
{
    public class FileController : Controller
    {
        private DataContext _db;
        private IHostingEnvironment _environment;
        public FileController(DataContext db, IHostingEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return RedirectToRoute("default");
        }

        [HttpPost]
        public string Delete(int id)
        {
            if (_db.Files.Any(x=>x.Id == id))
            {
                FileDTO travel = _db.Files.Where(x => x.Id == id).Include(x => x.Hike).First();


                var rootDir = _environment.ContentRootPath;
                var imagesDir = rootDir + "\\wwwroot\\Hikes\\Files\\";
                var hikeDir = imagesDir + "\\Hike_" + travel.Hike.Id;

                if (Directory.Exists(hikeDir))
                {
                    if (System.IO.File.Exists(hikeDir + travel.FileName))
                    {
                        System.IO.File.Delete(hikeDir + travel.FileName);
                    }
                }

                _db.Files.Remove(travel);
                _db.SaveChanges();

                return "OK";
            }

            return "ERR";
        }
    }
}