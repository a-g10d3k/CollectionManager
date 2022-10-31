using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Project.Extensions;
using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using Project.Hubs;

namespace Project.Controllers
{
    public class CollectionsController : Controller
    {
        private AppDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<CommentHub> _hubContext;

        public const int ItemsPerPage = 10;

        public CollectionsController(AppDbContext context, UserManager<ApplicationUser> userManager, IHubContext<CommentHub> hubContext)
        {
            _context = context;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("{controller}/{id}", Name = "GetCollection")]
        public async Task<IActionResult> GetCollection([FromRoute] int id, [FromQuery] int page = 1, [FromQuery] bool sortAscending = true)
        {
            if (page < 1) page = 1;
            var query = _context.Collections.Where(c => c.Id == id)
                .Include(c => c.Author)
                .Include(
                    c => 
                    (sortAscending ? 
                        c.Items
                        .Where(i => !i.Hidden)
                        .OrderBy(i => i.Created) :
                        c.Items
                        .Where(i => !i.Hidden)
                        .OrderByDescending(i => i.Created)
                    )
                    .Skip((page - 1) * ItemsPerPage)
                    .Take(ItemsPerPage))
                .ThenInclude(i => i.CustomStringFields)
                .Include(c => c.Items)
                .ThenInclude(i => i.CustomDateFields)
                .Select(c => new CollectionDto()
                {
                    Collection = c,
                    MaxPage = (c.Items.Count() - 1) / ItemsPerPage + 1,
                });
            if (!await query.AnyAsync()) return NotFound();
            CollectionDto collection = await query.FirstAsync();
            collection.Items = collection.Collection.Items;
            collection.TemplateItem = await _context.CollectionItems.Where(i => i.Collection == collection.Collection && i.Hidden)
                .Include(i => i.CustomStringFields)
                .Include(i => i.CustomDateFields).FirstAsync();
            collection.Page = page;
            var user = await _userManager.GetUserAsync(User);
            collection.IsOwner = user == null ? false : await user.OwnsCollectionAsync(collection.Collection, _userManager);
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
            if (user == null ? true : !await user.OwnsCollectionAsync(collection, _userManager)) return Forbid();
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
            if (!ModelState.IsValid) return View("AddCollection");
            collection.Created = DateTime.Now;
            collection.Modified = collection.Created;
            var author = await _userManager.GetUserAsync(User);
            collection.Items[0].Hidden = true;
            collection.Items[0].Name = "hiddenItem";
            collection.Items = new List<CollectionItem> { collection.Items[0] };
            author.Collections.Add(collection);
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
        [Route("{controller}/{id}/Edit", Name = "EditCollection")]
        public async Task<IActionResult> EditCollection([FromRoute] int id)
        {
            var collectionQuery = _context.Collections.Where(c => c.Id == id);
            if (!await collectionQuery.AnyAsync()) return NotFound();
            var collection = await collectionQuery.FirstAsync();
            var user = await _userManager.GetUserAsync(User);
            if (user == null ? true : !await user.OwnsCollectionAsync(collection, _userManager)) return Forbid();
            var itemQuery = _context.CollectionItems.Where(i => i.Collection == collection && i.Hidden == true)
                .Include(i => i.CustomIntFields)
                .Include(i => i.CustomStringFields)
                .Include(i => i.CustomTextAreaFields)
                .Include(i => i.CustomBoolFields)
                .Include(i => i.CustomDateFields);
            var templateItem = await itemQuery.FirstOrDefaultAsync();
            return View(collection);
        }

        [Authorize]
        [HttpPost]
        [Route("{controller}/{id}/Edit", Name = "PostEditCollection")]
        public async Task<IActionResult> PostEditCollection([FromRoute] int id, Collection newCollection, [FromForm(Name = "collectionImage")] IFormFile? collectionImage)
        {
            if (!ModelState.IsValid) return View("EditCollection");
            var query = _context.Collections.Where(c => c.Id == id)
                .Include(c => c.Items).ThenInclude(i => i.CustomIntFields)
                .Include(c => c.Items).ThenInclude(i => i.CustomStringFields)
                .Include(c => c.Items).ThenInclude(i => i.CustomTextAreaFields)
                .Include(c => c.Items).ThenInclude(i => i.CustomBoolFields)
                .Include(c => c.Items).ThenInclude(i => i.CustomDateFields);
            if (!await query.AnyAsync()) return NotFound();
            var oldCollection = await query.FirstAsync();
            var user = await _userManager.GetUserAsync(User);
            if (user == null ? true : !await user.OwnsCollectionAsync(oldCollection, _userManager)) return Forbid();
            oldCollection.Modified = DateTime.Now;
            oldCollection.UpdateFrom(newCollection);
            if (collectionImage != null && collectionImage.Length <= CollectionImage.MaxSize)
            {
                oldCollection.Image = new CollectionImage(
                    await collectionImage!.ToBytesAsync(),
                    collectionImage.ContentType
                    );
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("GetCollection", new { id = oldCollection.Id });
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
        public async Task<IActionResult> PostItem([FromRoute] int collectionId, CollectionItem item, [FromForm] List<string> tags)
        {
            var query = _context.Collections.Where(c => c.Id == collectionId).Include(c => c.Author);
            if (!await query.AnyAsync()) return NotFound();
            Collection collection = await query.FirstAsync();
            collection.Modified = DateTime.Now;
            var user = await _userManager.GetUserAsync(User);
            if (user == null ? true : !await user.OwnsCollectionAsync(collection, _userManager)) return Forbid();
            item.Created = DateTime.Now;
            item.Modified = DateTime.Now;
            foreach (var tag in tags) item.Tags.Add(new Tag() { Name = tag });
            collection.Items.Add(item);
            if (!ModelState.IsValid) return View("AddItem", item);
            _context.CollectionItems.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetItem", new { id = item.Id });
        }

        [Authorize]
        [HttpGet]
        [Route("{controller}/Items/{id}/Edit", Name = "EditItem")]
        public async Task<IActionResult> EditItem([FromRoute] int id)
        {
            var query = _context.CollectionItems.Where(i => i.Id == id)
                .Include(i => i.CustomIntFields)
                .Include(i => i.CustomStringFields)
                .Include(i => i.CustomTextAreaFields)
                .Include(i => i.CustomBoolFields)
                .Include(i => i.CustomDateFields)
                .Include(i => i.Tags)
                .Include(i => i.Collection);
            if (!await query.AnyAsync()) return NotFound();
            var item = await query.FirstAsync();
            var user = await _userManager.GetUserAsync(User);
            if (user == null ? true : !await user.OwnsCollectionAsync(item.Collection!, _userManager)) return Forbid();
            return View("AddItem", item);
        }

        [Authorize]
        [HttpPost]
        [Route("{controller}/Items/{itemId}/Edit", Name = "PostEditItem")]
        public async Task<IActionResult> PostEditItem([FromRoute]int itemId, CollectionItem newItem, [FromForm] List<string> tags)
        {
            var query = _context.CollectionItems.Where(i => i.Id == itemId)
                .Include(i => i.Collection)
                .Include(i => i.Tags)
                .Include(i => i.CustomIntFields)
                .Include(i => i.CustomStringFields)
                .Include(i => i.CustomTextAreaFields)
                .Include(i => i.CustomBoolFields)
                .Include(i => i.CustomDateFields);
            if (!await query.AnyAsync()) return NotFound();
            if (!ModelState.IsValid) return View("AddItem");
            var oldItem = await query.FirstAsync();
            oldItem.Modified = DateTime.Now;
            var user = await _userManager.GetUserAsync(User);
            if (user == null ? true : !await user.OwnsCollectionAsync(oldItem.Collection!, _userManager)) return Forbid();
            oldItem.UpdateFrom(newItem);
            oldItem.UpdateTags(tags);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetItem", new { id = oldItem.Id });
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
                .Include(i => i.Tags)
                .Include(i => i.Collection).ThenInclude(c => c.Author)
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
                    Comments = (List<Comment>)i.Comments.OrderByDescending(c => c.Created),
                    Tags = i.Tags
                });
            if(!await query.AnyAsync()) return NotFound();
            var item = await query.FirstAsync();
            item.TemplateItem = await _context.CollectionItems
                .Where(i => i.Collection == item.Collection && i.Hidden)
                .Include(i => i.CustomIntFields)
                .Include(i => i.CustomStringFields)
                .Include(i => i.CustomTextAreaFields)
                .Include(i => i.CustomBoolFields)
                .Include(i => i.CustomDateFields).FirstAsync();
            var user = await _userManager.GetUserAsync(User);
            item.CurrentUser = user;
            item.Liked = user != null && await _context.Likes.Where(l => l.UserId == user.Id && l.ItemId == item.Id).AnyAsync();
            item.IsAdmin = user != null && await _userManager.IsInRoleAsync(user, "Admin");
            bool isOwner = user == null ? false : await user.OwnsCollectionAsync(item.Collection!, _userManager);
            item.IsOwner = isOwner;
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
            if (user == null ? true : !await user.OwnsCollectionAsync(item.Collection!, _userManager)) return Forbid();

            _context.CollectionItems.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetCollection", new { id = item.Collection!.Id });
        }

        [HttpPost]
        [Route("{controller}/items/{itemId}/AddComment", Name = "AddComment")]
        public async Task<IActionResult> AddComment([FromRoute] int itemId, [FromBody] JsonElement data)
        {
            string? commentText;
            try
            {
                commentText = data.GetProperty("commentText").GetString();
            }
            catch(KeyNotFoundException e) { return BadRequest(); }
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null) return Forbid();
            var query = _context.CollectionItems.Where(i => i.Id == itemId);
            if (!await query.AnyAsync()) return NotFound();
            var item = await query.FirstAsync();
            var comment = new Comment()
            {
                Item = item,
                UserId = user.Id,
                Text = commentText,
                UserName = user.UserName,
                Created = DateTime.Now
            };
            item.Comments.Add(comment);
            await _context.SaveChangesAsync();
            _ = _hubContext.Clients.Group(itemId.ToString()).SendAsync("ReceiveComment", new
            {
                Id = comment.Id,
                UserName = comment.UserName,
                Text = comment.Text,
                Created = comment.Created.ToString()
            });
            return Ok();
        }

        [HttpGet]
        [Route("{controller}/DeleteComment/{id}", Name = "DeleteComment")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var query = _context.Comments.Where(c => c.Id == id);
            if(!query.Any()) return NotFound();
            var comment = await query.FirstAsync();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null || !await _userManager.IsInRoleAsync(user, "Admin"))
                return Forbid();
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return Ok();
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

        [HttpGet]
        [Route("{controller}/GetTags", Name = "GetTags")]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _context.Tags.GroupBy(t => t.Name)
            .Select(t => new
            {
                Name = t.Key,
                Count = t.Count()
            })
            .OrderByDescending(t => t.Count).ToListAsync();
            return Ok(tags);
        }
    }
}
