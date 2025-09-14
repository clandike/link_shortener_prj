using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using UrlShortener.BAL.Interfaces;
using UrlShortener.BAL.Models;
using UrlShortener.Helpers;
using UrlShortener.Helpers.Commands;
using UrlShortener.Helpers.Handlers;
using UrlShortener.Helpers.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [Authorize]
    [Route("/")]
    [Controller]
    public class HomeController : Controller
    {
        private readonly UrlCommandHandler handler;

        private readonly IUrlDetailsService urlDetailService;

        public HomeController(IUrlDetailsService urlDetailService, UrlCommandHandler handler)
        {
            this.handler = handler;
            this.urlDetailService = urlDetailService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View(handler.Handle());
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
            var shortedUrl = shortener.GetShortUrl(checkedUrl);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var command = new CreateUrlCommand
            {
                OriginalUrl = model.OriginalUrl,
                ShortedUrl = shortedUrl.ToString(),
                UserId = userId!,
                UserName = User.Identity!.Name!,
            };

            await handler.Handle(command);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> RemoveUrl(int id)
        {
            var command = new DeleteUrlCommand
            {
                UrlId = id,
                UserName = User.Identity.Name!,
                IsAdmin = User.IsInRole("Admin")
            };

            try
            {
                await handler.Handle(command);

                TempData["Success"] = "URL успішно видалено.";
            }
            catch (UnauthorizedAccessException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception)
            {
                TempData["Error"] = "Сталася помилка при обробці запиту.";
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> UrlDetails(int id)
        {
            var urlDetails = await urlDetailService.GetByIdAsync(id);
            return View(urlDetails);
        }

        [AllowAnonymous]
        [Route("About")]
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
