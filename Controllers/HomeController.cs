using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.BAL.Interfaces;
using UrlShortener.Helpers;
using UrlShortener.Helpers.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrlService urlService;

        public HomeController(ILogger<HomeController> logger, IUrlService urlService)
        {
            _logger = logger;
            this.urlService = urlService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(urlService.GetAllModels().ToList());
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
