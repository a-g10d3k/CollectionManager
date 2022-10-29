using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        [Route("{controller}", Name="Search")]
        public async Task<IActionResult> Search([FromQuery]string searchTerm)
        {
            SearchModel model = new SearchModel();
            if (searchTerm == null) return View(model);
            model.Collections = await _context.Collections
                .FromSqlRaw("Select * FROM Collections WHERE FREETEXT((Name, Description), {0})", searchTerm)
                .Include(c => c.Author)
                .ToListAsync();
            model.Items = await _context.CollectionItems
                .Where(
                i => EF.Functions.FreeText(i.Name, searchTerm) ||
                i.CustomStringFields.Any(f => EF.Functions.FreeText(f.Value, searchTerm)) ||
                i.CustomTextAreaFields.Any(f => EF.Functions.FreeText(f.Value, searchTerm)) ||
                i.Tags.Any(t => EF.Functions.FreeText(t.Name, searchTerm)) ||
                i.Comments.Any(c => EF.Functions.FreeText(c.Text, searchTerm))
                )
                .Include(i => i.Collection)
                .ThenInclude(i => i.Author)
                .ToListAsync();
            return View(model);
        }
        [Route("{controller}/Tags", Name = "SearchTags")]
        public async Task<IActionResult> SearchTags([FromQuery] string searchTerm)
        {
            var tags = await _context.Tags.Where(t => t.Name.StartsWith(searchTerm)).Select(t => new
            {
                Name = t.Name
            }).ToListAsync();
            return Ok(tags);
        }
    }
}
