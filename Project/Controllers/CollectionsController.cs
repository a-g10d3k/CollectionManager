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

        [Authorize]
        [HttpGet]
        [Route("{controller}/add")]
        public IActionResult AddCollection()
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

        [HttpGet]
        [Route("{controller}/{id}/add")]
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        [Route("{controller}/{collectionId}/add")]
        public async Task<IActionResult> PostItem([FromRoute] int collectionId, CollectionItem item)
        {
            var query = _context.Collections.Where(c => c.Id == collectionId).Include(c => c.Author);
            if (!query.Any()) return NotFound();
            Collection collection = await query.FirstAsync();
            collection.Modified = DateTime.Now;
            var user = await _userManager.GetUserAsync(User);
            if (!await _userManager.IsInRoleAsync(user, "Admin") && user != collection.Author) return Forbid();
            item.Created = DateTime.Now;
            item.Modified = DateTime.Now;
            collection.Items.Add(item);
            if (!ModelState.IsValid) return View("AddItem", item);
            _context.CollectionItems.Add(item);
            await _context.SaveChangesAsync();
            return View("AddItem");
        }
    }
}
