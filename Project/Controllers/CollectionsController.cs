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
            if (!await query.AnyAsync()) return NotFound();
            Collection collection = await query.FirstAsync();
            var user = await _userManager.GetUserAsync(User);
            bool isOwner = user != null && (await _userManager.IsInRoleAsync(user, "Admin") || user == collection.Author);
            ViewData["IsOwner"] = isOwner;
            return View(collection);
        }

        [HttpGet]
        [Route("{controller}/{id}/delete", Name = "DeleteCollection")]
        public async Task<IActionResult> DeleteCollection([FromRoute] int id)
        {
            var query = _context.Collections.Where(i => i.Id == id)
                .Include(c => c.Author);
            if (!await query.AnyAsync()) return NotFound();
            var collection = await query.FirstAsync();
            var user = await _userManager.GetUserAsync(User);
            if (!await _userManager.IsInRoleAsync(user, "Admin") && user != collection.Author) return Forbid();

            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetUser", "Users", new { username = collection.Author!.UserName });
        }

        [Authorize]
        [HttpGet]
        [Route("{controller}/add", Name = "AddCollection")]
        public IActionResult AddCollection()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("{controller}/add")]
        public async Task<IActionResult> PostCollection(Collection collection, [FromForm(Name = "collectionImage")] IFormFile? collectionImage)
        {
            collection.Created = DateTime.Now;
            collection.Modified = collection.Created;
            var author = await _userManager.GetUserAsync(User);
            collection.Items[0].Hidden = true;
            collection.Items[0].Name = "hiddenItem";
            author.Collections.Add(collection);
            if (!ModelState.IsValid) return View("AddCollection");
            if (collectionImage != null && collectionImage.Length <= CollectionImage.MaxSize)
            {
                collection.Image = new CollectionImage(
                    await collectionImage!.ToBytesAsync(),
                    collectionImage.ContentType
                    );
            }
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetCollection", new { id = collection.Id });
        }

        [Authorize]
        [HttpGet]
        [Route("{controller}/{id}/add", Name = "AddItem")]
        public async Task<IActionResult> AddItem([FromRoute] int id)
        {
            var query = _context.Collections.Where(c => c.Id == id)
                .Include(c => c.Items).ThenInclude(i => i.CustomIntFields)
                .Include(c => c.Items).ThenInclude(i => i.CustomStringFields)
                .Include(c => c.Items).ThenInclude(i => i.CustomTextAreaFields)
                .Include(c => c.Items).ThenInclude(i => i.CustomBoolFields)
                .Include(c => c.Items).ThenInclude(i => i.CustomDateFields);
            if (!await query.AnyAsync()) return NotFound();
            var collection = await query.FirstAsync();
            CollectionItem item = new CollectionItem(collection);
            return View(item);
        }

        [Authorize]
        [HttpPost]
        [Route("{controller}/{collectionId}/add")]
        public async Task<IActionResult> PostItem([FromRoute] int collectionId, CollectionItem item)
        {
            var query = _context.Collections.Where(c => c.Id == collectionId).Include(c => c.Author);
            if (!await query.AnyAsync()) return NotFound();
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
            return RedirectToAction("GetItem", new { id = item.Id });
        }

        [HttpGet]
        [Route("{controller}/Items/{id}", Name = "GetItem")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            var query = _context.CollectionItems.Where(i => i.Id == id && !i.Hidden)
                .Include(i => i.CustomIntFields)
                .Include(i => i.CustomStringFields)
                .Include(i => i.CustomTextAreaFields)
                .Include(i => i.CustomBoolFields)
                .Include(i => i.CustomDateFields)
                .Include(i => i.Collection)
                .ThenInclude(c => c.Author)
                .Include(i => i.Comments)
                .Select(i => new CollectionItemDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Created = i.Created,
                    Modified = i.Modified,
                    CustomIntFields = i.CustomIntFields,
                    CustomStringFields = i.CustomStringFields,
                    CustomTextAreaFields = i.CustomTextAreaFields,
                    CustomBoolFields = i.CustomBoolFields,
                    CustomDateFields = i.CustomDateFields,
                    Collection = i.Collection,
                    LikeCount = i.Likes.Count(),
                    Comments = (List<Comment>)i.Comments.OrderByDescending(c => c.Created)
                });
            if (!await query.AnyAsync()) return NotFound();
            var item = await query.FirstAsync();
            var user = await _userManager.GetUserAsync(User);
            item.CurrentUser = user;
            item.Liked = user != null && await _context.Likes.Where(l => l.UserId == user.Id && l.ItemId == item.Id).AnyAsync();
            bool isAdmin = user != null && await _userManager.IsInRoleAsync(user, "Admin");
            ViewData["IsAdmin"] = isAdmin;
            return View(item);
        }

        [HttpGet]
        [Route("{controller}/Items/{id}/Like", Name = "LikeItem")]
        public async Task<IActionResult> LikeItem([FromRoute] int id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null) return Forbid();
            var query = _context.CollectionItems.Where(i => i.Id == id && !i.Likes.Any(l => l.UserId == user.Id));
            if (!await query.AnyAsync()) return NotFound();
            var item = await query.FirstAsync();
            item.Likes.Add(new Like() { Item = item, UserId = user.Id });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("{controller}/Items/{id}/Unlike", Name = "UnlikeItem")]
        public async Task<IActionResult> UnLikeItem([FromRoute] int id)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null) return Forbid();
            var query = _context.Likes.Where(l => l.ItemId == id && l.UserId == user.Id);
            if (!await query.AnyAsync()) return NotFound();
            var like = await query.FirstAsync();
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("{controller}/items/{id}/delete", Name = "DeleteItem")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            var query = _context.CollectionItems.Where(i => i.Id == id)
                .Include(i => i.Collection)
                .ThenInclude(c => c.Author);
            if (!await query.AnyAsync()) return NotFound();
            var item = await query.FirstAsync();
            var user = await _userManager.GetUserAsync(User);
            if (!await _userManager.IsInRoleAsync(user, "Admin") && user != item.Collection!.Author) return Forbid();

            _context.CollectionItems.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetCollection", new { id = item.Collection!.Id });
        }

        [HttpPost]
        [Route("{controller}/items/{itemId}/AddComment", Name = "AddComment")]
        public async Task<IActionResult> AddComment([FromRoute] int itemId, [FromForm] string commentText)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null) return Forbid();
            var query = _context.CollectionItems.Where(i => i.Id == itemId);
            if (!await query.AnyAsync()) return NotFound();
            var item = await query.FirstAsync();
            item.Comments.Add(new Comment() 
            { 
                Item = item,
                UserId = user.Id,
                Text = commentText,
                UserName = user.UserName,
                Created = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("GetItem", new { id = itemId });
        }

        [HttpGet]
        [Route("{controller}/DeleteComment/{id}", Name = "DeleteComment")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var query = _context.Comments.Where(c => c.Id == id);
            if(!query.Any()) return NotFound();
            var comment = await query.FirstAsync();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null || !(await _userManager.IsInRoleAsync(user, "Admin") || user.Id == comment.UserId))
                return Forbid();
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetItem", new { id = comment.ItemId });
        }

        [HttpGet]
        [Route("{controller}/Images/{id}", Name ="GetImage")]
        public async Task<IActionResult> GetImage([FromRoute] int id)
        {
            var query = _context.CollectionImages.Where(i => i.Id == id);
            if (!await query.AnyAsync()) return NotFound();
            var image = await query.FirstAsync();
            return File(image.Image, image.ContentType);
        }
    }
}
