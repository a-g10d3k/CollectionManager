using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class UsersController : Controller
    {
        private AppDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public const int CollectionsPerPage = 8;

        public UsersController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("{controller}/{username}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string username, [FromQuery] int page = 1)
        {
            if (page < 1) page = 1;
            var query = _context.Users.Where(u => u.UserName == username).Select(u => new UserDto
            {
                User = u,
                Collections = u.Collections.OrderByDescending(c => c.Created)
                .Skip((page - 1) * CollectionsPerPage)
                .Take(CollectionsPerPage).ToList(),
                MaxPage = u.Collections.Count() / (CollectionsPerPage + 1) + 1
            });
            if (!query.Any()) return NotFound();
            var user = await query.FirstAsync();
            var currentUser = await _userManager.GetUserAsync(User);
            bool isOwner = await _userManager.IsInRoleAsync(user.User, "Admin") || user.User == currentUser;
            user.IsOwner = isOwner;
            user.Page = page;
            return View(user);
        }
    }
}
