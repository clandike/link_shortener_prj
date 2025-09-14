using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.BAL.Interfaces;
using UrlShortener.BAL.Models;
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
        private readonly IUrlDetailsService urlDetailService;

        public HomeController(ILogger<HomeController> logger, IUrlService urlService, IUrlDetailsService urlDetailService)
        {
            _logger = logger;
            this.urlService = urlService;
            this.urlDetailService = urlDetailService;
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
        public async Task<IActionResult> PostCreateAsync(UrlModel model)
        {
            IUrlChecker urlChecker = new UrlChecker();
            var checkedUrl = urlChecker.CheckAndReturnValidUrl(model.OriginalUrl);

            IShortener shortener = new Shortener();
            var value = shortener.GetShortUrl(checkedUrl);

            model.ShortedUrl = value.OriginalString;
            await urlService.CreateAsync(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> RemoveUrl(int id)
        {
            await urlService.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var urlDetails = await urlDetailService.GetByIdAsync(id);
            return View(urlDetails);
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
