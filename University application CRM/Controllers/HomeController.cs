using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using University_application_CRM.Data;
using University_application_CRM.Models;

namespace University_application_CRM.Controllers
{
    public class HomeController : Controller
    {
        private CRMContext _context;

        public HomeController(CRMContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Login")]
        [HttpGet]
        public IActionResult Login()
        {
            var login = new LoginViewModel();
            return View(login);
        }

        [Route("/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var User = _context.Users.Where(s => s.UserName == login.UserName && s.Password == login.Password).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return View(login);
            }
            if (User == null)
            {
                return View(login);
            }

            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(User.Id)),
                new Claim(ClaimTypes.Name, User.UserName)
            };

            var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, 
                new AuthenticationProperties { IsPersistent = login.RememberMe});


            return RedirectToAction("Index");
        }

        [Route("/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}