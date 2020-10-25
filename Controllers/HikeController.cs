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

        public IActionResult Index()
        {
            List<HikeVM> travels = _db.Hikes.Select(x => new HikeVM(x)).ToList();

            return View(travels);
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