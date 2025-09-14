using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.BAL.Interfaces;
using UrlShortener.BAL.Models;
using UrlShortener.Helpers;
using UrlShortener.Helpers.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
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
            var entity = urlService.GetAllModels().Where(x => x.OriginalUrl == model.OriginalUrl && x.ShortedUrl == model.ShortedUrl).FirstOrDefault();

            var urlDetailsModel = new UrlDetailsModel()
            {
                UrlId = entity!.Id,
                CreatedBy = "123123",
            };

            await urlDetailService.CreateAsync(urlDetailsModel);

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
        public async Task<IActionResult> UrlDetails(int id)
        {
            var urlDetails = await urlDetailService.GetByIdAsync(id);
            return View(urlDetails);
        }


        [AllowAnonymous]
        public IActionResult About()
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
