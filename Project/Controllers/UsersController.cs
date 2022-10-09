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
        public IActionResult GetUser(string username)
        {
            var query = _context.Users.Where(u => u.UserName == username)
                .Include(u => u.Collections);
            if (!query.Any()) return NotFound();
            var user = query.First();
            return View(user);
        }
    }
}
