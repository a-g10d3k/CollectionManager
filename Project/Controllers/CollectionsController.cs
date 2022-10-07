using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    public class CollectionsController : Controller
    {
        private AppDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public CollectionsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("{controller}/{id}")]
        public async Task<IActionResult> GetCollection([FromRoute] int id)
        {
            var query = _context.Collections.Where(c => c.Id == id).Include(c => c.Author);
            if (!query.Any()) return NotFound();
            Collection collection = await query.FirstAsync();
            return View(collection);
        }

        [HttpGet]
        [Route("{controller}/add")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("{controller}/add")]
        public async Task<IActionResult> PostCollection(Collection collection)
        {
            collection.Created = DateTime.Now;
            collection.Modified = collection.Created;
            var author = await _userManager.GetUserAsync(User);
            author.Collections.Add(collection);
            if (!ModelState.IsValid) return View("Add", collection);
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            return View("Add");
        }
    }
}
