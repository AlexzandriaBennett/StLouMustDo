#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stloumustdo.Data;
using stloumustdo.Models;
using stloumustdo.POCO;

namespace stloumustdo.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly stloumustdoContext _context;

        public RestaurantsController(stloumustdoContext context)
        {
            _context = context;
        }

        private bool UserExists(string email)
        {
            return _context.UserProfileViewModel.Any(e => e.EmailAddress == email);
        }


        [Authorize]
        public async Task<IActionResult> Add(int? id)
        {

            var restaurant = await _context.Restaurants
                    .FirstOrDefaultAsync(m => m.Id == id);

            var tempUserEmail = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;

            var thisuser = await _context.UserProfileViewModel.FirstOrDefaultAsync(m => m.EmailAddress == tempUserEmail);
            if (thisuser == null)
            {
                return RedirectToAction("Profile", "Account");
            }

            try
            {
                var thisUsersBucketList = await _context.BucketList.FirstOrDefaultAsync(c => c.BucketId == thisuser.BucketId);
                thisUsersBucketList.Restaurants.Add(restaurant);

                //TODO: Check if Cafe is already on the list and dont let it get added again

                await _context.SaveChangesAsync();
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

           
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            var email = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value.ToString();


            if (UserExists(email))
            {
                var response = new UserRestaurantList();
                response.HasRestaurant = new List<bool>();
                response.Restaurants = await _context.Restaurants.ToListAsync();

                var userFinder = new UserFinder();

                var response2 = await userFinder.ReturnUserProfileAsync(email, _context, User);
                var userResaurantList = response2.BucketList.Restaurants;



                foreach (var restaurant in response.Restaurants)
                {
                    var isMatched = false;
                    foreach (var userRestaurant in userResaurantList)
                    {
                        if (restaurant.RestaurantName == userRestaurant.RestaurantName)
                        {
                            isMatched = true;
                        }
                    }
                    response.HasRestaurant.Add(isMatched);
                    //TODO: this is the most inefficient way. How do I improve this?? 
                }

                return View(response);
            }
            else
            {
                var response = new UserRestaurantList();
                response.Restaurants = await _context.Restaurants.ToListAsync();
                response.HasRestaurant = new List<bool>();
                foreach (var restaurant in response.Restaurants)
                {
                    response.HasRestaurant.Add(false);
                }
                return View(response);
            }
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurants = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurants == null)
            {
                return NotFound();
            }

            return View(restaurants);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RestaurantName,RestaurantType,PriceRange,Neighborhood,WebsiteUrl,ResturauntAddress")] Restaurants restaurants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurants);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurants = await _context.Restaurants.FindAsync(id);
            if (restaurants == null)
            {
                return NotFound();
            }
            return View(restaurants);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RestaurantName,RestaurantType,PriceRange,Neighborhood,WebsiteUrl,ResturauntAddress")] Restaurants restaurants)
        {
            if (id != restaurants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantsExists(restaurants.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restaurants);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurants = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurants == null)
            {
                return NotFound();
            }

            return View(restaurants);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurants = await _context.Restaurants.FindAsync(id);
            _context.Restaurants.Remove(restaurants);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantsExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}
