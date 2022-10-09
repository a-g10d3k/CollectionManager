using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Project.Extensions;

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

        [Route("{controller}/{id}", Name = "GetCollection")]
        public async Task<IActionResult> GetCollection([FromRoute] int id)
        {
            var query = _context.Collections.Where(c => c.Id == id)
                .Include(c => c.Author)
                .Include(c => c.Items)
                .ThenInclude(i => i.CustomStringFields);
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
        public async Task<IActionResult> PostCollection(Collection collection, [FromForm(Name = "collectionImage")] IFormFile collectionImage)
        {
            collection.Created = DateTime.Now;
            collection.Modified = collection.Created;
            var author = await _userManager.GetUserAsync(User);
            author.Collections.Add(collection);
            if (!ModelState.IsValid) return View("AddCollection", collection);
            if (collectionImage != null && collectionImage.Length <= CollectionImage.MaxSize)
            {
                collection.Image = new CollectionImage(
                    await collectionImage!.ToBytesAsync(),
                    collectionImage.ContentType
                    );
            }
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            return View("AddCollection");
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
            if (!ModelState.IsValid) return View("AddItem");
            _context.CollectionItems.Add(item);
            await _context.SaveChangesAsync();
            return View("AddItem");
        }

        [HttpGet]
        [Route("{controller}/items/{id}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            var query = _context.CollectionItems.Where(i => i.Id == id)
                .Include(i => i.CustomIntFields)
                .Include(i => i.CustomStringFields)
                .Include(i => i.CustomTextAreaFields)
                .Include(i => i.CustomBoolFields)
                .Include(i => i.CustomDateFields)
                .Include(i => i.Collection);
            if(!query.Any()) return NotFound();
            var item = await query.FirstAsync();
            return View(item);
        }

        [HttpGet]
        [Route("{controller}/Images/{id}", Name ="GetImage")]
        public async Task<IActionResult> GetImage([FromRoute] int id)
        {
            var query = _context.CollectionImages.Where(i => i.Id == id);
            if (!query.Any()) return NotFound();
            var image = await query.FirstAsync();
            return File(image.Image, image.ContentType);
        }
    }
}
