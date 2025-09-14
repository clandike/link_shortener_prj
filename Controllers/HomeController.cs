using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.DAL.Interfaces;
using UrlShortener.DAL.Repository;
using UrlShortener.Database.Context;
using UrlShortener.Helpers;
using UrlShortener.Helpers.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UrlDbContext _context;

        public HomeController(ILogger<HomeController> logger, UrlDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IUrlRepositiory repository = new UrlRepository(_context);
            return View(repository.GetAll());
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult PostCreate(string url)
        {
            IUrlChecker urlChecker = new UrlChecker();
            var checkedUrl = urlChecker.CheckAndReturnValidUrl(url);

            IShortener shortener = new Shortener();
            var value = shortener.GetShortUrl(checkedUrl);

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
