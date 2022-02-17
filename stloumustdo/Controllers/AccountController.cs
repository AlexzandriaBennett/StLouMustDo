using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using stloumustdo.Data;
using stloumustdo.Models;
using System.Security.Claims;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using stloumustdo.POCO;

namespace stloumustdo.Controllers
{
    public class AccountController : Controller
    {


        private readonly stloumustdoContext _context;

        public AccountController(stloumustdoContext context)
        {
            _context = context;
        }

        public async Task Login(string returnUrl = "/")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);


        }

        public async Task<RedirectToActionResult> Redirect()
        {
            return RedirectToAction(nameof(Profile));
        }

        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action("Index", "Home"))
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var email = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value.ToString();

            var userFinder = new UserFinder();

            var response = await userFinder.ReturnUserProfileAsync(email, _context, User);

            return View(response);


        }
    }
}
