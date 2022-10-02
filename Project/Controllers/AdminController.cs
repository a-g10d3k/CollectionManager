using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Microsoft.AspNetCore.Identity;
using Project.Models;

namespace Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger, AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult UserManagement()
        {
            return View();
        }

        [HttpGet]
        [Route("{controller}/getusers")]
        public async Task<IActionResult> GetUsers()
        {
            if (_context?.Users == null) return StatusCode(503);
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var users = await _context.Users.Select(u => new
            {
                Id = u.Id,
                Name = u.UserName,
                Email = u.Email,
                LastLogin = u.LastLogin.ToString("dd/MM/yyyy HH:mm:ss"),
                Created = u.Created.ToString("dd/MM/yyyy HH:mm:ss"),
                Blocked = u.Blocked,
                Admin = admins.Contains(u)
            }).ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("{controller}/deleteusers")]
        public async Task<IActionResult> DeleteUsers([FromBody] List<string> ids)
        {
            if (_context?.Users == null) return StatusCode(503);
            foreach (var id in ids)
                await DeleteUserById(id);
            return Ok(ids);
        }

        [HttpPost]
        [Route("{controller}/setblockstatus")]
        public async Task<IActionResult> BlockUsers([FromBody] List<string> ids, [FromQuery] bool status)
        {
            if (_context?.Users == null) return StatusCode(503);
            var users = await _context.Users.Where(u => ids.Contains(u.Id)).ToListAsync();
            foreach (var user in users)
            {
                user.Blocked = status;
                if(status == true) await _userManager.UpdateSecurityStampAsync(user);
                _logger.LogInformation($"User {user.UserName} was {(status ? "blocked" : "unblocked")}.");
            }
            await _context.SaveChangesAsync();
            return Ok(ids);
        }

        [HttpPost]
        [Route("{controller}/setadminstatus")]
        public async Task<IActionResult> SetAdmin([FromBody] List<string> ids, [FromQuery] bool status)
        {
            if (_context?.Users == null) return StatusCode(503);
            var users = await _context.Users.Where(u => ids.Contains(u.Id)).ToListAsync();
            foreach (var user in users)
            {
                if (status == true) await _userManager.AddToRoleAsync(user, "Admin");
                else await _userManager.RemoveFromRoleAsync(user, "Admin");
            }
            await _context.SaveChangesAsync();
            return Ok(ids);
        }

        private async Task DeleteUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return;
            await _userManager.DeleteAsync(user);
        }
    }
}
