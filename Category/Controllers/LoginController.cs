using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Category.Domain.Models;

namespace Category.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserDomain userDomain)
        {
            if(!ModelState.IsValid)
            {
                ViewData["Invalid"] = "Invalid User";
                return View();

            }
            if (userDomain.UserName.ToLower() == "admin" && userDomain.Password == "admin")
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, userDomain.UserName));
                claims.Add(new Claim(ClaimTypes.Name, userDomain.UserName));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Home");
            }else if(userDomain.UserName.ToLower() == "user" && userDomain.Password == "user")
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, userDomain.UserName));
                claims.Add(new Claim(ClaimTypes.Name, userDomain.UserName));
                claims.Add(new Claim(ClaimTypes.Role, "User"));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);
                return RedirectToAction("Privacy", "Home");
            }
            ModelState.AddModelError("", "Invalid Credential");
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
