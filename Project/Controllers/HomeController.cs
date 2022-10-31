using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public const int MaxRecentItems = 5;
        public const int MaxLargestCollections = 5;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageModel();
            model.RecentItems = await _context.CollectionItems.Where(i => !i.Hidden)
                .Include(i => i.Collection)
                .ThenInclude(c => c.Author)
                .OrderByDescending(i => i.Created)
                .Take(MaxRecentItems)
                .ToListAsync();
            model.LargestCollections = await _context.Collections.OrderByDescending(c => c.Items.Count())
                .Include(c => c.Author)
                .Take(MaxLargestCollections)
                .ToListAsync();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LanguageSelect([FromQuery] string language, [FromQuery] string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language)),
                new CookieOptions(){ Expires = DateTimeOffset.MaxValue }
                );
            return LocalRedirect(returnUrl);
        }
    }
}