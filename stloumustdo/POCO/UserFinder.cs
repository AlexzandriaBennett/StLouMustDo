using Microsoft.EntityFrameworkCore;
using stloumustdo.Data;
using stloumustdo.Models;
using System.Security.Claims;

namespace stloumustdo.POCO
{
    public class UserFinder
    {

       
       public async Task<UserProfileViewModel> ReturnUserProfileAsync(string email, stloumustdoContext context, ClaimsPrincipal User)
        {

            if (UserExists(email, context))
            {
                var currentUser = await context.UserProfileViewModel
                    .FirstOrDefaultAsync(m => m.EmailAddress == email);


                //var tempBucketList = await _context.BucketList.FirstOrDefaultAsync(m => m.UserKey == tempUserName);
                //_context.Entry(tempBucketList).Collection(x => x.Restaurants).Load();

                var tempBucketList = await context.BucketList.FirstOrDefaultAsync(m => m.BucketId == currentUser.BucketId);
                context.Entry(tempBucketList).Collection(x => x.Cafes).Load();
                context.Entry(tempBucketList).Collection(x => x.Restaurants).Load();
                context.Entry(tempBucketList).Collection(x => x.Attractions).Load();
                context.Entry(tempBucketList).Collection(x => x.Outdoors).Load();

                currentUser.BucketList = tempBucketList;

                //_context.Entry(thisuser).Collection(x => x.BucketList.Cafes).Load();
                //_context.Entry(user).Collection(x => x.BucketList).Load();
                return currentUser;

            }

            else
            {
                var newUser = new UserProfileViewModel();
                newUser.Name = User.Identity.Name;
                newUser.EmailAddress = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
                newUser.ProfileImage = User.FindFirst(c => c.Type == "picture")?.Value;
                var usersBucket = new BucketList();
                usersBucket.Restaurants = new List<Restaurants>();

                usersBucket.Cafes = new List<Cafe>();

                usersBucket.Outdoors = new List<StatewideOutdoors>();

                usersBucket.Attractions = new List<LocalAttraction>();

                newUser.BucketList = usersBucket;
                context.Add(newUser);
                await context.SaveChangesAsync();

                return newUser;


            }
        }

        private bool UserExists(string email, stloumustdoContext context)
        {
            return context.UserProfileViewModel.Any(e => e.EmailAddress == email);
        }

    }
}
