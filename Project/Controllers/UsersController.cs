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

        public UsersController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("{controller}/{username}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string username)
        {
            var query = _context.Users.Where(u => u.UserName == username)
                .Include(u => u.Collections);
            if (!query.Any()) return NotFound();
            var user = await query.FirstAsync();
            var currentUser = await _userManager.GetUserAsync(User);
            bool isOwner = await _userManager.IsInRoleAsync(user, "Admin") || user == currentUser;
            ViewData["IsOwner"] = isOwner;
            return View(user);
        }
    }
}
