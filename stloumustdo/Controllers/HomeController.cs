using Microsoft.AspNetCore.Mvc;
using stloumustdo.Data;
using stloumustdo.Models;
using stloumustdo.POCO;
using System.Diagnostics;
using System.Security.Claims;

namespace stloumustdo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly stloumustdoContext _context;

       

        public HomeController(ILogger<HomeController> logger, stloumustdoContext context)
        {
            _logger = logger;
            _context = context;

        }

        public async Task<IActionResult> IndexAsync()
        {
            if (User.Identity.Name != null)
            {
                var email = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value.ToString();

                var userFinder = new UserFinder();

                var response = await userFinder.ReturnUserProfileAsync(email, _context, User);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private bool UserExists(string email)
        {
            return _context.UserProfileViewModel.Any(e => e.EmailAddress == email);
        }
    }
}