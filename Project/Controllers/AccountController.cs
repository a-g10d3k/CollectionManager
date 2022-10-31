using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project.Data;
using Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountController(ILogger<AccountController> logger, AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return LocalRedirect("/");
            return View();
        }

        [HttpPost]
        [Route("{controller}/Login")]
        public async Task<IActionResult> LoginPost(LoginModel model)
        {
            await CreateRoles();
            await CreateDefaultAdmin();
            if (!ModelState.IsValid) return View("Login", model);
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && user.Blocked)
            {
                ModelState.AddModelError(string.Empty, "You've been blocked from accessing your account.");
                return View("Login", model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
            if (result.Succeeded)
            {
                _logger.LogInformation($"User {User.Identity!.Name} logged in.");
                if (user != null)
                {
                    user.LastLogin = DateTime.Now;
                    _context.SaveChanges();
                }
                return LocalRedirect("/");
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning($"User {User.Identity!.Name} locked out.");
                ModelState.AddModelError(String.Empty, "You've been locked out of your account for failing too many login attempts. Please try again later.");
                return View("Login", model);
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View("Login", model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity!.IsAuthenticated) return LocalRedirect("/");
            return View();
        }


        [HttpPost]
        [Route("{controller}/Register")]
        public async Task<IActionResult> RegisterPost(RegisterModel model)
        {
            await CreateRoles();
            await CreateDefaultAdmin();
            if (!ModelState.IsValid) return View("Register", model);
            if (model.Username == _configuration["DefaultAdminUsername"]) return Forbid();
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                LastLogin = DateTime.Now,
                Created = DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, isPersistent: false);
                _logger.LogInformation($"User {user.UserName} was created.");
                return LocalRedirect("/");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View("Register", model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity!.IsAuthenticated) return LocalRedirect("/");
            await _signInManager.SignOutAsync();
            _logger.LogInformation($"User {User.Identity!.Name} logged out.");
            return LocalRedirect("/");
        }

        private async Task CreateRoles()
        {

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                await _roleManager.CreateAsync(adminRole);
            }
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var userRole = new IdentityRole("User");
                await _roleManager.CreateAsync(userRole);
            }
        }

        private async Task CreateDefaultAdmin()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            if (admins.Count > 0 && admins.Any(user => !user.Blocked)) return;
            var currentDefaultAdmin = await _context.Users.Where(u => u.UserName == _configuration["DefaultAdminUsername"])
                .FirstOrDefaultAsync();
            if (currentDefaultAdmin != null)
            {
                if(currentDefaultAdmin.Blocked) currentDefaultAdmin.Blocked = false;
                if (!await _userManager.IsInRoleAsync(currentDefaultAdmin, "Admin")) await _userManager.AddToRoleAsync(currentDefaultAdmin, "Admin");
                await _context.SaveChangesAsync();
                return;
            }
            var user = new ApplicationUser
            {
                UserName = _configuration["DefaultAdminUsername"],
                Email = _configuration["DefaultAdminEmail"],
                LastLogin = DateTime.Now,
                Created = DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, _configuration["DefaultAdminPassword"]);
            if (!result.Succeeded) return;
            await _userManager.AddToRoleAsync(user, "User");
            await _userManager.AddToRoleAsync(user, "Admin");
            _logger.LogInformation($"Default admin {user.UserName} was created.");
        }
    }
}
