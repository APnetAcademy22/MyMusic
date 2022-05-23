using Microsoft.AspNetCore.Mvc;
using MyMusic.Models;
using System.Diagnostics;
using MyMusic.DbHelper;

namespace MyMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MieiBrani()
        {
            BranoConnector branoConnector= new BranoConnector();
            return View(branoConnector.GetAllBrani());
        }

        [HttpGet]
        public IActionResult AddBrano()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBrano(BranoViewModel brano)
        {
            BranoConnector branoConnector = new BranoConnector();
            return View();
        }

        [HttpGet]
        public IActionResult AddBand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBand(BandViewModel band)
        {
            BandConnector bandConnector = new ();
            bandConnector.AddBand(band);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddAlbum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAlbum(AlbumViewModel album)
        {
            AlbumConnector albumConnector = new();
            albumConnector.AddAlbum(album);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}