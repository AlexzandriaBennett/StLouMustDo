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


            //if (UserExists(email))
            //{
            //    var user = await _context.UserProfileViewModel
            //        .FirstOrDefaultAsync(m => m.EmailAddress == email);


            //    //var tempBucketList = await _context.BucketList.FirstOrDefaultAsync(m => m.UserKey == tempUserName);
            //    //_context.Entry(tempBucketList).Collection(x => x.Restaurants).Load();

            //    var tempBucketList = await _context.BucketList.FirstOrDefaultAsync(m => m.BucketId == user.BucketId);
            //    _context.Entry(tempBucketList).Collection(x => x.Cafes).Load();
            //    _context.Entry(tempBucketList).Collection(x => x.Restaurants).Load();
            //    _context.Entry(tempBucketList).Collection(x => x.Attractions).Load();
            //    _context.Entry(tempBucketList).Collection(x => x.Outdoors).Load();

            //    user.BucketList = tempBucketList;

            //    //_context.Entry(thisuser).Collection(x => x.BucketList.Cafes).Load();
            //    //_context.Entry(user).Collection(x => x.BucketList).Load();
            //    return View(user);

            //}

            //else
            //{
            //    var thisUser = new UserProfileViewModel();
            //    thisUser.Name = User.Identity.Name;
            //    thisUser.EmailAddress = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
            //    thisUser.ProfileImage = User.FindFirst(c => c.Type == "picture")?.Value;
            //    var usersBucket = new BucketList();
            //    usersBucket.Restaurants = new List<Restaurants>();

            //    usersBucket.Cafes = new List<Cafe>();

            //    usersBucket.Outdoors = new List<StatewideOutdoors>();

            //    usersBucket.Attractions = new List<LocalAttraction>();

            //    thisUser.BucketList = usersBucket;
            //    _context.Add(thisUser);
            //    await _context.SaveChangesAsync();

            //    return View(thisUser);


        }
        

        //    private bool UserExists(string email)
        //{
        //    return _context.UserProfileViewModel.Any(e => e.EmailAddress == email);
        //}
    }
}
